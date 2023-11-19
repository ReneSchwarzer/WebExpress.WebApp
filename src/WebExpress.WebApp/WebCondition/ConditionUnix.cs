using System;
using WebExpress.Core.WebCondition;
using WebExpress.Core.WebMessage;

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
