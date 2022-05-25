using System.Threading.Tasks;
using BackendCore.Api.Controllers.Base;
using BackendCore.Common.Core;
using BackendCore.Service.Services.File;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendCore.Api.Controllers
{
    /// <summary>
    /// Files Controller
    /// </summary>
    public class FilesController : BaseController
    {
        private readonly IFileService _fileService;
        /// <summary>
        /// Constructor
        /// </summary>
        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }





        /// <summary>
        /// Upload Files
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IFinalResult> UploadAsync(IFormFileCollection files)
        {
            var result = await _fileService.UploadAsync(files);
            return result;
        }







    }
}
