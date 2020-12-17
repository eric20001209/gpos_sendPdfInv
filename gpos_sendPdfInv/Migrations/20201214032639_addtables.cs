using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gpos_sendPdfInv.Migrations
{
    public partial class addtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "barcode",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        item_code = table.Column<int>(type: "int", nullable: false),
            //        barcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        item_qty = table.Column<double>(type: "float", nullable: false),
            //        carton_qty = table.Column<double>(type: "float", nullable: false),
            //        carton_barcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        box_qty = table.Column<double>(type: "float", nullable: false),
            //        package_price = table.Column<decimal>(type: "money", nullable: false),
            //        supplier_code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        invoice_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        voucher_amount = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
            //        bcancelled = table.Column<bool>(type: "bit", nullable: false),
            //        cancelled_note = table.Column<string>(type: "nvarchar(502)", maxLength: 502, nullable: true),
            //        voucher_created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_barcode", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "card",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        type = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
            //        name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        initial_term = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        short_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        trading_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        corp_number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        directory = table.Column<byte>(type: "tinyint", nullable: true, defaultValueSql: "((1))"),
            //        gst_number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        gst_rate = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((0.15))"),
            //        currency_for_purchase = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
            //        company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        address1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        address2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        address3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('New Zealand')"),
            //        phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        fax = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        contact = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "('')"),
            //        nameB = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        companyB = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        address1B = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        address2B = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        cityB = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        countryB = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "('New Zealand')"),
            //        postal1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        postal2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        postal3 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        register_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        shipping_fee = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "((10))"),
            //        accept_mass_email = table.Column<bool>(type: "bit", nullable: false),
            //        web = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        cat_access = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, defaultValueSql: "('')"),
            //        cat_access_group = table.Column<byte>(type: "tinyint", nullable: false),
            //        access_level = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
            //        dealer_level = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
            //        discount = table.Column<double>(type: "float", nullable: false),
            //        trans_total = table.Column<decimal>(type: "money", nullable: false),
            //        balance = table.Column<decimal>(type: "money", nullable: false),
            //        note = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
            //        last_branch_id = table.Column<int>(type: "int", nullable: true),
            //        last_post_time = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        total_posts = table.Column<int>(type: "int", nullable: false),
            //        pm_email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        pm_ddi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        pm_mobile = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        sm_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        sm_email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        sm_ddi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        sm_mobile = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        ap_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        ap_email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        ap_ddi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        ap_mobile = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        credit_term = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
            //        credit_limit = table.Column<decimal>(type: "money", nullable: false),
            //        approved = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
            //        purchase_nza = table.Column<decimal>(type: "money", nullable: false),
            //        purchase_average = table.Column<decimal>(type: "money", nullable: false),
            //        m1 = table.Column<decimal>(type: "money", nullable: false),
            //        m2 = table.Column<decimal>(type: "money", nullable: false),
            //        m3 = table.Column<decimal>(type: "money", nullable: false),
            //        m4 = table.Column<decimal>(type: "money", nullable: false),
            //        m5 = table.Column<decimal>(type: "money", nullable: false),
            //        m6 = table.Column<decimal>(type: "money", nullable: false),
            //        m7 = table.Column<decimal>(type: "money", nullable: false),
            //        m8 = table.Column<decimal>(type: "money", nullable: false),
            //        m9 = table.Column<decimal>(type: "money", nullable: false),
            //        m10 = table.Column<decimal>(type: "money", nullable: false),
            //        m11 = table.Column<decimal>(type: "money", nullable: false),
            //        m12 = table.Column<decimal>(type: "money", nullable: false),
            //        working_on = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
            //        buy_online = table.Column<bool>(type: "bit", nullable: false),
            //        main_card_id = table.Column<int>(type: "int", nullable: true),
            //        is_branch = table.Column<bool>(type: "bit", nullable: false),
            //        stop_order = table.Column<bool>(type: "bit", nullable: false),
            //        stop_order_reason = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        sales = table.Column<int>(type: "int", nullable: true),
            //        support = table.Column<int>(type: "int", nullable: true),
            //        customer_access_level = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
            //        branch_card_id = table.Column<int>(type: "int", nullable: true),
            //        no_sys_quote = table.Column<bool>(type: "bit", nullable: false),
            //        tech_email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        our_branch = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
            //        personal_id = table.Column<int>(type: "int", nullable: true),
            //        total_online_order_point = table.Column<long>(type: "bigint", nullable: true, defaultValueSql: "((0))"),
            //        registered = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
            //        barcode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        points = table.Column<int>(type: "int", nullable: false),
            //        site_pass = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        tills = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "((1))"),
            //        default_language = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        state = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        qq = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        reg_code = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        corp_rep = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
            //        corp_rep_mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        gm = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        gm_mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        identity_id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        customer_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        reset_pwd_cc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        dob = table.Column<DateTime>(type: "datetime", nullable: true),
            //        tax_number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        bank_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        account_number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        surname = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
            //        midname = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
            //        dd_account_number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
            //        url = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        root_path = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        support_level = table.Column<byte>(type: "tinyint", nullable: false),
            //        target_rental = table.Column<double>(type: "float", nullable: true),
            //        target_sales = table.Column<double>(type: "float", nullable: true),
            //        target_point = table.Column<double>(type: "float", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_card", x => x.id)
            //            .Annotation("SqlServer:Clustered", false);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "card_address",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        card_id = table.Column<int>(type: "int", nullable: false),
            //        company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        contact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        mobile = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        suburb = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        city = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
            //        region = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        zip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        is_default = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_card_address", x => x.id);
            //    });

            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    card_id = table.Column<int>(type: "int", nullable: false),
                    site = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    kid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    quantity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    system = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "((0))"),
                    kit = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "((0))"),
                    used = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true, defaultValueSql: "((0))"),
                    supplierPrice = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    salesPrice = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    supplier = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    supplier_code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    s_serialNo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    barcode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    points = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    discount_percent = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    pack = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.id);
                });

            //migrationBuilder.CreateTable(
            //    name: "code_branch",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        inactive = table.Column<bool>(type: "bit", nullable: false),
            //        code = table.Column<int>(type: "int", nullable: false),
            //        branch_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
            //        price1 = table.Column<decimal>(type: "money", nullable: true),
            //        price2 = table.Column<decimal>(type: "money", nullable: true),
            //        qpos_qty_break = table.Column<int>(type: "int", nullable: false),
            //        special = table.Column<bool>(type: "bit", nullable: false),
            //        special_price = table.Column<decimal>(type: "money", nullable: true),
            //        special_price_start_date = table.Column<DateTime>(type: "datetime", nullable: true),
            //        special_price_end_date = table.Column<DateTime>(type: "datetime", nullable: true),
            //        stock_location = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
            //        shelf_qty = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
            //        branch_low_stock = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((-1))"),
            //        shelf_qty_adv = table.Column<double>(type: "float", nullable: false),
            //        branch_low_stock_adv = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((-1))"),
            //        sqa_start_date = table.Column<DateTime>(type: "datetime", nullable: true),
            //        sqa_end_date = table.Column<DateTime>(type: "datetime", nullable: true),
            //        lsa_start_date = table.Column<DateTime>(type: "datetime", nullable: true),
            //        lsa_end_date = table.Column<DateTime>(type: "datetime", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_code_branch", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "code_relations",
            //    columns: table => new
            //    {
            //        id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        code = table.Column<int>(type: "int", nullable: false),
            //        supplier = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        supplier_code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        supplier_price = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "((0))"),
            //        average_cost = table.Column<decimal>(type: "money", nullable: false),
            //        rate = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((1.1))"),
            //        name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
            //        name_cn = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
            //        brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        cat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        s_cat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        ss_cat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        hot = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
            //        skip = table.Column<bool>(type: "bit", nullable: false),
            //        clearance = table.Column<bool>(type: "bit", nullable: false),
            //        inventory_account = table.Column<int>(type: "int", nullable: true),
            //        cost_account = table.Column<int>(type: "int", nullable: true),
            //        income_account = table.Column<int>(type: "int", nullable: true),
            //        foreign_supplier_price = table.Column<decimal>(type: "money", nullable: true),
            //        currency = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "((1))"),
            //        exchange_rate = table.Column<double>(type: "float", nullable: true),
            //        nzd_freight = table.Column<decimal>(type: "money", nullable: false),
            //        level_rate1 = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((100))"),
            //        level_rate2 = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((95))"),
            //        level_rate3 = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((90))"),
            //        level_rate4 = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((85))"),
            //        level_rate5 = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((80))"),
            //        level_rate6 = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((78))"),
            //        level_rate7 = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((75))"),
            //        level_rate8 = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((73))"),
            //        level_rate9 = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((70))"),
            //        level_price0 = table.Column<decimal>(type: "money", nullable: false),
            //        level_price1 = table.Column<decimal>(type: "money", nullable: false),
            //        level_price2 = table.Column<decimal>(type: "money", nullable: false),
            //        level_price3 = table.Column<decimal>(type: "money", nullable: false),
            //        level_price4 = table.Column<decimal>(type: "money", nullable: false),
            //        level_price5 = table.Column<decimal>(type: "money", nullable: false),
            //        level_price6 = table.Column<decimal>(type: "money", nullable: false),
            //        level_price7 = table.Column<decimal>(type: "money", nullable: false),
            //        level_price8 = table.Column<decimal>(type: "money", nullable: false),
            //        level_price9 = table.Column<decimal>(type: "money", nullable: false),
            //        qty_break1 = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((5))"),
            //        qty_break2 = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((10))"),
            //        qty_break3 = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((20))"),
            //        qty_break4 = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((50))"),
            //        qty_break5 = table.Column<int>(type: "int", nullable: true),
            //        qty_break6 = table.Column<int>(type: "int", nullable: true),
            //        qty_break7 = table.Column<int>(type: "int", nullable: true),
            //        qty_break8 = table.Column<int>(type: "int", nullable: true),
            //        qty_break9 = table.Column<int>(type: "int", nullable: true),
            //        qty_break_discount1 = table.Column<double>(type: "float", nullable: false),
            //        qty_break_discount2 = table.Column<double>(type: "float", nullable: true),
            //        qty_break_discount3 = table.Column<double>(type: "float", nullable: true),
            //        qty_break_discount4 = table.Column<double>(type: "float", nullable: true),
            //        qty_break_discount5 = table.Column<double>(type: "float", nullable: true),
            //        qty_break_discount6 = table.Column<double>(type: "float", nullable: true),
            //        qty_break_discount7 = table.Column<double>(type: "float", nullable: true),
            //        qty_break_discount8 = table.Column<double>(type: "float", nullable: true),
            //        qty_break_discount9 = table.Column<double>(type: "float", nullable: true),
            //        qty_break_price1 = table.Column<decimal>(type: "money", nullable: true),
            //        qty_break_price2 = table.Column<decimal>(type: "money", nullable: true),
            //        qty_break_price3 = table.Column<decimal>(type: "money", nullable: true),
            //        qty_break_price4 = table.Column<decimal>(type: "money", nullable: true),
            //        qty_break_price5 = table.Column<decimal>(type: "money", nullable: true),
            //        qty_break_price6 = table.Column<decimal>(type: "money", nullable: true),
            //        qty_break_price7 = table.Column<decimal>(type: "money", nullable: true),
            //        qty_break_price8 = table.Column<decimal>(type: "money", nullable: true),
            //        qty_break_price9 = table.Column<decimal>(type: "money", nullable: true),
            //        qty_break_price10 = table.Column<decimal>(type: "money", nullable: true),
            //        manual_cost_frd = table.Column<decimal>(type: "money", nullable: false),
            //        manual_exchange_rate = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((1))"),
            //        manual_cost_nzd = table.Column<decimal>(type: "money", nullable: false),
            //        allocated_stock = table.Column<int>(type: "int", nullable: false),
            //        is_service = table.Column<bool>(type: "bit", nullable: false),
            //        rrp = table.Column<decimal>(type: "money", nullable: false),
            //        promotion = table.Column<byte>(type: "tinyint", nullable: true, defaultValueSql: "((0))"),
            //        coming_soon = table.Column<byte>(type: "tinyint", nullable: true, defaultValueSql: "((0))"),
            //        weight = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
            //        outer_pack = table.Column<int>(type: "int", nullable: true),
            //        inactive = table.Column<byte>(type: "tinyint", nullable: true, defaultValueSql: "((0))"),
            //        stock_location = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        popular = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
            //        real_stock = table.Column<bool>(type: "bit", nullable: false),
            //        disappeared = table.Column<int>(type: "int", nullable: false),
            //        price1 = table.Column<decimal>(type: "money", nullable: false),
            //        price2 = table.Column<decimal>(type: "money", nullable: false),
            //        price3 = table.Column<decimal>(type: "money", nullable: false),
            //        price4 = table.Column<decimal>(type: "money", nullable: false),
            //        price5 = table.Column<decimal>(type: "money", nullable: false),
            //        price6 = table.Column<decimal>(type: "money", nullable: false),
            //        price7 = table.Column<decimal>(type: "money", nullable: false),
            //        price8 = table.Column<decimal>(type: "money", nullable: false),
            //        price9 = table.Column<decimal>(type: "money", nullable: false),
            //        price_system = table.Column<decimal>(type: "money", nullable: false),
            //        barcode = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        expire_date = table.Column<DateTime>(type: "datetime", nullable: true),
            //        ref_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        low_stock = table.Column<int>(type: "int", nullable: false),
            //        package_barcode1 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        package_qty1 = table.Column<int>(type: "int", nullable: true),
            //        package_price1 = table.Column<double>(type: "float", nullable: true),
            //        package_barcode2 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        package_qty2 = table.Column<int>(type: "int", nullable: true),
            //        package_price2 = table.Column<double>(type: "float", nullable: true),
            //        package_barcode3 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        package_qty3 = table.Column<int>(type: "int", nullable: true),
            //        package_price3 = table.Column<double>(type: "float", nullable: true),
            //        normal_price = table.Column<double>(type: "float", nullable: true),
            //        special_price = table.Column<decimal>(type: "money", nullable: true),
            //        special_price_start_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        special_price_end_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        sku_code = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        costofsales_account = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((5111))"),
            //        qpos_qty_break = table.Column<int>(type: "int", nullable: false),
            //        promo_id = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
            //        has_scale = table.Column<bool>(type: "bit", nullable: false),
            //        new_item = table.Column<bool>(type: "bit", nullable: false),
            //        new_item_date = table.Column<DateTime>(type: "datetime", nullable: true),
            //        is_special = table.Column<bool>(type: "bit", nullable: false),
            //        is_member_only = table.Column<bool>(type: "bit", nullable: false),
            //        date_range = table.Column<bool>(type: "bit", nullable: false),
            //        pick_date = table.Column<bool>(type: "bit", nullable: false),
            //        avoid_point = table.Column<bool>(type: "bit", nullable: false),
            //        redeem_point = table.Column<int>(type: "int", nullable: false),
            //        moq = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))"),
            //        boxed_qty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        inner_pack = table.Column<int>(type: "int", nullable: false),
            //        hidden = table.Column<bool>(type: "bit", nullable: false),
            //        commission_rate = table.Column<double>(type: "float", nullable: false),
            //        is_void_discount = table.Column<bool>(type: "bit", nullable: false),
            //        is_barcodeprice = table.Column<bool>(type: "bit", nullable: false),
            //        is_id_check = table.Column<bool>(type: "bit", nullable: false),
            //        no_discount = table.Column<bool>(type: "bit", nullable: false),
            //        tax_rate = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((0.15))"),
            //        tax_code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        bom_id = table.Column<int>(type: "int", nullable: true),
            //        unit = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
            //        best_before = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        used_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        sell_by = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        product_code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        tareweight = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
            //        scale_description_line1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        scale_description_line2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //        line1_font = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((9))"),
            //        line2_font = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((9))"),
            //        print_format_code = table.Column<int>(type: "int", nullable: true),
            //        is_website_item = table.Column<bool>(type: "bit", nullable: false),
            //        special_cost = table.Column<decimal>(type: "money", nullable: true),
            //        special_cost_start_date = table.Column<DateTime>(type: "datetime", nullable: true),
            //        special_cost_end_date = table.Column<DateTime>(type: "datetime", nullable: true),
            //        do_not_rounddown = table.Column<bool>(type: "bit", nullable: false),
            //        outer_pack_barcode = table.Column<string>(type: "varchar(99)", unicode: false, maxLength: 99, nullable: true),
            //        country_of_origin = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
            //        core_range = table.Column<bool>(type: "bit", nullable: false),
            //        FreeDelivery = table.Column<bool>(type: "bit", nullable: false),
            //        OnLineRetail = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_code_relations", x => x.id);
            //    });

            migrationBuilder.CreateTable(
                name: "DpsOutput",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    amount_settlement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    auth_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date_expiry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dps_txn_ref = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    success = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    response_text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dps_billing_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_holder_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currency_settlement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    payment_method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txn_data1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txn_data2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txn_data3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txn_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currency_input = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    merchant_reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    client_info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txn_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email_address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    billing_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    txn_mac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    card_number2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cvc2_result_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(0)"),
                    order_sent = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DpsOutput", x => x.id);
                });

            //migrationBuilder.CreateTable(
            //    name: "enum",
            //    columns: table => new
            //    {
            //        @class = table.Column<string>(name: "class", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        id = table.Column<int>(type: "int", nullable: false),
            //        name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_enum", x => new { x.@class, x.id });
            //    });

            migrationBuilder.CreateTable(
                name: "freight_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    active = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    region = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    freight = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "(0)"),
                    freeshipping_active_amount = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "(0)"),
                    freight_range_start1 = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "(0)"),
                    freight_range_start2 = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "(0)"),
                    freight_range_start3 = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "(0)"),
                    freight_range_end1 = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "(0)"),
                    freight_range_end2 = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "(0)"),
                    freight_range_end3 = table.Column<decimal>(type: "money", nullable: false, defaultValueSql: "(0)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_freight_settings", x => x.id);
                });

            //migrationBuilder.CreateTable(
            //    name: "invoice",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        invoice_number = table.Column<int>(type: "int", nullable: false),
            //        branch = table.Column<int>(type: "int", nullable: true, defaultValueSql: "(1)"),
            //        type = table.Column<byte>(type: "tinyint", nullable: true, defaultValueSql: "(3)"),
            //        sales_type = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "(1)"),
            //        card_id = table.Column<int>(type: "int", nullable: false),
            //        special_shipto = table.Column<bool>(type: "bit", nullable: false),
            //        shipto = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
            //        price = table.Column<decimal>(type: "money", nullable: true),
            //        tax = table.Column<decimal>(type: "money", nullable: true),
            //        freight = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "(0)"),
            //        total = table.Column<decimal>(type: "money", nullable: true),
            //        commit_date = table.Column<DateTime>(type: "datetime", nullable: false),
            //        payment_type = table.Column<byte>(type: "tinyint", nullable: true, defaultValueSql: "(2)"),
            //        paid = table.Column<bool>(type: "bit", nullable: false),
            //        refunded = table.Column<bool>(type: "bit", nullable: false),
            //        amount_paid = table.Column<decimal>(type: "money", nullable: true, defaultValueSql: "(0)"),
            //        trans_failed_reason = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
            //        system = table.Column<bool>(type: "bit", nullable: false),
            //        sales = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        debug_info = table.Column<string>(type: "varchar(2048)", unicode: false, maxLength: 2048, nullable: true),
            //        no_individual_price = table.Column<bool>(type: "bit", nullable: false),
            //        gst_inclusive = table.Column<bool>(type: "bit", nullable: false),
            //        status = table.Column<int>(type: "int", nullable: false, defaultValueSql: "(1)"),
            //        cust_ponumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        sales_note = table.Column<string>(type: "text", nullable: true),
            //        shipping_method = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "(1)"),
            //        pick_up_time = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        company = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        trading_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        address1 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        address2 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        address3 = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
            //        postal1 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        postal2 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        postal3 = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        fax = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        agent = table.Column<int>(type: "int", nullable: false),
            //        record_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        customer_gst = table.Column<double>(type: "float", nullable: false, defaultValueSql: "((0.15))")
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_invoice", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "invoice_freight",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        invoice_number = table.Column<int>(type: "int", nullable: false),
            //        ship_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        ship_desc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        ticket = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        price = table.Column<decimal>(type: "money", nullable: false),
            //        ship_id = table.Column<int>(type: "int", nullable: true)
            //    },

            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_invoice_freight", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "invoice_note",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        invoice_number = table.Column<int>(type: "int", nullable: false),
            //        notes = table.Column<string>(type: "text", nullable: false),
            //        record_date = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
            //        staff_id = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_invoice_note", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "sales",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        invoice_number = table.Column<int>(type: "int", nullable: false),
            //        code = table.Column<int>(type: "int", nullable: false),
            //        quantity = table.Column<double>(type: "float", nullable: false),
            //        name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true, comment: "Chinese_PRC_BIN"),
            //        supplier = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        supplier_code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        serial_number = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        commit_price = table.Column<decimal>(type: "money", nullable: false),
            //        supplier_price = table.Column<decimal>(type: "money", nullable: false),
            //        status = table.Column<byte>(type: "tinyint", nullable: true),
            //        shipby = table.Column<byte>(type: "tinyint", nullable: true),
            //        ticket = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        note = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
            //        ship_date = table.Column<DateTime>(type: "datetime", nullable: true),
            //        processed_by = table.Column<int>(type: "int", nullable: true),
            //        system = table.Column<bool>(type: "bit", nullable: false),
            //        sys_special = table.Column<bool>(type: "bit", nullable: false),
            //        part = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((-1))"),
            //        p_status = table.Column<byte>(type: "tinyint", nullable: true),
            //        owner = table.Column<int>(type: "int", nullable: true),
            //        used = table.Column<bool>(type: "bit", nullable: false),
            //        stock_at_sales = table.Column<int>(type: "int", nullable: true),
            //        kit = table.Column<bool>(type: "bit", nullable: false),
            //        krid = table.Column<int>(type: "int", nullable: true),
            //        normal_price = table.Column<decimal>(type: "money", nullable: false),
            //        income_account = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((4111))"),
            //        costofsales_account = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((5111))"),
            //        inventory_account = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1121))"),
            //        discount_percent = table.Column<double>(type: "float", nullable: false),
            //        sales_total = table.Column<decimal>(type: "money", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_sales", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "site_pages",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        name = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        text = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        cat = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_site_pages", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tran_detail",
            //    columns: table => new
            //    {
            //        kid = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        id = table.Column<int>(type: "int", nullable: false),
            //        invoice_number = table.Column<string>(type: "varchar(4096)", unicode: false, maxLength: 4096, nullable: true),
            //        source_balance = table.Column<decimal>(type: "money", nullable: true),
            //        dest_balance = table.Column<decimal>(type: "money", nullable: true),
            //        trans_date = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
            //        staff_id = table.Column<int>(type: "int", nullable: true),
            //        card_id = table.Column<int>(type: "int", nullable: true),
            //        note = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
            //        payment_method = table.Column<int>(type: "int", nullable: true),
            //        payment_ref = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        finance = table.Column<decimal>(type: "money", nullable: false),
            //        currency_loss = table.Column<decimal>(type: "money", nullable: false),
            //        credit = table.Column<decimal>(type: "money", nullable: false),
            //        paid_by = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        bank = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        branch = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
            //        credit_id = table.Column<int>(type: "int", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tran_detail", x => x.kid);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "tran_invoice",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        tran_id = table.Column<int>(type: "int", nullable: false),
            //        invoice_number = table.Column<int>(type: "int", nullable: false),
            //        amount_applied = table.Column<decimal>(type: "money", nullable: false),
            //        purchase = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_tran_invoice", x => x.id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "trans",
            //    columns: table => new
            //    {
            //        id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        source = table.Column<int>(type: "int", nullable: true),
            //        dest = table.Column<int>(type: "int", nullable: true),
            //        amount = table.Column<decimal>(type: "money", nullable: false),
            //        dest_amount = table.Column<decimal>(type: "money", nullable: true),
            //        banked = table.Column<bool>(type: "bit", nullable: false),
            //        trans_bank_id = table.Column<int>(type: "int", nullable: true),
            //        trans_date = table.Column<int>(type: "int", nullable: true),
            //        branch = table.Column<byte>(type: "tinyint", nullable: false, defaultValueSql: "(1)"),
            //        reconcile = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_trans", x => x.id);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IDX_card_dealer_level",
            //    table: "card",
            //    column: "dealer_level");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_card_email",
            //    table: "card",
            //    column: "email",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IDX_card_id",
            //    table: "card",
            //    column: "id",
            //    unique: true)
            //    .Annotation("SqlServer:Clustered", true);

            //migrationBuilder.CreateIndex(
            //    name: "IDX_card_type",
            //    table: "card",
            //    column: "type");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_code_relations_cat",
            //    table: "code_relations",
            //    column: "cat");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_code_relations_clearance",
            //    table: "code_relations",
            //    column: "clearance");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_code_relations_code",
            //    table: "code_relations",
            //    column: "code");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_code_relations_id",
            //    table: "code_relations",
            //    column: "id");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_code_relations_scat",
            //    table: "code_relations",
            //    column: "s_cat");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_code_relations_spl_code",
            //    table: "code_relations",
            //    column: "supplier_code");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_code_relations_sscat",
            //    table: "code_relations",
            //    column: "ss_cat");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_enum_class",
            //    table: "enum",
            //    column: "class");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_enum_class_id",
            //    table: "enum",
            //    column: "id");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_enum_name",
            //    table: "enum",
            //    column: "name");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_invoice_freight_invoice_number",
            //    table: "invoice_freight",
            //    column: "invoice_number");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_invoice_freight_ticket",
            //    table: "invoice_freight",
            //    column: "ticket");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_invoice_note_invoice_number",
            //    table: "invoice_note",
            //    column: "invoice_number");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_sales_code",
            //    table: "sales",
            //    column: "code");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_sales_invoice_number",
            //    table: "sales",
            //    column: "invoice_number");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_sales_kit",
            //    table: "sales",
            //    column: "kit");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_sales_krid",
            //    table: "sales",
            //    column: "krid");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_sales_part",
            //    table: "sales",
            //    column: "part");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_sales_status",
            //    table: "sales",
            //    column: "status");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_sales_system",
            //    table: "sales",
            //    column: "system");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_settings_id",
            //    table: "site_pages",
            //    column: "id");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_tran_detail_card_id",
            //    table: "tran_detail",
            //    column: "card_id");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_tran_detail_id",
            //    table: "tran_detail",
            //    column: "id");

            //migrationBuilder.CreateIndex(
            //    name: "IX_tran_detail_staff_id",
            //    table: "tran_detail",
            //    column: "staff_id");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_tran_invoice_purchase",
            //    table: "tran_invoice",
            //    column: "purchase");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_tran_invoice_tranid",
            //    table: "tran_invoice",
            //    column: "tran_id");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_trans_banked",
            //    table: "trans",
            //    column: "banked");

            //migrationBuilder.CreateIndex(
            //    name: "IDX_trans_branch",
            //    table: "trans",
            //    column: "branch");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "barcode");

            migrationBuilder.DropTable(
                name: "card");

            migrationBuilder.DropTable(
                name: "card_address");

            migrationBuilder.DropTable(
                name: "cart");

            migrationBuilder.DropTable(
                name: "code_branch");

            migrationBuilder.DropTable(
                name: "code_relations");

            migrationBuilder.DropTable(
                name: "DpsOutput");

            migrationBuilder.DropTable(
                name: "enum");

            migrationBuilder.DropTable(
                name: "freight_settings");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "invoice_freight");

            migrationBuilder.DropTable(
                name: "invoice_note");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "site_pages");

            migrationBuilder.DropTable(
                name: "tran_detail");

            migrationBuilder.DropTable(
                name: "tran_invoice");

            migrationBuilder.DropTable(
                name: "trans");
        }
    }
}
