using Microsoft.EntityFrameworkCore.Migrations;

namespace gpos_sendPdfInv.Migrations
{
    public partial class addOnLineRetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OnLineRetail",
                table: "code_relations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnLineRetail",
                table: "code_relations");
        }
    }
}
