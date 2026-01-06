
using System.Threading.Tasks;
using Uyen_LeThiPhuong_Lab5.Models;

namespace Uyen_LeThiPhuong_Lab5.Service
{
    public interface IRiskPredictionService
    {
        Task<string> PredictRiskAsync(RiskInput input);
    }
}
