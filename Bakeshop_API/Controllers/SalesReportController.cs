using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bakeshop_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesReportController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SalesReportController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateSalesReport([FromBody] SalesDataInput input)
        {
            if (string.IsNullOrWhiteSpace(input?.RawData))
            {
                return BadRequest("The RawData field is required.");
            }

            try
            {
                var client = _httpClientFactory.CreateClient();

                client.DefaultRequestHeaders.Add("Authorization", "Bearer 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");

                var prompt = $"Summarize the following sales data and highlight key trends and best-selling products:\n{input.RawData}";

                var requestBody = new { inputs = prompt };
                var json = JsonSerializer.Serialize(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(
                    "https://api-inference.huggingface.co/models/mistralai/Mistral-7B-Instruct-v0.3",
                    content);

                var responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, $"Hugging Face API error: {response.StatusCode}\n{responseBody}");
                }

                var summary = JsonDocument.Parse(responseBody).RootElement[0].GetProperty("generated_text").GetString();

                return Ok(new { summary });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"❌ Internal server error:\n{ex.Message}");
            }
        }
    }

    public class SalesDataInput
    {
        public string RawData { get; set; }
    }
}
