using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.WebHooks.Filters;
using Microsoft.AspNetCore.WebHooks.Metadata;

namespace CoreWebhook.WebApi.GenWebHook
{
    public class GenVerifyCodeFilter : WebHookVerifyCodeFilter, IAsyncResourceFilter
    {
        public GenVerifyCodeFilter(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory, IWebHookVerifyCodeMetadata verifyCodeMetadata) : base(configuration, hostingEnvironment, loggerFactory, verifyCodeMetadata)
        {
        }       
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }
            var request = context.HttpContext.Request;
            if (HttpMethods.IsPost(request.Method))
            {
                // 1. Confirm a secure connection.
                var errorResult = EnsureValidCode(context.HttpContext.Request,context.RouteData,GenWebHookConstrants.ReceiverName);
                if (errorResult != null)
                {
                    context.Result = errorResult;
                    return;
                }

                await next();
            }
        }
    }
}
