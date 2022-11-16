using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AssetManager.Core.Models;

namespace AssetManager.Core.Data
{
    public class AssetManagerDbContext : IdentityDbContext<UserModel>
    {
        public AssetManagerDbContext(DbContextOptions<AssetManagerDbContext> options)
           : base(options)
        {
        }

        public DbSet<AssetModel> Assets { get; set; }

        public DbSet<TypeModel> Type { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserAssetModel>()
                .HasKey(x => new { x.UserId, x.AssetId });
            
            
            

            builder.Entity<UserModel>()
                .Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();
            builder.Entity<UserModel>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();




            builder
               .Entity<AssetModel>()
               .HasData(new AssetModel()
               {
                   Id = Guid.Parse("848114f0-2f02-4d19-87b1-dc104375da8a"),
                   Name = "Iphone 14 Pro",
                   SerialNumber = "223DW3441",
                   Value = 2000.0M,
                   TypeId = 1
               }) ;

            builder
           .Entity<TypeModel>()
           .HasData(new TypeModel()
           {
               Id = 1,
               Type = "Smartphone"
           },
            new TypeModel()
            {
                Id = 2,
                Type = "Laptop"
            },
           new TypeModel()
           {
               Id = 3,
               Type = "PC"
           },
           new TypeModel()
           {
               Id = 4,
               Type = "Monitor"
           },
           new TypeModel()
           {
               Id = 5,
               Type = "Mouse"
           },
           new TypeModel()
           {
               Id = 6,
               Type = "Keyboard"
           });


            base.OnModelCreating(builder);
        }
    }
}
