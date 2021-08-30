using Microsoft.EntityFrameworkCore.Migrations;

namespace Spil_Til_Dig.Backend.Migrations
{
    public partial class AddedIndexToCheckIfProfuctKeyIsSold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Keys_IsSold",
                table: "Keys",
                column: "IsSold");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Keys_IsSold",
                table: "Keys");
        }
    }
}
