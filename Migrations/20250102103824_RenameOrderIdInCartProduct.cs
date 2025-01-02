using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace squirrels.Migrations
{
    /// <inheritdoc />
    public partial class RenameOrderIdInCartProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "CartProducts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "CartProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

// IF RENAME IS NEEDED

//migrationBuilder.RenameColumn(
//    name: "OrderId",
//    table: "CartProducts",
//    newName: "UserId");