using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taxi.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migDiscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Percent = table.Column<int>(type: "int", nullable: false),
                    Desc = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Expire = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");
        }
    }
}
