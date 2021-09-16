using Microsoft.EntityFrameworkCore.Migrations;

namespace Foodies.Data.Migrations
{
    public partial class FoodItemandCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    IsTodaySpecial = table.Column<bool>(type: "bit", nullable: false),
                    HasDiscount = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_FoodItems_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 1, "Vegeterian", "Pure Vegeterian Dishes" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 2, "Eggterian", "FoodItems with Egg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 3, "Non-Vegeterian", "Delicious Dishes of Non-Vegeterian" });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodId", "CategoryId", "FoodDescription", "FoodName", "HasDiscount", "ImageThumbnailUrl", "ImageUrl", "IsAvailable", "IsTodaySpecial", "Price" },
                values: new object[] { 1, 1, "South Indian Special", "Dosa", false, "/Images/dosa.jpg", "/Images/dosa.jpg", true, true, 40m });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodId", "CategoryId", "FoodDescription", "FoodName", "HasDiscount", "ImageThumbnailUrl", "ImageUrl", "IsAvailable", "IsTodaySpecial", "Price" },
                values: new object[] { 3, 1, "Hyderabadi Dum Biryani", "Biryani", false, "/Images/biryani.jpg", "/Images/biryani.jpg", true, true, 120m });

            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodId", "CategoryId", "FoodDescription", "FoodName", "HasDiscount", "ImageThumbnailUrl", "ImageUrl", "IsAvailable", "IsTodaySpecial", "Price" },
                values: new object[] { 2, 2, "Special Anda Sandwitch", "Anda Sandwitch", false, "/Images/eggsandwith.jpg", "/Images/eggsandwith.jpg", true, true, 30m });

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_CategoryId",
                table: "FoodItems",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
