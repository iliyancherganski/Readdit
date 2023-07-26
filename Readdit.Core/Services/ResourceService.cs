using Readdit.Core.Contracts;
using Readdit.Data;
using Readdit.Data.Models.Resources;
using Microsoft.EntityFrameworkCore;

namespace Readdit.Core.Services
{
    public class ResourceService : IResourceService
    {
        private readonly BookshelfDbContext dbContext;

        public ResourceService(BookshelfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Resource>> GetAllResources()
        {
            return await dbContext.Resources
                .ToListAsync();
        }

        public async Task<IEnumerable<Resource>> GetAllUserResources(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
