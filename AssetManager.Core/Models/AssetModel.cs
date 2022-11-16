using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Models
{
    /// <summary>
    /// Asset view model
    /// </summary>
    public class AssetModel 
    {
        /// <summary>
        /// Asset Identifier
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Asset Name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Asset Serial Number
        /// </summary>
        [Required]
        [StringLength(40)]
        public string SerialNumber { get; set; } = null!;
        /// <summary>
        /// Asset type
        /// </summary>
        [Required]
        public int TypeId { get; set; }
        public TypeModel Type { get; set; } = null!;
        /// <summary>
        /// Asset value
        /// </summary>
        [Required]
        [Range(typeof(decimal), "1.00", "10000.00", ConvertValueInInvariantCulture = true)]
        public decimal Value { get; set; }
        public IEnumerable<UserAssetModel> UsersAssets { get; set; } = new List<UserAssetModel>();
    }
}
