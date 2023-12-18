using Microsoft.AspNetCore.WebHooks.Metadata;

namespace CoreWebhook.WebApi.GenWebHook
{
    public class GenMetadata : WebHookMetadata, IWebHookFilterMetadata
    {
        private readonly GenSignatureFilter _genSignatureFilter;
        private readonly GenVerifyCodeFilter _genVerifyCodeFilter;
        public override WebHookBodyType BodyType => WebHookBodyType.Json;

        public GenMetadata(GenVerifyCodeFilter genVerifyCodeFilter):base(GenWebHookConstrants.ReceiverName)
        {
            _genVerifyCodeFilter = genVerifyCodeFilter;
        }
        public void AddFilters(WebHookFilterMetadataContext context)
        {
            context.Results.Add(_genVerifyCodeFilter);
        }
    }
}
