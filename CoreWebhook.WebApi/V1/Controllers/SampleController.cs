using CoreWebhook.Core.Dtos.Common;
using CoreWebhook.WebApi.GenWebHook;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace CoreWebhook.WebApi.V1.Controllers
{
    public class SampleController : ControllerBase
    {
        private IConfiguration configuration;
        private ILogger<SampleController> _logger;

        public SampleController(IConfiguration iconfig, ILogger<SampleController> logger)
        {
            configuration = iconfig;
            _logger = logger;
        }

        //https://localhost:7221/api/webhooks/incoming/corehook

        [GenWebHook]
        [ActionName(nameof(GetSampleData))]
        public async Task<ApiResponse<string>> GetSampleData(JObject data)
        {
            var response = new ApiResponse<string>
            {
                Success = true,
                Data=data.ToString(),
                ErrorCode="0",
                ErrorMessage=""
            };

            return response;
        }


    }
}
