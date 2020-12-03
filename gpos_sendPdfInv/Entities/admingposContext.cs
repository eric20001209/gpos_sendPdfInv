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

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Enum> Enums { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceFreight> InvoiceFreights { get; set; }
        public virtual DbSet<InvoiceNote> InvoiceNotes { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SitePages> SitePages { get; set; }
        public virtual DbSet<Tran> Trans { get; set; }
        public virtual DbSet<TranDetail> TranDetails { get; set; }
        public virtual DbSet<TranInvoice> TranInvoices { get; set; }

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

                entity.Property(e => e.Used).HasColumnName("used");
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
