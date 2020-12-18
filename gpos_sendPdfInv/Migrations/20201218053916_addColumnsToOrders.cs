using Microsoft.EntityFrameworkCore.Migrations;

namespace gpos_sendPdfInv.Migrations
{
    public partial class addColumnsToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cCardName",
                table: "orders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cCardNum",
                table: "orders",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cCardType",
                table: "orders",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cRefCode",
                table: "orders",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cResponseTxt",
                table: "orders",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cSuccess",
                table: "orders",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "delivery_number",
                table: "orders",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_web_order",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "online_processed",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "order_deleted",
                table: "orders",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<decimal>(
                name: "order_total",
                table: "orders",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "station_id",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "total_charge",
                table: "orders",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "total_discount",
                table: "orders",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "total_special",
                table: "orders",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cCardName",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "cCardNum",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "cCardType",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "cRefCode",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "cResponseTxt",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "cSuccess",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "delivery_number",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "is_web_order",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "online_processed",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "order_deleted",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "order_total",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "station_id",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "total_charge",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "total_discount",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "total_special",
                table: "orders");
        }
    }
}
