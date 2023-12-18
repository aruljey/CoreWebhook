

using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CoreWebhook.WebApi.GenWebHook
{
    public static class GenMvcCoreBuilderExtensions
    {
        public static IMvcCoreBuilder AddCoreWebHooks(this IMvcCoreBuilder builder)
        {
            CoreServiceCollectionSetup.AddCoreServices(builder.Services);
            return builder.AddWebHooks().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling= ReferenceLoopHandling.Ignore;
            });
        }

        
    }
}
