using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Helpers
{
    public static class DbInitializer
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category() { Id = 1, Name = "Cars & Transport" },
                new Category() { Id = 2, Name = "Pets" },
                new Category() { Id = 3, Name = "Home & Garden" },
                new Category() { Id = 4, Name = "Electronics" },
                new Category() { Id = 5, Name = "Fashion" },
                new Category() { Id = 6, Name = "Hobbies & Sport" },
                new Category() { Id = 7, Name = "Musical Instruments" },
                new Category() { Id = 8, Name = "Art" }
            });
        }

        public static void SeedItems(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(new[] {
                new Item()
                {
                    Id = 1,
                    Name = "iPhone 13 256GB",
                    Price = 25610.2,
                    Discount = 33.3,
                    Rating = 6,
                    Description = "Excellent condition as new\nPassed the test for 30 points for workability\nThere is a warranty for the device from the store up to 2 years",
                    ImagePath = "https://www.reliancedigital.in/medias/Apple-MLPF3HN-A-Smart-Phone-491997699-i-1-1200Wx1200H?context=bWFzdGVyfGltYWdlc3wyNTU5NTZ8aW1hZ2UvanBlZ3xpbWFnZXMvaDU5L2hlOC85ODc4MDkwMDg4NDc4LmpwZ3wxNGQzODYyZWJiYjYwZDVjZjNhM2Q5YzQ4ZmE5OTljMmZiYmM2MDE0ZjE1YzhhMTRmYjM2ZDkzZGEyODcxNTU2",
                    Status = Item.ItemStatus.InStock,
                    CategoryId = 4
                },
                new Item()
                {
                    Id = 2,
                    Name = "2020 Volvo S60",
                    Price = 473027.7,
                    Discount = 0.0,
                    Rating = 8,
                    ImagePath = "https://ireland.apollo.olxcdn.com/v1/files/dddvh1ibzptb-UA/image",
                    Status = Item.ItemStatus.Limited,
                    CategoryId = 1
                },
                new Item()
                {
                    Id = 3,
                    Name = "Synthesizer Yamaha PSR E-343",
                    Price = 7900.0,
                    Discount = 0.0,
                    Rating = 6,
                    Description = "Great synthesizer professional line YAMAHA PSR E-343!\nPerfect condition!\nBoth adults and children can easily master the user-friendly control interface. This is a tool in which the design is organically combined with the necessary functionality",
                    ImagePath = "https://ireland.apollo.olxcdn.com/v1/files/utm4vzs67i893-UA/image",
                    Status = Item.ItemStatus.InStock,
                    CategoryId = 7
                },
                new Item()
                {
                    Id = 4,
                    Name = "Printer HP DeskJet 2300",
                    Price = 2000.0,
                    Discount = 10.0,
                    Rating = 5,
                    Description = "A great printer that is suitable for both office and home use.\nThe printer allows you to print color photos and black and white text, as well as scan images. It has energy-saving functions, in particular sleep mode and auto-off mode",
                    ImagePath = "https://ireland.apollo.olxcdn.com/v1/files/66wfny594cwu3-UA/image",
                    Status = Item.ItemStatus.Unavailable,
                    CategoryId = 4
                },
                new Item()
                {
                    Id = 5,
                    Name = "Sofa",
                    Price = 10830.0,
                    Discount = 0.0,
                    Rating = 7,
                    ImagePath = "https://ireland.apollo.olxcdn.com/v1/files/w80mjaevar2s-UA/image",
                    Status = Item.ItemStatus.InStock,
                    CategoryId = 3
                }
            });
        }
    }
}
