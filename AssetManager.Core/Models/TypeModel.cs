using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Models
{
    public class TypeModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Type { get; set; } = null!;
        public List<AssetModel> Assets { get; set; } =  new List<AssetModel>();
        
    }
}
