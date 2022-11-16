using AssetManager.Core.Contracts;
using AssetManager.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManager.API.Controllers
{
    /// <summary>
    /// Initializes CRUD operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService assetService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_assetService"></param>
        public AssetController(IAssetService _assetService)
        {
            assetService = _assetService;
        }
        /// <summary>
        /// Getting all assets from DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await assetService.GetAll());
        }
        //[HttpGet]
        //public async Task<IActionResult> Add()
        //{
        //    var model = new AssetModel();

        //    return 
        //}
    }
}
