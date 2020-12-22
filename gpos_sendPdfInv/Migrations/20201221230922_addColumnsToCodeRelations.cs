using Microsoft.EntityFrameworkCore.Migrations;

namespace gpos_sendPdfInv.Migrations
{
    public partial class addColumnsToCodeRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<string>(
            //    name: "Cat",
            //    table: "sales",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "SCat",
            //    table: "sales",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "SsCat",
            //    table: "sales",
            //    type: "nvarchar(max)",
            //    nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "commission_rate",
                table: "code_relations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "country_of_origin",
                table: "code_relations",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_member_only",
                table: "code_relations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "is_special",
                table: "code_relations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "level_price0",
                table: "code_relations",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "level_price1",
                table: "code_relations",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "level_price2",
                table: "code_relations",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "level_price3",
                table: "code_relations",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "level_price4",
                table: "code_relations",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "level_price5",
                table: "code_relations",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "level_price6",
                table: "code_relations",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "level_price7",
                table: "code_relations",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "level_price8",
                table: "code_relations",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "level_price9",
                table: "code_relations",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "no_discount",
                table: "code_relations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "tax_code",
                table: "code_relations",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "tax_rate",
                table: "code_relations",
                type: "float",
                nullable: false,
                defaultValueSql: "((0.15))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cat",
                table: "sales");

            migrationBuilder.DropColumn(
                name: "SCat",
                table: "sales");

            migrationBuilder.DropColumn(
                name: "SsCat",
                table: "sales");

            migrationBuilder.DropColumn(
                name: "commission_rate",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "country_of_origin",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "is_member_only",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "is_special",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "level_price0",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "level_price1",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "level_price2",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "level_price3",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "level_price4",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "level_price5",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "level_price6",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "level_price7",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "level_price8",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "level_price9",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "no_discount",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "tax_code",
                table: "code_relations");

            migrationBuilder.DropColumn(
                name: "tax_rate",
                table: "code_relations");
        }
    }
}
