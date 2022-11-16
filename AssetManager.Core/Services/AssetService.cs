using AssetManager.Core.Contracts;
using AssetManager.Core.Data.Common;
using AssetManager.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Services
{
    /// <summary>
    /// Working with and manipulating assets data
    /// </summary>
    public class AssetService : IAssetService
    {
        private readonly IConfiguration config;

        private readonly IRepository repo;
        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="_config">App configuration</param>
        public AssetService(
            IConfiguration _config,
            IRepository _repo
            )
        {
            config = _config;
            repo= _repo;
        }

        public async Task Add(AssetModel model)
        {
            var assets = new AssetModel()
            {
                Name = model.Name,
                SerialNumber = model.SerialNumber,
                Type = model.Type,
                Value = model.Value,
            };

           await repo.AddAsync(assets);
           await repo.SaveChangesAsync();
           
        }
        /// <summary>
        /// Gets all assets
        /// </summary>
        /// <returns>List of assets</returns>
        public async Task<IEnumerable<AssetModel>> GetAll()
        {
            return await repo.AllReadonly<AssetModel>()
                .Select(a => new AssetModel()
                {
                    Id= a.Id,
                    Name = a.Name,
                    SerialNumber = a.SerialNumber,
                    TypeId= a.TypeId,
                    Type = a.Type,
                    Value = a.Value,
                }).ToListAsync();
        }

        
        
    }
}
