using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gpos_sendPdfInv.Migrations
{
    public partial class addshippinginfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdersId",
                table: "invoice_freight",
                type: "int",
                nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "order_item",
            //    columns: table => new
            //    {
            //        kid = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        id = table.Column<int>(type: "int", nullable: false),
            //        code = table.Column<int>(type: "int", nullable: false),
            //        quantity = table.Column<double>(type: "float", nullable: false),
            //        item_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //        supplier = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        supplier_code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        supplier_price = table.Column<decimal>(type: "money", nullable: false),
            //        commit_price = table.Column<decimal>(type: "money", nullable: false),
            //        eta = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        system = table.Column<bool>(type: "bit", nullable: false),
            //        sys_special = table.Column<bool>(type: "bit", nullable: false),
            //        part = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((-1))"),
            //        kit = table.Column<bool>(type: "bit", nullable: false),
            //        krid = table.Column<int>(type: "int", nullable: true),
            //        discount_percent = table.Column<double>(type: "float", nullable: false),
            //        item_name_cn = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        cat = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        s_cat = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        ss_cat = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        order_total = table.Column<decimal>(type: "money", nullable: false),
            //        station_id = table.Column<int>(type: "int", nullable: true),
            //        pack = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //        quantity_supplied = table.Column<double>(type: "float", nullable: false),
            //        barcode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        tax_code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        tax_rate = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
            //        promo_id = table.Column<int>(type: "int", nullable: true),
            //        promo_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_order_item", x => x.kid);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "orders",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        branch = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
            //        number = table.Column<int>(type: "int", nullable: false),
            //        part = table.Column<int>(type: "int", nullable: false),
            //        card_id = table.Column<int>(type: "int", nullable: false),
            //        po_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        status = table.Column<byte>(type: "tinyint", nullable: true, defaultValueSql: "((1))"),
            //        invoice_number = table.Column<int>(type: "int", nullable: true),
            //        record_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        contact = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        special_shipto = table.Column<bool>(type: "bit", nullable: false),
            //        shipto = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
            //        date_shipped = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        shipby = table.Column<int>(type: "int", nullable: true),
            //        freight = table.Column<decimal>(type: "money", nullable: false),
            //        ticket = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        sales = table.Column<int>(type: "int", nullable: true),
            //        sales_manager = table.Column<int>(type: "int", nullable: true),
            //        sales_note = table.Column<string>(type: "ntext", nullable: true),
            //        locked_by = table.Column<int>(type: "int", nullable: true),
            //        time_locked = table.Column<DateTime>(type: "datetime", nullable: true),
            //        shipping_method = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
            //        pick_up_time = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        payment_type = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((3))"),
            //        paid = table.Column<bool>(type: "bit", nullable: false),
            //        trans_failed_reason = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
            //        debug_info = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
            //        system = table.Column<bool>(type: "bit", nullable: false),
            //        no_individual_price = table.Column<bool>(type: "bit", nullable: false),
            //        gst_inclusive = table.Column<bool>(type: "bit", nullable: false),
            //        type = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((2))"),
            //        quote_total = table.Column<decimal>(type: "money", nullable: false),
            //        purchase_id = table.Column<int>(type: "int", nullable: true),
            //        dealer_draft = table.Column<bool>(type: "bit", nullable: false),
            //        ship_as_parts = table.Column<bool>(type: "bit", nullable: false),
            //        dealer_customer_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        dealer_total = table.Column<decimal>(type: "money", nullable: false),
            //        @unchecked = table.Column<bool>(name: "unchecked", type: "bit", nullable: false, defaultValueSql: "((1))"),
            //        status_orderonly = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
            //        credit_order_id = table.Column<int>(type: "int", nullable: true),
            //        agent = table.Column<int>(type: "int", nullable: false),
            //        customer_gst = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((0.15))"),
            //        discount = table.Column<double>(type: "float", nullable: true),
            //        station_id = table.Column<int>(type: "int", nullable: true),
            //        order_deleted = table.Column<byte>(type: "tinyint", nullable: false),
            //        order_total = table.Column<decimal>(type: "money", nullable: false),
            //        total_charge = table.Column<decimal>(type: "money", nullable: false),
            //        total_discount = table.Column<decimal>(type: "money", nullable: false),
            //        total_special = table.Column<decimal>(type: "money", nullable: false),
            //        delivery_number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        online_processed = table.Column<bool>(type: "bit", nullable: false),
            //        cCardName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        cCardNum = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
            //        cCardType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        cRefCode = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
            //        cSuccess = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        cResponseTxt = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
            //        is_web_order = table.Column<bool>(type: "bit", nullable: false),
            //        web_order_status = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_orders", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "store_special",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        code = table.Column<int>(type: "int", nullable: false),
            //        branch_id = table.Column<int>(type: "int", nullable: false),
            //        enabled = table.Column<bool>(type: "bit", nullable: false),
            //        price = table.Column<decimal>(type: "money", nullable: false),
            //        price_start_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        price_end_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cost = table.Column<decimal>(type: "money", nullable: false),
            //        cost_start_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        cost_end_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_store_special", x => x.id);
            //    });

            migrationBuilder.CreateTable(
                name: "shipping_info",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    sender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sender_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sender_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sender_city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sender_country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receiver_company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receiver_address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receiver_address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receiver_address3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receiver_city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receiver_country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receiver_phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    receiver_contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipping_info", x => x.id);
                    table.ForeignKey(
                        name: "FK_shipping_info_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoice_freight_OrdersId",
                table: "invoice_freight",
                column: "OrdersId");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_order_item_code",
            //    table: "order_item",
            //    column: "code");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_order_item_id",
            //    table: "order_item",
            //    column: "id");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_order_item_kit",
            //    table: "order_item",
            //    column: "kit");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_order_item_krid",
            //    table: "order_item",
            //    column: "kid");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_order_item_supplier_code",
            //    table: "order_item",
            //    column: "supplier_code");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_orders_card_id",
            //    table: "orders",
            //    column: "card_id");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_orders_id",
            //    table: "orders",
            //    column: "id",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IDX_orders_invoice_number",
            //    table: "orders",
            //    column: "invoice_number");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_orders_sales",
            //    table: "orders",
            //    column: "sales");

            migrationBuilder.CreateIndex(
                name: "IX_shipping_info_order_id",
                table: "shipping_info",
                column: "order_id");

            migrationBuilder.AddForeignKey(
                name: "FK_invoice_freight_orders_OrdersId",
                table: "invoice_freight",
                column: "OrdersId",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invoice_freight_orders_OrdersId",
                table: "invoice_freight");

            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "shipping_info");

            migrationBuilder.DropTable(
                name: "store_special");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropIndex(
                name: "IX_invoice_freight_OrdersId",
                table: "invoice_freight");

            migrationBuilder.DropColumn(
                name: "OrdersId",
                table: "invoice_freight");
        }
    }
}
