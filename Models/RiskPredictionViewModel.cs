namespace Uyen_LeThiPhuong_Lab5.Models
{
    public class RiskPredictionViewModel
    {
        public string InspectionType { get; set; }
        public string ViolationDescription { get; set; }
        // Kết quả trả về từ API
        public string PredictedRisk { get; set; }
    }
}
