using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.WebHooks.Filters;
using Microsoft.Extensions.Options;
using System.Text;

namespace CoreWebhook.WebApi.GenWebHook
{
    public class GenSignatureFilter : WebHookVerifySignatureFilter, IAsyncResourceFilter
    {
        private readonly byte[] _secret;

        public GenSignatureFilter(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory) : base(configuration, hostingEnvironment, loggerFactory)
        {
            //_secret = Encoding.UTF8.GetBytes(options.Value.SharedSecret);
        }

        public override string ReceiverName => GenWebHookConstrants.ReceiverName;
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
                var errorResult = EnsureSecureConnection(ReceiverName, context.HttpContext.Request);
                if (errorResult != null)
                {
                    context.Result = errorResult;
                    return;
                }

                // 2. Get the expected hash from the signature header.
                var header = GetRequestHeader(request, GenWebHookConstrants.SignatureHeaderName, out errorResult);
                if (errorResult != null)
                {
                    context.Result = errorResult;
                    return;
                }

                //byte[] payload;
                //using (var ms = new MemoryStream())
                //{
                //    request.EnableRewind();
                //    await request.Body.CopyToAsync(ms);
                //    payload = ms.ToArray();
                //    request.Body.Position = 0;
                //}

                //if (payload == null || payload.Length == 0)
                //{
                //    context.Result = new BadRequestObjectResult("No payload");
                //    return;
                //}

                await next();

            }
        }
    }
}
