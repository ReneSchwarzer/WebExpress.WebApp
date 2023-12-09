using System;
using WebExpress.WebCore.WebCondition;
using WebExpress.WebCore.WebMessage;

namespace WebExpress.WebApp.WebCondition
{
    public class ConditionUnix : ICondition
    {
        /// <summary>
        /// Die Bedingung
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>true wenn die Bedingung erfüllt ist, false sonst</returns>
        public bool Fulfillment(Request request)
        {
            return Environment.OSVersion.ToString().Contains("unix", StringComparison.OrdinalIgnoreCase);
        }
    }
}
