using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_game.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedCostToFoodTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "Foods",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Foods");
        }
    }
}
