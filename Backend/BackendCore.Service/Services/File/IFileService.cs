using System.Threading.Tasks;
using BackendCore.Common.Core;
using Microsoft.AspNetCore.Http;

namespace BackendCore.Service.Services.File
{
    public interface IFileService 
    {

        /// <summary>
        /// Upload 
        /// </summary>
        /// <param name="files"></param>>
        /// <returns></returns>
        Task<IFinalResult> UploadAsync(IFormFileCollection files);
       
    }
}