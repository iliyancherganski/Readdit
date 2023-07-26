using Readdit.Core.DTOs;
using Readdit.Core.Contracts;
using Readdit.Data;
using Readdit.Data.Models.Requests;
using Readdit.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Readdit.Data.Models.Enums;
using Readdit.Data.Models;
using Readdit.Data.Models.Resources.Actions;

namespace Readdit.Core.Services
{
    public class RequestService : IRequestService
    {
        private readonly BookshelfDbContext dbContext;
        public RequestService(BookshelfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<RequestEditDto> GetAddNewRequest()
        {
            var model = new RequestEditDto(GetAllCategories().ToList());
            return model;
        }
        public async Task AddNewRequestAsync(RequestEditDto model, string userId)
        {
            ResourceRequest rr = new ResourceRequest
            {
                UserId = userId,
                Title = model.Title,
                Author = model.Author,
                Status = RequestStatus.PendingReview,
                Priority = (RequestPriority)Enum.ToObject(typeof(RequestPriority), model.Priority),
                DateAdded = DateTime.Now,
                Justification = model.Justification
            };
            dbContext.ResourcesRequests.Add(rr);
            foreach (var categoryId in model.CategoryIds)
            {
                dbContext.CategoriesRequests.Add(new CategoryRequest
                {
                    Category = dbContext.Categories.FirstOrDefault(x => x.CategoryId == categoryId),
                    CategoryId = categoryId,
                    ResourceRequest = rr,
                    RequestId = rr.Id
                });
            }
            await dbContext.SaveChangesAsync();
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return dbContext.Categories.Select(x => new CategoryDto
            {
                Id = x.CategoryId,
                Name = x.CategoryName
            }).ToList();
        }

        public async Task<ShowRequestDto> GetRequest(int id, string userId)
        {
            var request = await dbContext.ResourcesRequests
                .FirstOrDefaultAsync(x => x.Id == id);
            var categories = new List<Category>();
            foreach (var categoryReq in await dbContext.CategoriesRequests.Where(c => c.RequestId == request.Id).ToListAsync())
            {
                var category = await dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == categoryReq.CategoryId);
                categories.Add(category);
            }
            request.Categories = categories;

            var dto = new ShowRequestDto(request, dbContext.RequestUpvotes.Where(x => x.RequestId == id).Select(x => x.User.Email).ToList());
            if (!string.IsNullOrEmpty(userId))
            {

                // Creator of request -> IsUpvoted = null
                if (dto.UserId == userId)
                {
                    dto.IsUpvoted = null;
                }
                // Not creator of request
                else
                {
                    if (dbContext.RequestUpvotes.Any(x => x.RequestId == id && x.UserId == userId))
                    {
                        dto.IsUpvoted = true;
                    }
                    else
                    {
                        dto.IsUpvoted = false;
                    }
                }
            }
            return dto;
        }

        public async Task<IEnumerable<ShowRequestDto>> GetAllRequests(string userId)
        {
            var ids = await dbContext.ResourcesRequests.Select(x => x.Id).ToListAsync();
            var requests = new List<ShowRequestDto>();
            foreach (var id in ids)
            {
                requests.Add(await GetRequest(id, userId));
            }

            return requests.OrderBy(x=>x.DateAdded);
        }

        public async Task UpvoteRequest(int requestId, string userId)
        {
            if (!dbContext.RequestUpvotes.Any(x => x.RequestId == requestId && x.UserId == userId))
            {
                RequestUpvote requestUpvote = new RequestUpvote()
                {
                    RequestId = requestId,
                    UserId = userId
                };
                dbContext.RequestUpvotes.Add(requestUpvote);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task RemoveUpvoteRequest(int requestId, string userId)
        {
            if (dbContext.RequestUpvotes.Any(x => x.RequestId == requestId && x.UserId == userId))
            {
                RequestUpvote requestUpvote = new RequestUpvote()
                {
                    RequestId = requestId,
                    UserId = userId
                };
                dbContext.RequestUpvotes.Remove(requestUpvote);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
