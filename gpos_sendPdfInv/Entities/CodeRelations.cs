﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gpos_sendPdfInv.Entities
{
	public class CodeRelations
	{
        public string Id { get; set; }
        public int Code { get; set; }
        public string Supplier { get; set; }
        public string SupplierCode { get; set; }
        public decimal? SupplierPrice { get; set; }
        public decimal AverageCost { get; set; }
        public double Rate { get; set; }
        public string Name { get; set; }
        public string NameCn { get; set; }
        public string Brand { get; set; }
        public string Cat { get; set; }
        public string SCat { get; set; }
        public string SsCat { get; set; }
        public bool? Hot { get; set; }
        public bool Skip { get; set; }
        public bool Clearance { get; set; }
        public int? InventoryAccount { get; set; }
        public int? CostAccount { get; set; }
        public int? IncomeAccount { get; set; }
        public decimal? ForeignSupplierPrice { get; set; }
        public byte Currency { get; set; }
        public double? ExchangeRate { get; set; }
        public decimal NzdFreight { get; set; }
        public double LevelRate1 { get; set; }
        public double LevelRate2 { get; set; }
        public double LevelRate3 { get; set; }
        public double LevelRate4 { get; set; }
        public double LevelRate5 { get; set; }
        public double LevelRate6 { get; set; }
        public double? LevelRate7 { get; set; }
        public double? LevelRate8 { get; set; }
        public double? LevelRate9 { get; set; }
        public decimal LevelPrice0 { get; set; }
        public decimal LevelPrice1 { get; set; }
        public decimal LevelPrice2 { get; set; }
        public decimal LevelPrice3 { get; set; }
        public decimal LevelPrice4 { get; set; }
        public decimal LevelPrice5 { get; set; }
        public decimal LevelPrice6 { get; set; }
        public decimal LevelPrice7 { get; set; }
        public decimal LevelPrice8 { get; set; }
        public decimal LevelPrice9 { get; set; }
        public int QtyBreak1 { get; set; }
        public int? QtyBreak2 { get; set; }
        public int? QtyBreak3 { get; set; }
        public int? QtyBreak4 { get; set; }
        public int? QtyBreak5 { get; set; }
        public int? QtyBreak6 { get; set; }
        public int? QtyBreak7 { get; set; }
        public int? QtyBreak8 { get; set; }
        public int? QtyBreak9 { get; set; }
        public double QtyBreakDiscount1 { get; set; }
        public double? QtyBreakDiscount2 { get; set; }
        public double? QtyBreakDiscount3 { get; set; }
        public double? QtyBreakDiscount4 { get; set; }
        public double? QtyBreakDiscount5 { get; set; }
        public double? QtyBreakDiscount6 { get; set; }
        public double? QtyBreakDiscount7 { get; set; }
        public double? QtyBreakDiscount8 { get; set; }
        public double? QtyBreakDiscount9 { get; set; }
        public decimal? QtyBreakPrice1 { get; set; }
        public decimal? QtyBreakPrice2 { get; set; }
        public decimal? QtyBreakPrice3 { get; set; }
        public decimal? QtyBreakPrice4 { get; set; }
        public decimal? QtyBreakPrice5 { get; set; }
        public decimal? QtyBreakPrice6 { get; set; }
        public decimal? QtyBreakPrice7 { get; set; }
        public decimal? QtyBreakPrice8 { get; set; }
        public decimal? QtyBreakPrice9 { get; set; }
        public decimal? QtyBreakPrice10 { get; set; }
        public decimal ManualCostFrd { get; set; }
        public double ManualExchangeRate { get; set; }
        public decimal ManualCostNzd { get; set; }
        public int AllocatedStock { get; set; }
        public bool IsService { get; set; }
        public decimal Rrp { get; set; }
        public byte? Promotion { get; set; }
        public byte? ComingSoon { get; set; }
        public double? Weight { get; set; }
        public int? outer_pack { get; set; }
        public byte? Inactive { get; set; }
        public string StockLocation { get; set; }
        public bool? Popular { get; set; }
        public bool RealStock { get; set; }
        public int Disappeared { get; set; }
        public decimal Price1 { get; set; }
        public decimal Price2 { get; set; }
        public decimal Price3 { get; set; }
        public decimal Price4 { get; set; }
        public decimal Price5 { get; set; }
        public decimal Price6 { get; set; }
        public decimal Price7 { get; set; }
        public decimal Price8 { get; set; }
        public decimal Price9 { get; set; }
        public decimal PriceSystem { get; set; }
        public string Barcode { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string RefCode { get; set; }
        public int LowStock { get; set; }
        public string PackageBarcode1 { get; set; }
        public int? PackageQty1 { get; set; }
        public double? PackagePrice1 { get; set; }
        public string PackageBarcode2 { get; set; }
        public int? PackageQty2 { get; set; }
        public double? PackagePrice2 { get; set; }
        public string PackageBarcode3 { get; set; }
        public int? PackageQty3 { get; set; }
        public double? PackagePrice3 { get; set; }
        public double? NormalPrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public DateTime? SpecialPriceStartDate { get; set; }
        public DateTime? SpecialPriceEndDate { get; set; }
        public string SkuCode { get; set; }
        public int CostofsalesAccount { get; set; }
        public int QposQtyBreak { get; set; }
        public int? PromoId { get; set; }
        public bool HasScale { get; set; }
        public bool NewItem { get; set; }
        public DateTime? NewItemDate { get; set; }
        public bool IsSpecial { get; set; }
        public bool IsMemberOnly { get; set; }
        public bool DateRange { get; set; }
        public bool PickDate { get; set; }
        public bool AvoidPoint { get; set; }
        public int RedeemPoint { get; set; }
        public int? Moq { get; set; }
        public string BoxedQty { get; set; }
        public int InnerPack { get; set; }
        public bool Hidden { get; set; }
        public double CommissionRate { get; set; }
        public bool IsVoidDiscount { get; set; }
        public bool IsBarcodeprice { get; set; }
        public bool IsIdCheck { get; set; }
        public bool NoDiscount { get; set; }
        public double TaxRate { get; set; }
        public string TaxCode { get; set; }
        public int? BomId { get; set; }
        public int Unit { get; set; }
        public string BestBefore { get; set; }
        public string UsedBy { get; set; }
        public string SellBy { get; set; }
        public string ProductCode { get; set; }
        public int? Tareweight { get; set; }
        public string ScaleDescriptionLine1 { get; set; }
        public string ScaleDescriptionLine2 { get; set; }
        public int Line1Font { get; set; }
        public int Line2Font { get; set; }
        public int? PrintFormatCode { get; set; }
        public bool IsWebsiteItem { get; set; }
        public decimal? SpecialCost { get; set; }
        public DateTime? SpecialCostStartDate { get; set; }
        public DateTime? SpecialCostEndDate { get; set; }
        public bool DoNotRounddown { get; set; }
        public string OuterPackBarcode { get; set; }
        public string CountryOfOrigin { get; set; }
        public bool CoreRange { get; set; }
        public bool FreeDelivery { get; set; }
        public bool OnLineRetail { get; set; }
    }
}