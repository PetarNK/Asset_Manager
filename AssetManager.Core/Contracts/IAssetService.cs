using AssetManager.Core.Models;


namespace AssetManager.Core.Contracts
{
    /// <summary>
    /// Working with and manipulating assets data
    /// </summary>
    public interface IAssetService
    {
        /// <summary>
        /// Gets all assets
        /// </summary>
        /// <returns>List of assets</returns>
        Task<IEnumerable<AssetModel>> GetAll();

        Task Add(AssetModel model);
    }
}
