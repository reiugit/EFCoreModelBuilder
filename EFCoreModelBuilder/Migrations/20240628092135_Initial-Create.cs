using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreModelBuilder.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AProducts", x => x.Id);
                    table.CheckConstraint("CK_Price_not_negative", "Price > 0");
                });

            migrationBuilder.CreateTable(
                name: "BProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BProducts", x => x.Id);
                    table.CheckConstraint("CK_Price_not_negative1", "Price > 0");
                });

            migrationBuilder.InsertData(
                table: "AProducts",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 1, "Description", "Class AProduct is configured mostly via annotations.", 5.5m });

            migrationBuilder.InsertData(
                table: "BProducts",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[] { 1, "Description", "Class BProduct is configured only via DbContext.ModelBuilder.", 5.5m });

            migrationBuilder.CreateIndex(
                name: "IX_AProducts_Name",
                table: "AProducts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BProducts_Name",
                table: "BProducts",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AProducts");

            migrationBuilder.DropTable(
                name: "BProducts");
        }
    }
}
