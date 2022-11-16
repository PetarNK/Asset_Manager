using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Models
{
    public class UserAssetModel
    {
        [Required]
        public Guid AssetId { get; set; }
        [ForeignKey(nameof(AssetId))]
        public AssetModel Asset { get; set; } = null!;
        [Required]
        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public UserModel User { get; set; } = null!;
    }
}
