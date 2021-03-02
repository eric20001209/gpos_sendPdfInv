using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace gpos_sendPdfInv.Entities
{
    public partial class admingposContext : DbContext
    {
        public admingposContext()
        {
        }

        public admingposContext(DbContextOptions<admingposContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barcode> Barcodes{ get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<CardAddress> CardAddress { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CodeBranch> CodeBranch { get; set; }
        public virtual DbSet<CodeRelations> CodeRelations { get; set; }
        public virtual DbSet<DpsOutput> DpsOutput { get; set; }
        public virtual DbSet<Enum> Enums { get; set; }
        public virtual DbSet<EcomBanner> EcomBanner { get; set; }
        public virtual DbSet<EcomSetting> EcomSetting { get; set; }
        public virtual DbSet<EcomTopMenu> EcomTopMenu { get; set; }
        public virtual DbSet<FreightSettings> FreightSettings { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceFreight> InvoiceFreights { get; set; }
        public virtual DbSet<InvoiceNote> InvoiceNotes { get; set; }
        public virtual DbSet<MessageBoard> MessageBoards { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ProductDetails> ProductDetails { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<ShippingInfo> ShippingInfo{ get; set; }
        public virtual DbSet<StockQty> StockQty{ get; set; }
        public virtual DbSet<SitePages> SitePages { get; set; }

        public virtual DbSet<StoreSpecial> StoreSpecial { get; set; }
        public virtual DbSet<Tran> Trans { get; set; }
        public virtual DbSet<TranDetail> TranDetails { get; set; }
        public virtual DbSet<TranInvoice> TranInvoices { get; set; }
        public virtual DbSet<TranDetail> TranDetail { get; set; }
        public virtual DbSet<Settings> Settings{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.1.239;Database=admingpos;User Id=eznz;password=9seqxtf7");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barcode>(entity =>
            {
                entity.ToTable("barcode");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Barcode1)
                    .IsRequired()
                    .HasColumnName("barcode")
                    .HasMaxLength(255);

                entity.Property(e => e.Bcancelled).HasColumnName("bcancelled");

                entity.Property(e => e.BoxQty).HasColumnName("box_qty");

                entity.Property(e => e.CancelledNote)
                    .HasColumnName("cancelled_note")
                    .HasMaxLength(502);

                entity.Property(e => e.CartonBarcode)
                    .HasColumnName("carton_barcode")
                    .HasMaxLength(255);

                entity.Property(e => e.CartonQty).HasColumnName("carton_qty");

                entity.Property(e => e.InvoiceNumber)
                    .HasColumnName("invoice_number")
                    .HasMaxLength(50);

                entity.Property(e => e.ItemCode).HasColumnName("item_code");

                entity.Property(e => e.ItemQty).HasColumnName("item_qty");

                entity.Property(e => e.PackagePrice)
                    .HasColumnName("package_price")
                    .HasColumnType("money");

                entity.Property(e => e.SupplierCode)
                    .HasColumnName("supplier_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VoucherAmount)
                    .HasColumnName("voucher_amount")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.VoucherCreated)
                    .HasColumnName("voucher_created")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);

                entity.ToTable("card");

                entity.HasIndex(e => e.DealerLevel, "IDX_card_dealer_level");

                entity.HasIndex(e => e.Email, "IDX_card_email")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "IDX_card_id")
                    .IsUnique()
                    .IsClustered();

                entity.HasIndex(e => e.Type, "IDX_card_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AcceptMassEmail).HasColumnName("accept_mass_email");

                entity.Property(e => e.AccessLevel)
                    .HasColumnName("access_level")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(255)
                    .HasColumnName("account_number");

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .HasColumnName("address1");

                entity.Property(e => e.Address1B)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address1B");

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .HasColumnName("address2");

                entity.Property(e => e.Address2B)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address2B");

                entity.Property(e => e.Address3)
                    .HasMaxLength(50)
                    .HasColumnName("address3");

                entity.Property(e => e.ApDdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ap_ddi");

                entity.Property(e => e.ApEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ap_email");

                entity.Property(e => e.ApMobile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ap_mobile");

                entity.Property(e => e.ApName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ap_name");

                entity.Property(e => e.Approved)
                    .HasColumnName("approved")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Area)
                    .HasMaxLength(50)
                    .HasColumnName("area");

                entity.Property(e => e.Balance)
                    .HasColumnType("money")
                    .HasColumnName("balance");

                entity.Property(e => e.BankName)
                    .HasMaxLength(255)
                    .HasColumnName("bank_name");

                entity.Property(e => e.Barcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("barcode");

                entity.Property(e => e.BranchCardId).HasColumnName("branch_card_id");

                entity.Property(e => e.BuyOnline).HasColumnName("buy_online");

                entity.Property(e => e.CatAccess)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("cat_access")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CatAccessGroup).HasColumnName("cat_access_group");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.CityB)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cityB");

                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .HasColumnName("company");

                entity.Property(e => e.CompanyB)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("companyB");

                entity.Property(e => e.Contact)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contact")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.CorpNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("corp_number");

                entity.Property(e => e.CorpRep)
                    .HasMaxLength(512)
                    .HasColumnName("corp_rep");

                entity.Property(e => e.CorpRepMobile)
                    .HasMaxLength(50)
                    .HasColumnName("corp_rep_mobile");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .HasColumnName("country")
                    .HasDefaultValueSql("('New Zealand')");

                entity.Property(e => e.CountryB)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("countryB")
                    .HasDefaultValueSql("('New Zealand')");

                entity.Property(e => e.CreditLimit)
                    .HasColumnType("money")
                    .HasColumnName("credit_limit");

                entity.Property(e => e.CreditTerm)
                    .HasColumnName("credit_term")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CurrencyForPurchase)
                    .HasColumnName("currency_for_purchase")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CustomerAccessLevel)
                    .HasColumnName("customer_access_level")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CustomerNumber)
                    .HasMaxLength(50)
                    .HasColumnName("customer_number");

                entity.Property(e => e.DdAccountNumber)
                    .HasMaxLength(255)
                    .HasColumnName("dd_account_number");

                entity.Property(e => e.DealerLevel)
                    .HasColumnName("dealer_level")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DefaultLanguage)
                    .HasMaxLength(255)
                    .HasColumnName("default_language");

                entity.Property(e => e.Directory)
                    .HasColumnName("directory")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("dob");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fax");

                entity.Property(e => e.Gm)
                    .HasMaxLength(255)
                    .HasColumnName("gm");

                entity.Property(e => e.GmMobile)
                    .HasMaxLength(50)
                    .HasColumnName("gm_mobile");

                entity.Property(e => e.GstNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gst_number");

                entity.Property(e => e.GstRate)
                    .HasColumnName("gst_rate")
                    .HasDefaultValueSql("((0.15))");

                entity.Property(e => e.IdentityId)
                    .HasMaxLength(50)
                    .HasColumnName("identity_id");

                entity.Property(e => e.InitialTerm)
                    .HasMaxLength(50)
                    .HasColumnName("initial_term");

                entity.Property(e => e.IsBranch).HasColumnName("is_branch");

                entity.Property(e => e.LastBranchId).HasColumnName("last_branch_id");

                entity.Property(e => e.LastPostTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_post_time")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.M1)
                    .HasColumnType("money")
                    .HasColumnName("m1");

                entity.Property(e => e.M10)
                    .HasColumnType("money")
                    .HasColumnName("m10");

                entity.Property(e => e.M11)
                    .HasColumnType("money")
                    .HasColumnName("m11");

                entity.Property(e => e.M12)
                    .HasColumnType("money")
                    .HasColumnName("m12");

                entity.Property(e => e.M2)
                    .HasColumnType("money")
                    .HasColumnName("m2");

                entity.Property(e => e.M3)
                    .HasColumnType("money")
                    .HasColumnName("m3");

                entity.Property(e => e.M4)
                    .HasColumnType("money")
                    .HasColumnName("m4");

                entity.Property(e => e.M5)
                    .HasColumnType("money")
                    .HasColumnName("m5");

                entity.Property(e => e.M6)
                    .HasColumnType("money")
                    .HasColumnName("m6");

                entity.Property(e => e.M7)
                    .HasColumnType("money")
                    .HasColumnName("m7");

                entity.Property(e => e.M8)
                    .HasColumnType("money")
                    .HasColumnName("m8");

                entity.Property(e => e.M9)
                    .HasColumnType("money")
                    .HasColumnName("m9");

                entity.Property(e => e.MainCardId).HasColumnName("main_card_id");

                entity.Property(e => e.Midname)
                    .HasMaxLength(128)
                    .HasColumnName("midname");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.NameB)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nameB");

                entity.Property(e => e.NoSysQuote).HasColumnName("no_sys_quote");

                entity.Property(e => e.Note)
                    .HasMaxLength(2500)
                    .HasColumnName("note");

                entity.Property(e => e.OurBranch)
                    .HasColumnName("our_branch")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PersonalId).HasColumnName("personal_id");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.PmDdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pm_ddi");

                entity.Property(e => e.PmEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pm_email");

                entity.Property(e => e.PmMobile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pm_mobile");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.Postal1)
                    .HasMaxLength(50)
                    .HasColumnName("postal1");

                entity.Property(e => e.Postal2)
                    .HasMaxLength(50)
                    .HasColumnName("postal2");

                entity.Property(e => e.Postal3)
                    .HasMaxLength(50)
                    .HasColumnName("postal3");

                entity.Property(e => e.PurchaseAverage)
                    .HasColumnType("money")
                    .HasColumnName("purchase_average");

                entity.Property(e => e.PurchaseNza)
                    .HasColumnType("money")
                    .HasColumnName("purchase_nza");

                entity.Property(e => e.Qq)
                    .HasMaxLength(50)
                    .HasColumnName("qq");

                entity.Property(e => e.RegCode)
                    .HasMaxLength(255)
                    .HasColumnName("reg_code");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("datetime")
                    .HasColumnName("register_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Registered)
                    .IsRequired()
                    .HasColumnName("registered")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ResetPwdCc)
                    .HasMaxLength(50)
                    .HasColumnName("reset_pwd_cc");

                entity.Property(e => e.RootPath)
                    .HasMaxLength(250)
                    .HasColumnName("root_path");

                entity.Property(e => e.Sales).HasColumnName("sales");

                entity.Property(e => e.ShippingFee)
                    .HasColumnType("money")
                    .HasColumnName("shipping_fee")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(50)
                    .HasColumnName("short_name");

                entity.Property(e => e.SitePass)
                    .HasMaxLength(250)
                    .HasColumnName("site_pass");

                entity.Property(e => e.SmDdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sm_ddi");

                entity.Property(e => e.SmEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sm_email");

                entity.Property(e => e.SmMobile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sm_mobile");

                entity.Property(e => e.SmName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sm_name");

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .HasColumnName("state");

                entity.Property(e => e.StopOrder).HasColumnName("stop_order");

                entity.Property(e => e.StopOrderReason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("stop_order_reason");

                entity.Property(e => e.Support).HasColumnName("support");

                entity.Property(e => e.SupportLevel).HasColumnName("support_level");

                entity.Property(e => e.Surname)
                    .HasMaxLength(128)
                    .HasColumnName("surname");

                entity.Property(e => e.TargetPoint).HasColumnName("target_point");

                entity.Property(e => e.TargetRental).HasColumnName("target_rental");

                entity.Property(e => e.TargetSales).HasColumnName("target_sales");

                entity.Property(e => e.TaxNumber)
                    .HasMaxLength(255)
                    .HasColumnName("tax_number");

                entity.Property(e => e.TechEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tech_email");

                entity.Property(e => e.Tills)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tills")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TotalOnlineOrderPoint)
                    .HasColumnName("total_online_order_point")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalPosts).HasColumnName("total_posts");

                entity.Property(e => e.TradingName)
                    .HasMaxLength(50)
                    .HasColumnName("trading_name");

                entity.Property(e => e.TransTotal)
                    .HasColumnType("money")
                    .HasColumnName("trans_total");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Url)
                    .HasMaxLength(250)
                    .HasColumnName("url");

                entity.Property(e => e.Web)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("web");

                entity.Property(e => e.WorkingOn)
                    .HasColumnName("working_on")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip");

            });
            modelBuilder.Entity<CardAddress>(entity =>
            {
                entity.ToTable("card_address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(250);

                entity.Property(e => e.Suburb)
  .HasColumnName("suburb")
  .HasMaxLength(250);
                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(250);
                entity.Property(e => e.Region)
  .HasColumnName("region")
  .HasMaxLength(50);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(50);

                entity.Property(e => e.Zip)
.HasColumnName("zip")
.HasMaxLength(50);

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(50);

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasMaxLength(50);

                entity.Property(e => e.IsDefault).HasColumnName("is_default");

                entity.Property(e => e.Mobile)
                    .HasColumnName("mobile")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);
            });
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiscountPercent)
                    .HasColumnName("discount_percent")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Kid)
                    .HasColumnName("kid")
                    .HasMaxLength(50);

                entity.Property(e => e.Kit)
                    .HasColumnName("kit")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(250);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(255);

                entity.Property(e => e.Pack)
                    .HasColumnName("pack")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Points)
                    .HasColumnName("points")
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SSerialNo)
                    .HasColumnName("s_serialNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SalesPrice)
                    .HasColumnName("salesPrice")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Site)
                    .HasColumnName("site")
                    .HasMaxLength(50);

                entity.Property(e => e.Supplier)
                    .HasColumnName("supplier")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierCode)
                    .HasColumnName("supplier_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierPrice)
                    .HasColumnName("supplierPrice")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.System)
                    .HasColumnName("system")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Used)
                    .HasColumnName("used")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<CodeBranch>(entity =>
            {
                entity.ToTable("code_branch");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchId)
                    .HasColumnName("branch_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.BranchLowStock)
                    .HasColumnName("branch_low_stock")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.BranchLowStockAdv)
                    .HasColumnName("branch_low_stock_adv")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Inactive).HasColumnName("inactive");

                entity.Property(e => e.LsaEndDate)
                    .HasColumnName("lsa_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LsaStartDate)
                    .HasColumnName("lsa_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Price1)
                    .HasColumnName("price1")
                    .HasColumnType("money");

                entity.Property(e => e.Price2)
                    .HasColumnName("price2")
                    .HasColumnType("money");

                entity.Property(e => e.QposQtyBreak).HasColumnName("qpos_qty_break");

                entity.Property(e => e.ShelfQty)
                    .HasColumnName("shelf_qty")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShelfQtyAdv).HasColumnName("shelf_qty_adv");

                entity.Property(e => e.Special).HasColumnName("special");

                entity.Property(e => e.SpecialPrice)
                    .HasColumnName("special_price")
                    .HasColumnType("money");

                entity.Property(e => e.SpecialPriceEndDate)
                    .HasColumnName("special_price_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SpecialPriceStartDate)
                    .HasColumnName("special_price_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SqaEndDate)
                    .HasColumnName("sqa_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SqaStartDate)
                    .HasColumnName("sqa_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.StockLocation)
                    .HasColumnName("stock_location")
                    .HasMaxLength(150);
            });
            modelBuilder.Entity<CodeRelations>(entity =>
            {
                entity.ToTable("code_relations");

                entity.HasIndex(e => e.Cat)
                    .HasName("IDX_code_relations_cat");

                entity.HasIndex(e => e.Clearance)
                    .HasName("IDX_code_relations_clearance");

                entity.HasIndex(e => e.Code)
                    .HasName("IDX_code_relations_code");

                entity.HasIndex(e => e.Id)
                    .HasName("IDX_code_relations_id");

                entity.HasIndex(e => e.SCat)
                    .HasName("IDX_code_relations_scat");

                entity.HasIndex(e => e.SsCat)
                    .HasName("IDX_code_relations_sscat");

                entity.HasIndex(e => e.SupplierCode)
                    .HasName("IDX_code_relations_spl_code");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AllocatedStock).HasColumnName("allocated_stock");

                entity.Property(e => e.AverageCost)
                    .HasColumnName("average_cost")
                    .HasColumnType("money");

                entity.Property(e => e.AvoidPoint).HasColumnName("avoid_point");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BestBefore)
                    .HasColumnName("best_before")
                    .HasMaxLength(50);

                entity.Property(e => e.BomId).HasColumnName("bom_id");

                entity.Property(e => e.BoxedQty)
                    .HasColumnName("boxed_qty")
                    .HasMaxLength(50);

                entity.Property(e => e.Brand)
                    .HasColumnName("brand")
                    .HasMaxLength(50);

                entity.Property(e => e.Cat)
                    .HasColumnName("cat")
                    .HasMaxLength(50);

                entity.Property(e => e.Clearance).HasColumnName("clearance");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.ComingSoon)
                    .HasColumnName("coming_soon")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CommissionRate).HasColumnName("commission_rate");

                entity.Property(e => e.CoreRange).HasColumnName("core_range");

                entity.Property(e => e.CostAccount).HasColumnName("cost_account");

                entity.Property(e => e.CostofsalesAccount)
                    .HasColumnName("costofsales_account")
                    .HasDefaultValueSql("((5111))");

                entity.Property(e => e.CountryOfOrigin)
                    .HasColumnName("country_of_origin")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasColumnName("currency")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DateRange).HasColumnName("date_range");

                entity.Property(e => e.Disappeared).HasColumnName("disappeared");

                entity.Property(e => e.DoNotRounddown).HasColumnName("do_not_rounddown");

                entity.Property(e => e.ExchangeRate).HasColumnName("exchange_rate");

                entity.Property(e => e.ExpireDate)
                    .HasColumnName("expire_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ForeignSupplierPrice)
                    .HasColumnName("foreign_supplier_price")
                    .HasColumnType("money");

                entity.Property(e => e.HasScale).HasColumnName("has_scale");

                entity.Property(e => e.Hidden).HasColumnName("hidden");

                entity.Property(e => e.Hot)
                    .HasColumnName("hot")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Inactive)
                    .HasColumnName("inactive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IncomeAccount).HasColumnName("income_account");

                entity.Property(e => e.InnerPack).HasColumnName("inner_pack");

                entity.Property(e => e.InventoryAccount).HasColumnName("inventory_account");

                entity.Property(e => e.IsBarcodeprice).HasColumnName("is_barcodeprice");

                entity.Property(e => e.IsIdCheck).HasColumnName("is_id_check");

                entity.Property(e => e.IsMemberOnly).HasColumnName("is_member_only");

                entity.Property(e => e.IsService).HasColumnName("is_service");

                entity.Property(e => e.IsSpecial).HasColumnName("is_special");

                entity.Property(e => e.IsVoidDiscount).HasColumnName("is_void_discount");

                entity.Property(e => e.IsWebsiteItem).HasColumnName("is_website_item");


                entity.Property(e => e.LevelPrice0)
                    .HasColumnName("level_price0")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice1)
                    .HasColumnName("level_price1")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice2)
                    .HasColumnName("level_price2")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice3)
                    .HasColumnName("level_price3")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice4)
                    .HasColumnName("level_price4")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice5)
                    .HasColumnName("level_price5")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice6)
                    .HasColumnName("level_price6")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice7)
                    .HasColumnName("level_price7")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice8)
                    .HasColumnName("level_price8")
                    .HasColumnType("money");

                entity.Property(e => e.LevelPrice9)
                    .HasColumnName("level_price9")
                    .HasColumnType("money");

                entity.Property(e => e.LevelRate1)
                    .HasColumnName("level_rate1")
                    .HasDefaultValueSql("((100))");

                entity.Property(e => e.LevelRate2)
                    .HasColumnName("level_rate2")
                    .HasDefaultValueSql("((95))");

                entity.Property(e => e.LevelRate3)
                    .HasColumnName("level_rate3")
                    .HasDefaultValueSql("((90))");

                entity.Property(e => e.LevelRate4)
                    .HasColumnName("level_rate4")
                    .HasDefaultValueSql("((85))");

                entity.Property(e => e.LevelRate5)
                    .HasColumnName("level_rate5")
                    .HasDefaultValueSql("((80))");

                entity.Property(e => e.LevelRate6)
                    .HasColumnName("level_rate6")
                    .HasDefaultValueSql("((78))");

                entity.Property(e => e.LevelRate7)
                    .HasColumnName("level_rate7")
                    .HasDefaultValueSql("((75))");

                entity.Property(e => e.LevelRate8)
                    .HasColumnName("level_rate8")
                    .HasDefaultValueSql("((73))");

                entity.Property(e => e.LevelRate9)
                    .HasColumnName("level_rate9")
                    .HasDefaultValueSql("((70))");

                entity.Property(e => e.Line1Font)
                    .HasColumnName("line1_font")
                    .HasDefaultValueSql("((9))");

                entity.Property(e => e.Line2Font)
                    .HasColumnName("line2_font")
                    .HasDefaultValueSql("((9))");

                entity.Property(e => e.LowStock).HasColumnName("low_stock");

                entity.Property(e => e.ManualCostFrd)
                    .HasColumnName("manual_cost_frd")
                    .HasColumnType("money");

                entity.Property(e => e.ManualCostNzd)
                    .HasColumnName("manual_cost_nzd")
                    .HasColumnType("money");

                entity.Property(e => e.ManualExchangeRate)
                    .HasColumnName("manual_exchange_rate")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Moq)
                    .HasColumnName("moq")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.NameCn)
                    .HasColumnName("name_cn")
                    .HasMaxLength(350);

                entity.Property(e => e.NewItem).HasColumnName("new_item");

                entity.Property(e => e.NewItemDate)
                    .HasColumnName("new_item_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.NoDiscount).HasColumnName("no_discount");

                entity.Property(e => e.NormalPrice).HasColumnName("normal_price");

                entity.Property(e => e.NzdFreight)
                    .HasColumnName("nzd_freight")
                    .HasColumnType("money");

                entity.Property(e => e.OuterPackBarcode)
                    .HasColumnName("outer_pack_barcode")
                    .HasMaxLength(99)
                    .IsUnicode(false);

                entity.Property(e => e.PackageBarcode1)
                    .HasColumnName("package_barcode1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PackageBarcode2)
                    .HasColumnName("package_barcode2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PackageBarcode3)
                    .HasColumnName("package_barcode3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PackagePrice1).HasColumnName("package_price1");

                entity.Property(e => e.PackagePrice2).HasColumnName("package_price2");

                entity.Property(e => e.PackagePrice3).HasColumnName("package_price3");

                entity.Property(e => e.PackageQty1).HasColumnName("package_qty1");

                entity.Property(e => e.PackageQty2).HasColumnName("package_qty2");

                entity.Property(e => e.PackageQty3).HasColumnName("package_qty3");

                entity.Property(e => e.PickDate).HasColumnName("pick_date");

                entity.Property(e => e.Popular)
                    .HasColumnName("popular")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Price1)
                    .HasColumnName("price1")
                    .HasColumnType("money");

                entity.Property(e => e.Price2)
                    .HasColumnName("price2")
                    .HasColumnType("money");

                entity.Property(e => e.Price3)
                    .HasColumnName("price3")
                    .HasColumnType("money");

                entity.Property(e => e.Price4)
                    .HasColumnName("price4")
                    .HasColumnType("money");

                entity.Property(e => e.Price5)
                    .HasColumnName("price5")
                    .HasColumnType("money");

                entity.Property(e => e.Price6)
                    .HasColumnName("price6")
                    .HasColumnType("money");

                entity.Property(e => e.Price7)
                    .HasColumnName("price7")
                    .HasColumnType("money");

                entity.Property(e => e.Price8)
                    .HasColumnName("price8")
                    .HasColumnType("money");

                entity.Property(e => e.Price9)
                    .HasColumnName("price9")
                    .HasColumnType("money");

                entity.Property(e => e.PriceSystem)
                    .HasColumnName("price_system")
                    .HasColumnType("money");

                entity.Property(e => e.PrintFormatCode).HasColumnName("print_format_code");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("product_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PromoId)
                    .HasColumnName("promo_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Promotion)
                    .HasColumnName("promotion")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QposQtyBreak).HasColumnName("qpos_qty_break");

                entity.Property(e => e.QtyBreak1)
                    .HasColumnName("qty_break1")
                    .HasDefaultValueSql("((5))");

                entity.Property(e => e.QtyBreak2)
                    .HasColumnName("qty_break2")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.QtyBreak3)
                    .HasColumnName("qty_break3")
                    .HasDefaultValueSql("((20))");

                entity.Property(e => e.QtyBreak4)
                    .HasColumnName("qty_break4")
                    .HasDefaultValueSql("((50))");

                entity.Property(e => e.QtyBreak5).HasColumnName("qty_break5");

                entity.Property(e => e.QtyBreak6).HasColumnName("qty_break6");

                entity.Property(e => e.QtyBreak7).HasColumnName("qty_break7");

                entity.Property(e => e.QtyBreak8).HasColumnName("qty_break8");

                entity.Property(e => e.QtyBreak9).HasColumnName("qty_break9");

                entity.Property(e => e.QtyBreakDiscount1).HasColumnName("qty_break_discount1");

                entity.Property(e => e.QtyBreakDiscount2).HasColumnName("qty_break_discount2");

                entity.Property(e => e.QtyBreakDiscount3).HasColumnName("qty_break_discount3");

                entity.Property(e => e.QtyBreakDiscount4).HasColumnName("qty_break_discount4");

                entity.Property(e => e.QtyBreakDiscount5).HasColumnName("qty_break_discount5");

                entity.Property(e => e.QtyBreakDiscount6).HasColumnName("qty_break_discount6");

                entity.Property(e => e.QtyBreakDiscount7).HasColumnName("qty_break_discount7");

                entity.Property(e => e.QtyBreakDiscount8).HasColumnName("qty_break_discount8");

                entity.Property(e => e.QtyBreakDiscount9).HasColumnName("qty_break_discount9");

                entity.Property(e => e.QtyBreakPrice1)
                    .HasColumnName("qty_break_price1")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice10)
                    .HasColumnName("qty_break_price10")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice2)
                    .HasColumnName("qty_break_price2")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice3)
                    .HasColumnName("qty_break_price3")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice4)
                    .HasColumnName("qty_break_price4")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice5)
                    .HasColumnName("qty_break_price5")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice6)
                    .HasColumnName("qty_break_price6")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice7)
                    .HasColumnName("qty_break_price7")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice8)
                    .HasColumnName("qty_break_price8")
                    .HasColumnType("money");

                entity.Property(e => e.QtyBreakPrice9)
                    .HasColumnName("qty_break_price9")
                    .HasColumnType("money");

                entity.Property(e => e.Rate)
                    .HasColumnName("rate")
                    .HasDefaultValueSql("((1.1))");

                entity.Property(e => e.RealStock).HasColumnName("real_stock");

                entity.Property(e => e.RedeemPoint).HasColumnName("redeem_point");

                entity.Property(e => e.RefCode)
                    .HasColumnName("ref_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rrp)
                    .HasColumnName("rrp")
                    .HasColumnType("money");

                entity.Property(e => e.SCat)
                    .HasColumnName("s_cat")
                    .HasMaxLength(50);

                entity.Property(e => e.ScaleDescriptionLine1)
                    .HasColumnName("scale_description_line1")
                    .HasMaxLength(50);

                entity.Property(e => e.ScaleDescriptionLine2)
                    .HasColumnName("scale_description_line2")
                    .HasMaxLength(50);

                entity.Property(e => e.SellBy)
                    .HasColumnName("sell_by")
                    .HasMaxLength(50);

                entity.Property(e => e.Skip).HasColumnName("skip");

                entity.Property(e => e.SkuCode)
                    .HasColumnName("sku_code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialCost)
                    .HasColumnName("special_cost")
                    .HasColumnType("money");

                entity.Property(e => e.SpecialCostEndDate)
                    .HasColumnName("special_cost_end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SpecialCostStartDate)
                    .HasColumnName("special_cost_start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.SpecialPrice)
                    .HasColumnName("special_price")
                    .HasColumnType("money");

                entity.Property(e => e.SpecialPriceEndDate)
                    .HasColumnName("special_price_end_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SpecialPriceStartDate)
                    .HasColumnName("special_price_start_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SsCat)
                    .HasColumnName("ss_cat")
                    .HasMaxLength(50);

                entity.Property(e => e.StockLocation)
                    .HasColumnName("stock_location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Supplier)
                    .HasColumnName("supplier")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierCode)
                    .HasColumnName("supplier_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierPrice)
                    .HasColumnName("supplier_price")
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Tareweight)
                    .HasColumnName("tareweight")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TaxCode)
                    .HasColumnName("tax_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxRate)
                    .HasColumnName("tax_rate")
                    .HasDefaultValueSql("((0.15))");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UsedBy)
                    .HasColumnName("used_by")
                    .HasMaxLength(50);

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<DpsOutput>(entity =>
            {
                entity.ToTable("DpsOutput");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Valid).HasColumnName("valid");
                entity.Property(e => e.AmountSettlement).HasColumnName("amount_settlement");
                entity.Property(e => e.AuthCode).HasColumnName("auth_code");
                entity.Property(e => e.CardName).HasColumnName("card_name");
                entity.Property(e => e.DateExpiry).HasColumnName("date_expiry");
                entity.Property(e => e.DpsTxnRef).HasColumnName("dps_txn_ref");
                entity.Property(e => e.Success).HasColumnName("success");
                entity.Property(e => e.ResponseText).HasColumnName("response_text");
                entity.Property(e => e.DpsBillingId).HasColumnName("dps_billing_id");
                entity.Property(e => e.CardHolderName).HasColumnName("card_holder_name");
                entity.Property(e => e.CurrencySettlement).HasColumnName("currency_settlement");
                entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");
                entity.Property(e => e.TxnData1).HasColumnName("txn_data1");
                entity.Property(e => e.TxnData2).HasColumnName("txn_data2");
                entity.Property(e => e.TxnData3).HasColumnName("txn_data3");
                entity.Property(e => e.TxnType).HasColumnName("txn_type");
                entity.Property(e => e.CurrencyInput).HasColumnName("currency_input");
                entity.Property(e => e.MerchantReference).HasColumnName("merchant_reference");
                entity.Property(e => e.ClientInfo).HasColumnName("client_info");
                entity.Property(e => e.TxnId).HasColumnName("txn_id");
                entity.Property(e => e.EmailAddress).HasColumnName("email_address");
                entity.Property(e => e.BillingId).HasColumnName("billing_id");
                entity.Property(e => e.TxnMac).HasColumnName("txn_mac");
                entity.Property(e => e.CardNumber2).HasColumnName("card_number2");
                entity.Property(e => e.Cvc2ResultCode).HasColumnName("cvc2_result_code");
                entity.Property(e => e.OrderId).HasColumnName("order_id").HasColumnType("int").HasDefaultValueSql("(0)");
                entity.Property(e => e.OrderSent).HasColumnName("order_sent").HasColumnType("bit").HasDefaultValueSql("(0)");
            });
            modelBuilder.Entity<Enum>(entity =>
            {
                entity.HasKey(e => new { e.Class, e.Id });

                entity.ToTable("enum");

                entity.HasIndex(e => e.Class, "IDX_enum_class");

                entity.HasIndex(e => e.Id, "IDX_enum_class_id");

                entity.HasIndex(e => e.Name, "IDX_enum_name");

                entity.Property(e => e.Class)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("class");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<FreightSettings>(entity =>
            {
                entity.HasKey(e => new { e.Id });
                entity.ToTable("freight_settings");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active").HasColumnType("bit").HasDefaultValue(true);
                entity.Property(e => e.Region).HasColumnName("region").IsUnicode(false);
                entity.Property(e => e.Freight).HasColumnName("freight").HasColumnType("money").HasDefaultValueSql("(0)");
                entity.Property(e => e.FreeshippingActiveAmount).HasColumnName("freeshipping_active_amount").HasColumnType("money").HasDefaultValueSql("(0)");
                entity.Property(e => e.FreightRangeStart1).HasColumnName("freight_range_start1").HasColumnType("money").HasDefaultValueSql("(0)");
                entity.Property(e => e.FreightRangeStart2).HasColumnName("freight_range_start2").HasColumnType("money").HasDefaultValueSql("(0)");
                entity.Property(e => e.FreightRangeStart3).HasColumnName("freight_range_start3").HasColumnType("money").HasDefaultValueSql("(0)");
                entity.Property(e => e.FreightRangeEnd1).HasColumnName("freight_range_end1").HasColumnType("money").HasDefaultValueSql("(0)");
                entity.Property(e => e.FreightRangeEnd2).HasColumnName("freight_range_end2").HasColumnType("money").HasDefaultValueSql("(0)");
                entity.Property(e => e.FreightRangeEnd3).HasColumnName("freight_range_end3").HasColumnType("money").HasDefaultValueSql("(0)");
            });
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address1");

                entity.Property(e => e.Address2)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address2");

                entity.Property(e => e.Address3)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address3");

                entity.Property(e => e.Agent).HasColumnName("agent");

                entity.Property(e => e.AmountPaid)
                    .HasColumnType("money")
                    .HasColumnName("amount_paid")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.Property(e => e.CommitDate)
                    .HasColumnType("datetime")
                    .HasColumnName("commit_date");

                entity.Property(e => e.Company)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("company");

                entity.Property(e => e.CustPonumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cust_ponumber");

                entity.Property(e => e.CustomerGst)
                    .HasColumnName("customer_gst")
                    .HasDefaultValueSql("((0.15))");

                entity.Property(e => e.DebugInfo)
                    .HasMaxLength(2048)
                    .IsUnicode(false)
                    .HasColumnName("debug_info");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fax");

                entity.Property(e => e.Freight)
                    .HasColumnType("money")
                    .HasColumnName("freight")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.GstInclusive).HasColumnName("gst_inclusive");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.NoIndividualPrice).HasColumnName("no_individual_price");

                entity.Property(e => e.Paid).HasColumnName("paid");

                entity.Property(e => e.PaymentType)
                    .HasColumnName("payment_type")
                    .HasDefaultValueSql("(2)");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.PickUpTime)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pick_up_time");

                entity.Property(e => e.Postal1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("postal1");

                entity.Property(e => e.Postal2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("postal2");

                entity.Property(e => e.Postal3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("postal3");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("record_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Refunded).HasColumnName("refunded");

                entity.Property(e => e.Sales)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sales");

                entity.Property(e => e.SalesNote)
                    .HasColumnType("text")
                    .HasColumnName("sales_note");

                entity.Property(e => e.SalesType)
                    .HasColumnName("sales_type")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.ShippingMethod)
                    .HasColumnName("shipping_method")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Shipto)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("shipto");

                entity.Property(e => e.SpecialShipto).HasColumnName("special_shipto");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.System).HasColumnName("system");

                entity.Property(e => e.Tax)
                    .HasColumnType("money")
                    .HasColumnName("tax");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("total");

                entity.Property(e => e.TradingName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("trading_name");

                entity.Property(e => e.TransFailedReason)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("trans_failed_reason");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("(3)");
            });
            modelBuilder.Entity<InvoiceFreight>(entity =>
            {
                entity.ToTable("invoice_freight");

                entity.HasIndex(e => e.InvoiceNumber, "IDX_invoice_freight_invoice_number");

                entity.HasIndex(e => e.Ticket, "IDX_invoice_freight_ticket");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.ShipDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ship_desc");

                entity.Property(e => e.ShipId).HasColumnName("ship_id");

                entity.Property(e => e.ShipName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ship_name");

                entity.Property(e => e.Ticket)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ticket");
            });
            modelBuilder.Entity<InvoiceNote>(entity =>
            {
                entity.ToTable("invoice_note");

                entity.HasIndex(e => e.InvoiceNumber, "IDX_invoice_note_invoice_number");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("notes");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("record_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");
            });
            modelBuilder.Entity<MessageBoard>(entity => {
                entity.ToTable("message_board");
                entity.HasKey(entity => entity.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name").IsUnicode(true);
                entity.Property(e => e.Subject).HasColumnName("subjuect").IsUnicode(true);
                entity.Property(e => e.Content).HasColumnName("content").IsUnicode(true);
                entity.Property(e => e.Email).HasColumnName("email").IsUnicode(true);
            });
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.Kid);

                entity.ToTable("order_item");

                entity.HasIndex(e => e.Code)
                    .HasName("IDX_order_item_code");

                entity.HasIndex(e => e.Id)
                    .HasName("IDX_order_item_id");

                entity.HasIndex(e => e.Kid)
                    .HasName("IDX_order_item_krid");

                entity.HasIndex(e => e.Kit)
                    .HasName("IDX_order_item_kit");

                entity.HasIndex(e => e.SupplierCode)
                    .HasName("IDX_order_item_supplier_code");

                entity.Property(e => e.Kid).HasColumnName("kid");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cat)
                    .HasColumnName("cat")
                    .HasMaxLength(150);

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CommitPrice)
                    .HasColumnName("commit_price")
                    .HasColumnType("money");

                entity.Property(e => e.DiscountPercent).HasColumnName("discount_percent");

                entity.Property(e => e.Eta)
                    .HasColumnName("eta")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemName)
                    .HasColumnName("item_name")
                    .HasMaxLength(500);

                entity.Property(e => e.ItemNameCn)
                    .HasColumnName("item_name_cn")
                    .HasMaxLength(150);

                entity.Property(e => e.Kit).HasColumnName("kit");

                entity.Property(e => e.Krid).HasColumnName("krid");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(255)
                    .IsUnicode(true);

                entity.Property(e => e.OrderTotal)
                    .HasColumnName("order_total")
                    .HasColumnType("money");

                entity.Property(e => e.Pack)
                    .HasColumnName("pack")
                    .HasMaxLength(100);

                entity.Property(e => e.Part)
                    .HasColumnName("part")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.PromoId).HasColumnName("promo_id");

                entity.Property(e => e.PromoName)
                    .HasColumnName("promo_name")
                    .HasMaxLength(128);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.QuantitySupplied).HasColumnName("quantity_supplied");

                entity.Property(e => e.SCat)
                    .HasColumnName("s_cat")
                    .HasMaxLength(150);

                entity.Property(e => e.SsCat)
                    .HasColumnName("ss_cat")
                    .HasMaxLength(150);

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.Supplier)
                    .IsRequired()
                    .HasColumnName("supplier")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierCode)
                    .IsRequired()
                    .HasColumnName("supplier_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierPrice)
                    .HasColumnName("supplier_price")
                    .HasColumnType("money");

                entity.Property(e => e.SysSpecial).HasColumnName("sys_special");

                entity.Property(e => e.System).HasColumnName("system");

                entity.Property(e => e.TaxCode)
                    .HasColumnName("tax_code")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TaxRate)
                    .HasColumnName("tax_rate")
                    .HasDefaultValueSql("((0))");
            });
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.CardId)
                    .HasName("IDX_orders_card_id");

                entity.HasIndex(e => e.Id)
                    .HasName("IDX_orders_id")
                    .IsUnique();

                entity.HasIndex(e => e.InvoiceNumber)
                    .HasName("IDX_orders_invoice_number");

                entity.HasIndex(e => e.Sales)
                    .HasName("IDX_orders_sales");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Agent).HasColumnName("agent");

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CCardName)
                    .HasColumnName("cCardName")
                    .HasMaxLength(150);

                entity.Property(e => e.CCardNum)
                    .HasColumnName("cCardNum")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CCardType)
                    .HasColumnName("cCardType")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CRefCode)
                    .HasColumnName("cRefCode")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CResponseTxt)
                    .HasColumnName("cResponseTxt")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CSuccess)
                    .HasColumnName("cSuccess")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreditOrderId).HasColumnName("credit_order_id");

                entity.Property(e => e.CustomerGst)
                    .HasColumnName("customer_gst")
                    .HasDefaultValueSql("((0.15))");

                entity.Property(e => e.DateShipped)
                    .HasColumnName("date_shipped")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DealerCustomerName)
                    .HasColumnName("dealer_customer_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DealerDraft).HasColumnName("dealer_draft");

                entity.Property(e => e.DealerTotal)
                    .HasColumnName("dealer_total")
                    .HasColumnType("money");

                entity.Property(e => e.DebugInfo)
                    .HasColumnName("debug_info")
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryNumber)
                    .HasColumnName("delivery_number")
                    .HasMaxLength(255);

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Freight)
                    .HasColumnName("freight")
                    .HasColumnType("money");

                entity.Property(e => e.GstInclusive).HasColumnName("gst_inclusive");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");

                entity.Property(e => e.IsWebOrder).HasColumnName("is_web_order");

                entity.Property(e => e.WebOrderStatus).HasColumnName("web_order_status");

                entity.Property(e => e.LockedBy).HasColumnName("locked_by");

                entity.Property(e => e.NoIndividualPrice).HasColumnName("no_individual_price");

                entity.Property(e => e.Number).HasColumnName("number");

                entity.Property(e => e.OnlineProcessed).HasColumnName("online_processed");

                entity.Property(e => e.OrderDeleted).HasColumnName("order_deleted");

                entity.Property(e => e.OrderTotal)
                    .HasColumnName("order_total")
                    .HasColumnType("money");

                entity.Property(e => e.Paid).HasColumnName("paid");

                entity.Property(e => e.Part).HasColumnName("part");

                entity.Property(e => e.PaymentType)
                    .HasColumnName("payment_type")
                    .HasDefaultValueSql("((3))");

                entity.Property(e => e.PickUpTime)
                    .HasColumnName("pick_up_time")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PoNumber)
                    .HasColumnName("po_number")
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.QuoteTotal)
                    .HasColumnName("quote_total")
                    .HasColumnType("money");

                entity.Property(e => e.RecordDate)
                    .HasColumnName("record_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Sales).HasColumnName("sales");

                entity.Property(e => e.SalesManager).HasColumnName("sales_manager");

                entity.Property(e => e.SalesNote)
                    .HasColumnName("sales_note")
                    .HasColumnType("ntext");

                entity.Property(e => e.ShipAsParts).HasColumnName("ship_as_parts");

                entity.Property(e => e.Shipby).HasColumnName("shipby");

                entity.Property(e => e.ShippingMethod)
                    .HasColumnName("shipping_method")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Shipto)
                    .HasColumnName("shipto")
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialShipto).HasColumnName("special_shipto");

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StatusOrderonly)
                    .HasColumnName("status_orderonly")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.System).HasColumnName("system");

                entity.Property(e => e.Ticket)
                    .HasColumnName("ticket")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TimeLocked)
                    .HasColumnName("time_locked")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalCharge)
                    .HasColumnName("total_charge")
                    .HasColumnType("money");

                entity.Property(e => e.TotalDiscount)
                    .HasColumnName("total_discount")
                    .HasColumnType("money");

                entity.Property(e => e.TotalSpecial)
                    .HasColumnName("total_special")
                    .HasColumnType("money");

                entity.Property(e => e.TransFailedReason)
                    .HasColumnName("trans_failed_reason")
                    .HasMaxLength(1024)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasDefaultValueSql("((2))");

                entity.Property(e => e.Unchecked)
                    .IsRequired()
                    .HasColumnName("unchecked")
                    .HasDefaultValueSql("((1))");
            });
            modelBuilder.Entity<ProductDetails>(entity => {
                entity.ToTable("product_details");
                entity.HasKey(entity => entity.Code);
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.Highlight).HasColumnName("highlight");
                entity.Property(e => e.Spec).HasColumnName("spec");
                entity.Property(e => e.Manufacture).HasColumnName("manufacture");
                entity.Property(e => e.Pic).HasColumnName("pic");
                entity.Property(e => e.Rev).HasColumnName("rev");
                entity.Property(e => e.Warranty).HasColumnName("warranty");
                entity.Property(e => e.Details).HasColumnName("details");
                entity.Property(e => e.Ingredients).HasColumnName("ingredients");
                entity.Property(e => e.Directions).HasColumnName("directions");
                entity.Property(e => e.Advice).HasColumnName("advice");
                entity.Property(e => e.Shipping).HasColumnName("shipping");
            });
            modelBuilder.Entity<SitePages>(entity =>
            {
                entity.ToTable("site_pages");

                entity.HasIndex(e => e.Id, "IDX_settings_id");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Cat).HasColumnName("cat");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Text).HasColumnName("text");
            });
            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sales");

                entity.HasIndex(e => e.Code, "IDX_sales_code");

                entity.HasIndex(e => e.InvoiceNumber, "IDX_sales_invoice_number");

                entity.HasIndex(e => e.Kit, "IDX_sales_kit");

                entity.HasIndex(e => e.Krid, "IDX_sales_krid");

                entity.HasIndex(e => e.Part, "IDX_sales_part");

                entity.HasIndex(e => e.Status, "IDX_sales_status");

                entity.HasIndex(e => e.System, "IDX_sales_system");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.CommitPrice)
                    .HasColumnType("money")
                    .HasColumnName("commit_price");

                entity.Property(e => e.CostofsalesAccount)
                    .HasColumnName("costofsales_account")
                    .HasDefaultValueSql("((5111))");

                entity.Property(e => e.DiscountPercent).HasColumnName("discount_percent");

                entity.Property(e => e.IncomeAccount)
                    .HasColumnName("income_account")
                    .HasDefaultValueSql("((4111))");

                entity.Property(e => e.InventoryAccount)
                    .HasColumnName("inventory_account")
                    .HasDefaultValueSql("((1121))");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");

                entity.Property(e => e.Kit).HasColumnName("kit");

                entity.Property(e => e.Krid).HasColumnName("krid");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name")
                    .HasComment("Chinese_PRC_BIN");

                entity.Property(e => e.NormalPrice)
                    .HasColumnType("money")
                    .HasColumnName("normal_price");

                entity.Property(e => e.Note)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.Owner).HasColumnName("owner");

                entity.Property(e => e.PStatus).HasColumnName("p_status");

                entity.Property(e => e.Part)
                    .HasColumnName("part")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.ProcessedBy).HasColumnName("processed_by");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SalesTotal)
                    .HasColumnType("money")
                    .HasColumnName("sales_total");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("serial_number");

                entity.Property(e => e.ShipDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ship_date");

                entity.Property(e => e.Shipby).HasColumnName("shipby");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StockAtSales).HasColumnName("stock_at_sales");

                entity.Property(e => e.Supplier)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("supplier");

                entity.Property(e => e.SupplierCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("supplier_code");

                entity.Property(e => e.SupplierPrice)
                    .HasColumnType("money")
                    .HasColumnName("supplier_price");

                entity.Property(e => e.SysSpecial).HasColumnName("sys_special");

                entity.Property(e => e.System).HasColumnName("system");

                entity.Property(e => e.Ticket)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ticket");

                entity.Property(e => e.SCat)
                    .HasColumnName("s_cat")
                    .HasMaxLength(150);

                entity.Property(e => e.SsCat)
                    .HasColumnName("ss_cat")
                    .HasMaxLength(150);

                entity.Property(e => e.Used).HasColumnName("used");
            });
            modelBuilder.Entity<Settings>(entity => {
                entity.ToTable("settings");
                entity.HasKey(c => c.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Cat).HasColumnName("cat");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Value).HasColumnName("value");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Hidden).HasColumnName("hidden");
                entity.Property(e => e.BoolValue).HasColumnName("bool_value");
                entity.Property(e => e.Access).HasColumnName("access");
            });
            modelBuilder.Entity<ShippingInfo>(entity =>
            {
                entity.ToTable("shipping_info");
                entity.HasKey(entity => entity.id);
                entity.Property(e => e.id).HasColumnName("id");
                entity.Property(e => e.orderId).HasColumnName("order_id");
                entity.Property(e => e.sender).HasColumnName("sender");
                entity.Property(e => e.sender_phone).HasColumnName("sender_phone");
                entity.Property(e => e.sender_address).HasColumnName("sender_address");
                entity.Property(e => e.sender_city).HasColumnName("sender_city");
                entity.Property(e => e.sender_country).HasColumnName("sender_country");
                entity.Property(e => e.receiver).HasColumnName("receiver");

                entity.Property(e => e.receiver_company).HasColumnName("receiver_company");
                entity.Property(e => e.receiver_address1).HasColumnName("receiver_address1");
                entity.Property(e => e.receiver_address2).HasColumnName("receiver_address2");
                entity.Property(e => e.receiver_address3).HasColumnName("receiver_address3");
                entity.Property(e => e.receiver_city).HasColumnName("receiver_city");
                entity.Property(e => e.receiver_country).HasColumnName("receiver_country");
                entity.Property(e => e.receiver_phone).HasColumnName("receiver_phone");
                entity.Property(e => e.zip).HasColumnName("zip");
                entity.Property(e => e.receiver_contact).HasColumnName("receiver_contact");
                entity.Property(e => e.note).HasColumnName("note");
            });
            modelBuilder.Entity<StoreSpecial>(entity =>
            {
                entity.ToTable("store_special");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BranchId).HasColumnName("branch_id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("money");

                entity.Property(e => e.CostEndDate)
                    .HasColumnName("cost_end_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CostStartDate)
                    .HasColumnName("cost_start_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.Property(e => e.PriceEndDate)
                    .HasColumnName("price_end_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PriceStartDate)
                    .HasColumnName("price_start_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });
            modelBuilder.Entity<StockQty>(entity =>
            {
                entity.ToTable("stock_qty");

                entity.HasIndex(e => e.BranchId)
                    .HasName("IDX_stock_qty_branch_id");

                entity.HasIndex(e => e.Code)
                    .HasName("IDX_stock_qty_code");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AllocatedStock)
                    .HasColumnName("allocated_stock")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.AverageCost)
                    .HasColumnName("average_cost")
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.BranchId)
                    .HasColumnName("branch_id")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.LastStock).HasColumnName("last_stock");

                entity.Property(e => e.QposPrice)
                    .HasColumnName("qpos_price")
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.SpEndDate)
                    .HasColumnName("sp_end_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SpStartDate)
                    .HasColumnName("sp_start_date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SpecialPrice)
                    .HasColumnName("special_price")
                    .HasColumnType("money");

                entity.Property(e => e.SupplierPrice)
                    .HasColumnName("supplier_price")
                    .HasColumnType("money")
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.WarningStock).HasColumnName("warning_stock");
            });
            modelBuilder.Entity<Tran>(entity =>
            {
                entity.ToTable("trans");

                entity.HasIndex(e => e.Banked, "IDX_trans_banked");

                entity.HasIndex(e => e.Branch, "IDX_trans_branch");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasColumnName("amount");

                entity.Property(e => e.Banked).HasColumnName("banked");

                entity.Property(e => e.Branch)
                    .HasColumnName("branch")
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Dest).HasColumnName("dest");

                entity.Property(e => e.DestAmount)
                    .HasColumnType("money")
                    .HasColumnName("dest_amount");

                entity.Property(e => e.Reconcile).HasColumnName("reconcile");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.TransBankId).HasColumnName("trans_bank_id");

                entity.Property(e => e.TransDate).HasColumnName("trans_date");
            });
            modelBuilder.Entity<EcomBanner>(entity =>
            {
                entity.ToTable("ecom_banner");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.PicUrl).HasColumnName("pic_url");
                entity.Property(e => e.HrefUrl).HasColumnName("href_url");
                entity.Property(e => e.Seq).HasColumnName("seq");
            });

            modelBuilder.Entity<EcomSetting>(entity =>
            {
                entity.ToTable("ecom_setting");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Value).HasColumnName("value");
                entity.Property(e => e.Active).HasColumnName("active").HasDefaultValueSql("(1)");
            });

            modelBuilder.Entity<EcomTopMenu>(entity =>
            {
                entity.ToTable("ecom_top_menu");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description).HasColumnName("description");
                entity.Property(e => e.Url).HasColumnName("url");
                entity.Property(e => e.Seq).HasColumnName("seq");
                entity.Property(e => e.Active).HasColumnName("active").HasDefaultValueSql("(1)");
            });

            modelBuilder.Entity<TranDetail>(entity =>
            {
                entity.HasKey(e => e.Kid);

                entity.ToTable("tran_detail");

                entity.HasIndex(e => e.CardId, "IDX_tran_detail_card_id");

                entity.HasIndex(e => e.Id, "IDX_tran_detail_id");

                entity.HasIndex(e => e.StaffId, "IX_tran_detail_staff_id");

                entity.Property(e => e.Kid).HasColumnName("kid");

                entity.Property(e => e.Bank)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bank");

                entity.Property(e => e.Branch)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("branch");

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.Property(e => e.Credit)
                    .HasColumnType("money")
                    .HasColumnName("credit");

                entity.Property(e => e.CreditId).HasColumnName("credit_id");

                entity.Property(e => e.CurrencyLoss)
                    .HasColumnType("money")
                    .HasColumnName("currency_loss");

                entity.Property(e => e.DestBalance)
                    .HasColumnType("money")
                    .HasColumnName("dest_balance");

                entity.Property(e => e.Finance)
                    .HasColumnType("money")
                    .HasColumnName("finance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(4096)
                    .IsUnicode(false)
                    .HasColumnName("invoice_number");

                entity.Property(e => e.Note)
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("note");

                entity.Property(e => e.PaidBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("paid_by");

                entity.Property(e => e.PaymentMethod).HasColumnName("payment_method");

                entity.Property(e => e.PaymentRef)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("payment_ref");

                entity.Property(e => e.SourceBalance)
                    .HasColumnType("money")
                    .HasColumnName("source_balance");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");

                entity.Property(e => e.TransDate)
                    .HasColumnType("datetime")
                    .HasColumnName("trans_date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<TranInvoice>(entity =>
            {
                entity.ToTable("tran_invoice");

                entity.HasIndex(e => e.Purchase, "IDX_tran_invoice_purchase");

                entity.HasIndex(e => e.TranId, "IDX_tran_invoice_tranid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AmountApplied)
                    .HasColumnType("money")
                    .HasColumnName("amount_applied");

                entity.Property(e => e.InvoiceNumber).HasColumnName("invoice_number");

                entity.Property(e => e.Purchase).HasColumnName("purchase");

                entity.Property(e => e.TranId).HasColumnName("tran_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
