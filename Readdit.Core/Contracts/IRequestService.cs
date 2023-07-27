using Readdit.Core.DTOs;
using Readdit.Data.Models.Requests;
using Readdit.Models.Requests;
using Microsoft.AspNetCore.Identity;

namespace Readdit.Core.Contracts
{
    public interface IRequestService
    {
        Task<IEnumerable<ShowRequestDto>> GetAllRequests(string userId);
        IEnumerable<CategoryDto> GetAllCategories();
        Task<RequestEditDto> GetAddNewRequest();
        Task AddNewRequestAsync(RequestEditDto model, string userId);
        Task<ShowRequestDto> GetRequest(int id, string userId);
        Task UpvoteRequest(int requestId, string userId);
        Task RemoveUpvoteRequest(int requestId, string userId);
        Task ApproveRequest(int id);
        Task DeclineRequest(int id, string rejectionJustification);
    }
}
