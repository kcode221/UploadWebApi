using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPICore.Service;

namespace MyWebAPICore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IStorageService _storageService;

        public FileUploadController(IStorageService storageService)
        {
            _storageService = storageService;
        }
        public IActionResult Get()
        {
            return Ok("File upload running ...");
        }

        [HttpPost]
        [Route("upload")]
        public IActionResult Upload(IFormFile file)
        {
            var successMsg = _storageService.Upload(file);
            return Ok($"in file upload post method {successMsg}");
        }
    }
}