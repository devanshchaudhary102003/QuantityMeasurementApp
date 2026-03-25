using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuantityMeasurementAppRepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class QuantityTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Quantity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Value1 = table.Column<double>(type: "float", nullable: false),
                    Value2 = table.Column<double>(type: "float", nullable: false),
                    Unit1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quantity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quantity_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quantity_UserId",
                table: "Quantity",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quantity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
