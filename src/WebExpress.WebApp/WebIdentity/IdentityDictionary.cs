using System.Collections.Generic;
using WebExpress.WebCore.WebModule;

namespace WebExpress.WebApp.WebIdentity
{
    /// <summary>
    /// The identity directory.
    /// </summary>
    internal class IdentityDictionary
    {
        /// <summary>
        /// The directory of identities.
        /// module -> id -> identity
        /// </summary>
        public static Dictionary<IModuleContext, Dictionary<string, IdentityItem>> Identities { get; } = new Dictionary<IModuleContext, Dictionary<string, IdentityItem>>();

        /// <summary>
        /// The directory of roles.
        /// module -> id -> role
        /// </summary>
        public static Dictionary<IModuleContext, Dictionary<string, IdentityRoleItem>> Roles { get; } = new Dictionary<IModuleContext, Dictionary<string, IdentityRoleItem>>();

        /// <summary>
        /// The directory of resources.
        ///  module -> id -> resource
        /// </summary>
        public static Dictionary<IModuleContext, Dictionary<string, IdentityResourceItem>> Resources { get; } = new Dictionary<IModuleContext, Dictionary<string, IdentityResourceItem>>();
    }
}
