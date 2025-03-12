using E_Commerce.Domain.Models;
using E_Commerce.Domain.Models.Cart;
using E_Commerce.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace E_Commerce.Infrastructure.Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<CheckoutHistory> CheckoutHistory { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductImages> ProductsImages { get; set; }
        public DbSet<ProductGender> Genders { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<SizeOption> SizeOptions { get; set; }
        
        public DbSet<ProductVariation> ProductVariations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "c0a1bdf5-1221-4050-82a6-9420d9e71964", Name= "Admin", NormalizedName = "ADMIN"},
                new IdentityRole { Id = "4a16c373-f59c-4ac6-aa64-51c8c87137eb", Name= "User", NormalizedName = "USER"}
                );

            builder.Entity<PaymentMethod>().HasData(
                new PaymentMethod { Id = "c604226c-9b6b-4465-aa75-5ecefba8d840", Name = "CreditCard" },
                new PaymentMethod { Id = "c604226c-9b6b-4465-aa75-5ecefba8d835", Name = "Paypal" }
                );

            builder.Entity<ProductGender>().HasData(
                new ProductGender { Id = Guid.Parse("546c234a-390b-467b-913c-c6153ba4f83a") , Name = "Men" },
                new ProductGender { Id = Guid.Parse("c99a79ab-2a1e-40c9-a821-cfe627134acc"), Name = "Women" }
                );

			builder.Entity<Color>().HasData(
	            new Color { Id = Guid.Parse("475208bf-d3fe-4029-a381-474ab0daa225"), Name = "Black", HexCode = "#000000" },
	            new Color { Id = Guid.Parse("575208bf-d3fe-4029-a381-474ab0daa225"), Name = "White", HexCode = "#FFFFFF" },
	            new Color { Id = Guid.Parse("675208bf-d3fe-4029-a381-474ab0daa225"), Name = "Gray", HexCode = "#808080" },
	            new Color { Id = Guid.Parse("775208bf-d3fe-4029-a381-474ab0daa225"), Name = "Light Gray", HexCode = "#D3D3D3" },
	            new Color { Id = Guid.Parse("875208bf-d3fe-4029-a381-474ab0daa225"), Name = "Charcoal", HexCode = "#333333" },
	            new Color { Id = Guid.Parse("975208bf-d3fe-4029-a381-474ab0daa225"), Name = "Navy Blue", HexCode = "#001F3F" },
	            new Color { Id = Guid.Parse("175208bf-d3fe-4029-a381-474ab0daa225"), Name = "Royal Blue", HexCode = "#4169E1" },
	            new Color { Id = Guid.Parse("275208bf-d3fe-4029-a381-474ab0daa225"), Name = "Sky Blue", HexCode = "#87CEEB" },
	            new Color { Id = Guid.Parse("375208bf-d3fe-4029-a381-474ab0daa225"), Name = "Red", HexCode = "#FF0000" },
	            new Color { Id = Guid.Parse("315208bf-d3fe-4029-a381-474ab0daa225"), Name = "Dark Red (Maroon)", HexCode = "#800000" },
	            new Color { Id = Guid.Parse("325208bf-d3fe-4029-a381-474ab0daa225"), Name = "Burgundy", HexCode = "#8B0000" },
	            new Color { Id = Guid.Parse("335208bf-d3fe-4029-a381-474ab0daa225"), Name = "Brown", HexCode = "#654321" },
	            new Color { Id = Guid.Parse("345208bf-d3fe-4029-a381-474ab0daa225"), Name = "Tan", HexCode = "#D2B48C" },
	            new Color { Id = Guid.Parse("355208bf-d3fe-4029-a381-474ab0daa225"), Name = "Beige", HexCode = "#F5F5DC" },
	            new Color { Id = Guid.Parse("365208bf-d3fe-4029-a381-474ab0daa225"), Name = "Olive Green", HexCode = "#808000" },
	            new Color { Id = Guid.Parse("371208bf-d3fe-4029-a381-474ab0daa225"), Name = "Military Green", HexCode = "#4B5320" },
	            new Color { Id = Guid.Parse("372208bf-d3fe-4029-a381-474ab0daa225"), Name = "Forest Green", HexCode = "#228B22" },
	            new Color { Id = Guid.Parse("373208bf-d3fe-4029-a381-474ab0daa225"), Name = "Yellow", HexCode = "#FFD700" },
	            new Color { Id = Guid.Parse("374208bf-d3fe-4029-a381-474ab0daa225"), Name = "Orange", HexCode = "#FF4500" },
	            new Color { Id = Guid.Parse("376208bf-d3fe-4029-a381-474ab0daa225"), Name = "Purple", HexCode = "#800080" },
	            new Color { Id = Guid.Parse("377208bf-d3fe-4029-a381-474ab0daa225"), Name = "Violet", HexCode = "#9400D3" },
	            new Color { Id = Guid.Parse("378208bf-d3fe-4029-a381-474ab0daa225"), Name = "Pink", HexCode = "#FFC0CB" },
	            new Color { Id = Guid.Parse("379208bf-d3fe-4029-a381-474ab0daa225"), Name = "Rose Gold", HexCode = "#B76E79" },
	            new Color { Id = Guid.Parse("375108bf-d3fe-4029-a381-474ab0daa225"), Name = "Gold", HexCode = "#FFD700" },
	            new Color { Id = Guid.Parse("375808bf-d3fe-4029-a381-474ab0daa225"), Name = "Silver", HexCode = "#C0C0C0" }
            );

			builder.Entity<ProductItem>()
		    .HasOne(p => p.Color)
		    .WithMany(c => c.ProductItems)  // No navigation property in Color (or use .WithMany(c => c.ProductItems) if needed)
		    .HasForeignKey(p => p.ColorId)
		    .OnDelete(DeleteBehavior.Restrict);  // ⛔ Prevents cascade delete


			builder.Entity<SizeOption>().HasData(
                new SizeOption() { Id = Guid.Parse("87d466c9-b472-4bf5-aa6a-36542dcd2168"), Name = "38", SortOrder = 1},
                new SizeOption() { Id = Guid.Parse("67ff2632-eaca-4517-a003-e0d350180830"), Name = "39", SortOrder = 2},
                new SizeOption() { Id = Guid.Parse("91428799-f976-41c4-ba90-f37ef89c32a2"), Name = "40", SortOrder = 3},
                new SizeOption() { Id = Guid.Parse("75c8d74b-a14d-4fcc-a6d2-c45f88fab43f"), Name = "41", SortOrder = 4},
                new SizeOption() { Id = Guid.Parse("e2748efb-9886-49a6-bcf1-797f68e67f17"), Name = "42", SortOrder = 5},
                new SizeOption() { Id = Guid.Parse("28457f8e-7f80-488a-be4a-55b105425f37"), Name = "43", SortOrder = 6},
                new SizeOption() { Id = Guid.Parse("ca20f2fa-a6b8-440e-bbcc-efadf412a42d"), Name = "44", SortOrder = 7},
                new SizeOption() { Id = Guid.Parse("4fce50b1-bb79-4bce-8da0-4970f8aa0760"), Name = "45", SortOrder = 8},
                new SizeOption() { Id = Guid.Parse("f392c6d7-94ec-4705-9669-530823e5de24"), Name = "46", SortOrder = 9},
                new SizeOption() { Id = Guid.Parse("30933c30-bca4-4683-945a-0e482a8c4fb8"), Name = "47", SortOrder = 10}
                );
            builder.Entity<SizeOption>()
                .HasIndex(s => s.Name)
                .IsUnique();

            builder.Entity<ProductItem>()
                .Navigation(pi => pi.ProductVariations)
                .AutoInclude();
			builder.Entity<ProductItem>()
				.Navigation(pi => pi.Images)
				.AutoInclude();

			builder.Entity<ProductVariation>()
                .Navigation(pv => pv.SizeOption)
                .AutoInclude();

            builder.Entity<Order>()
                .Navigation(o => o.CheckoutHistories)
                .AutoInclude();
        }
    }
}
