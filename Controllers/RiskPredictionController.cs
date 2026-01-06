using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Uyen_LeThiPhuong_Lab5.Models;
using Uyen_LeThiPhuong_Lab5.Service;
using Uyen_LeThiPhuong_Lab5.Service;
namespace Uyen_LeThiPhuong_Lab5.Controllers
{
    public class RiskPredictionController : Controller
    {
        private readonly IRiskPredictionService _riskService;

        public RiskPredictionController(IRiskPredictionService riskService)
        {
            _riskService = riskService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new RiskPredictionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(RiskPredictionViewModel model)
        {
            // Tạo dữ liệu gửi đi
            var input = new RiskInput
            {
                InspectionType = model.InspectionType,
                ViolationDescription = model.ViolationDescription
            };

            // Gọi API lấy kết quả
            var prediction = await _riskService.PredictRiskAsync(input);

            // Gán kết quả để hiển thị
            model.PredictedRisk = prediction;

            return View(model);
        }
    }
}
