using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxi.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migMonthTypeupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "precent",
                table: "MonthTypes",
                newName: "Precent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Precent",
                table: "MonthTypes",
                newName: "precent");
        }
    }
}
