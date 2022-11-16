using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Models
{
    public class UserModel : IdentityUser
    {
        public List<UserAssetModel> UsersAssets { get; set; } = new List<UserAssetModel>();
    }
}
