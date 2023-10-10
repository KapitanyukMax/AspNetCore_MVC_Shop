using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cars & Transport" },
                    { 2, "Pets" },
                    { 3, "Home & Garden" },
                    { 4, "Electronics" },
                    { 5, "Fashion" },
                    { 6, "Hobbies & Sport" },
                    { 7, "Musical Instruments" },
                    { 8, "Art" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CategoryId", "Description", "Discount", "ImagePath", "Name", "Price", "Rating", "Status" },
                values: new object[,]
                {
                    { 1, 4, "Excellent condition as new\nPassed the test for 30 points for workability\nThere is a warranty for the device from the store up to 2 years", 33.299999999999997, "https://www.reliancedigital.in/medias/Apple-MLPF3HN-A-Smart-Phone-491997699-i-1-1200Wx1200H?context=bWFzdGVyfGltYWdlc3wyNTU5NTZ8aW1hZ2UvanBlZ3xpbWFnZXMvaDU5L2hlOC85ODc4MDkwMDg4NDc4LmpwZ3wxNGQzODYyZWJiYjYwZDVjZjNhM2Q5YzQ4ZmE5OTljMmZiYmM2MDE0ZjE1YzhhMTRmYjM2ZDkzZGEyODcxNTU2", "iPhone 13 256GB", 25610.200000000001, 6, 0 },
                    { 2, 1, null, 0.0, "https://ireland.apollo.olxcdn.com/v1/files/dddvh1ibzptb-UA/image", "2020 Volvo S60", 473027.70000000001, 8, 2 },
                    { 3, 7, "Great synthesizer professional line YAMAHA PSR E-343!\nPerfect condition!\nBoth adults and children can easily master the user-friendly control interface. This is a tool in which the design is organically combined with the necessary functionality", 0.0, "https://ireland.apollo.olxcdn.com/v1/files/utm4vzs67i893-UA/image", "Synthesizer Yamaha PSR E-343", 7900.0, 6, 0 },
                    { 4, 4, "A great printer that is suitable for both office and home use.\nThe printer allows you to print color photos and black and white text, as well as scan images. It has energy-saving functions, in particular sleep mode and auto-off mode", 10.0, "https://ireland.apollo.olxcdn.com/v1/files/66wfny594cwu3-UA/image", "Printer HP DeskJet 2300", 2000.0, 5, 1 },
                    { 5, 3, null, 0.0, "https://ireland.apollo.olxcdn.com/v1/files/w80mjaevar2s-UA/image", "Sofa", 10830.0, 7, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
