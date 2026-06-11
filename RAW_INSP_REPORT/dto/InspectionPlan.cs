namespace SAP.Report.dto
{
    public class InspectionPlan
    {
        public string TaskGroup { get; set; } = String.Empty;
        public string GroupCounter { get; set; } = String.Empty;
        public string Material { get; set; } = String.Empty;
        public string MaterialDesc { get; set; } = String.Empty;
        public string Vendor { get; set; } = String.Empty;
        public string VendorName { get; set; } = String.Empty;
        public string WorkCenter { get; set; } = String.Empty;
        public string WorkCenterDesc { get; set; } = String.Empty;
        public string Plant { get; set; } = String.Empty;
        public string PlantName { get; set; } = String.Empty;
        public string TradeMode { get; set; } = String.Empty;
        public string TradeModeDesc { get; set; } = String.Empty;

        public List<InspectionCharacteristic>? InspChars { get; set; }

    }

    public class InspectionCharacteristic
    {
        public string ItemId { get; set; } = String.Empty;
        public bool QuantitativeInd { get; set; }
        public string MstrChar { get; set; } = String.Empty;
        public string CharDescr { get; set; } = String.Empty;
        public int DecPlaces { get; set; }
        public string MeasUnit { get; set; } = String.Empty;
        public string UpTolLmt { get; set; } = String.Empty;

        public string LwTolLmt { get; set; } = String.Empty;
        public string CategoryName { get; set; } = String.Empty;
        public string TargetValue { get; set; } = String.Empty;
        public string QualitativeAddTxt { get; set; } = String.Empty;
    }
}
