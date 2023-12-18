using Microsoft.AspNetCore.WebHooks.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WebHook.WebHooks.Receiver.Metadata
{
    public class WebHookVerifyCodeMetadata : IWebHookVerifyCodeMetadata
    {
        public string ReceiverName => "corehook";        
        public bool IsApplicable(string receiverName)
        {
            return true;
        }
    }
}
