
using Microsoft.AspNetCore.Http;

namespace Regon.Application.Common
{
    public interface ILocalFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
    }
}
