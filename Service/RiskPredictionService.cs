using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Uyen_LeThiPhuong_Lab5.Models;

namespace Uyen_LeThiPhuong_Lab5.Service
{
    public class RiskPredictionService : IRiskPredictionService
    {
        private readonly HttpClient _httpClient;

        public RiskPredictionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> PredictRiskAsync(RiskInput input)
        {
            // POST către /predict 
            var response = await _httpClient.PostAsJsonAsync("/predict", input);

            response.EnsureSuccessStatusCode();

            // Structura exactă a răspunsului depinde de API. 
            // De obicei, Model Builder generează un JSON de forma: 
            // { "Prediction": "Moderate Risk", ... } 

            var result = await response.Content.ReadFromJsonAsync<RiskApiResponse>();

            return result?.PredictedLabel;
        }

        // clasă internă pentru maparea răspunsului 
        private class RiskApiResponse
        {
            public string PredictedLabel { get; set; }
        }
    }
}
