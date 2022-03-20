using Microsoft.AspNetCore.Http;

namespace MyWebAPICore.Service
{
    public interface IStorageService
    {
         string Upload(IFormFile file);
    }
}