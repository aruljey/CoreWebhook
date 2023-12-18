using Microsoft.AspNetCore.WebHooks.Filters;
using Microsoft.AspNetCore.WebHooks.Metadata;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.WebHook.WebHooks.Receiver.Metadata;

namespace CoreWebhook.WebApi.GenWebHook
{
    public static class CoreServiceCollectionSetup
    {
        public static void AddCoreServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            WebHookMetadata.Register<GenMetadata>(services);
            services.AddSingleton<GenSignatureFilter>();
            services.AddSingleton<GenVerifyCodeFilter>();
            services.AddSingleton<IWebHookVerifyCodeMetadata, WebHookVerifyCodeMetadata>();
        }
    }
}
