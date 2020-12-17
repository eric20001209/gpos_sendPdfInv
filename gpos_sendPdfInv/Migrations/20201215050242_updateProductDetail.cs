using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gpos_sendPdfInv.Migrations
{
    public partial class updateProductDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "details",
                table: "product_details",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "ingredients",
                table: "product_details",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "directions",
                table: "product_details",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "advice",
                table: "product_details",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "shipping",
                table: "product_details",
                nullable: true);
            //migrationBuilder.CreateTable(
            //    name: "product_details",
            //    columns: table => new
            //    {
            //        code = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        highlight = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        spec = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        manufacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        pic = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        rev = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        warranty = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        details = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        ingredients = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        directions = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        advice = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        shipping = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_product_details", x => x.code);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "settings",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        cat = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        value = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        description = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        hidden = table.Column<bool>(type: "bit", nullable: true),
            //        bool_value = table.Column<bool>(type: "bit", nullable: true),
            //        access = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_settings", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "stock_qty",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        code = table.Column<int>(type: "int", nullable: false),
            //        qty = table.Column<double>(type: "float", nullable: true),
            //        branch_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(1)"),
            //        supplier_price = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "(0)"),
            //        allocated_stock = table.Column<double>(type: "float", nullable: true, defaultValueSql: "(0)"),
            //        average_cost = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "(0)"),
            //        qpos_price = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "(0)"),
            //        special_price = table.Column<decimal>(type: "money", nullable: true),
            //        sp_start_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        sp_end_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        last_stock = table.Column<double>(type: "float", nullable: false),
            //        warning_stock = table.Column<double>(type: "float", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_stock_qty", x => x.id);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IDX_stock_qty_branch_id",
            //    table: "stock_qty",
            //    column: "branch_id");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_stock_qty_code",
            //    table: "stock_qty",
            //    column: "code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_details");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "stock_qty");
        }
    }
}
