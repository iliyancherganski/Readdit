using Readdit.Data.Models.Resources;

namespace Readdit.Core.Contracts
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>> GetAllResources();
        Task<IEnumerable<Resource>> GetAllUserResources(string userId);
    }
}
