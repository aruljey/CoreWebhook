using Microsoft.AspNetCore.WebHooks;

namespace CoreWebhook.WebApi.GenWebHook
{
    public class GenWebHookAttribute : WebHookAttribute
    {
        public GenWebHookAttribute() : base(GenWebHookConstrants.ReceiverName)
        {

        }
    }
}
