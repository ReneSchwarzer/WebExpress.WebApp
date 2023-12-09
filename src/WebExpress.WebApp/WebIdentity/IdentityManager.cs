using System.Linq;
using System.Security;
using WebExpress.WebCore;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebModule;
using WebExpress.WebCore.WebPlugin;

namespace WebExpress.WebApp.WebIdentity
{
    /// <summary>
    /// Management of identities (users).
    /// </summary>
    public class IdentityManager
    {
        /// <summary>
        /// Returns or sets the reference to the context of the host.
        /// </summary>
        public IHttpServerContext HttpServerContext { get; private set; }

        /// <summary>
        /// Returns the current signed-in identity.
        /// </summary>
        public static IIdentity CurrentIdentity { get; set; }

        /// <summary>
        /// Returns or sets the reference to the context of the plugin.
        /// </summary>
        private static IPluginContext Context { get; set; }

        /// <summary>
        /// Returns the directory by listing the entities, roles, and resources.
        /// </summary>
        private static IdentityDictionary Dictionary { get; } = new IdentityDictionary();

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The reference to the context of the host.</param>
        public void Initialization(IHttpServerContext context)
        {
            HttpServerContext = context;

            HttpServerContext.Log.Debug(message: InternationalizationManager.I18N("webexpress:identitymanager.initialization"));
        }

        /// <summary>
        /// Adds identity entries.
        /// </summary>
        /// <param name="context">The context that applies to the execution of the plugin.</param>
        public void Register(IModuleContext context)
        {
            var assembly = context.PluginContext.Assembly;

            foreach (var type in assembly.GetExportedTypes().Where(x => x.IsClass && x.IsSealed && x.GetInterface(typeof(IIdentityResource).Name) != null))
            {
                var id = type.FullName?.ToLower();
                var name = type.Name;
                var description = string.Empty;
                var moduleId = string.Empty;

                foreach (var customAttribute in type.CustomAttributes.Where(x => x.AttributeType.GetInterfaces().Contains(typeof(IModuleAttribute))))
                {
                    if (customAttribute.AttributeType == typeof(NameAttribute))
                    {
                        name = customAttribute.ConstructorArguments.FirstOrDefault().Value?.ToString();
                    }
                    else if (customAttribute.AttributeType == typeof(DescriptionAttribute))
                    {
                        description = customAttribute.ConstructorArguments.FirstOrDefault().Value?.ToString();
                    }
                    else if (customAttribute.AttributeType.Name == typeof(ModuleAttribute<>).Name && customAttribute.AttributeType.Namespace == typeof(ModuleAttribute<>).Namespace)
                    {
                        moduleId = customAttribute.AttributeType.GenericTypeArguments.FirstOrDefault()?.FullName?.ToLower();
                    }
                }

                if (string.IsNullOrWhiteSpace(moduleId))
                {
                    // no module has been specified
                    HttpServerContext.Log.Warning(message: InternationalizationManager.I18N("webexpress:identitymanager.moduleless"), args: id);

                    continue;
                }

                // identify the associated module
                //var module = ModuleManager.GetModule(context.Application, moduleId);

                //if (module == null || !(module.ModuleId == context.ModuleId && module.Application.ApplicationId == context.Application.ApplicationId))
                //{
                //    continue;
                //}
            }
        }

        /// <summary>
        /// Registers an identity.
        /// </summary>
        /// <param name="identity">The identity.</param>
        public static void Register(IIdentity identity)
        {

        }

        /// <summary>
        /// Registers a role.
        /// </summary>
        /// <param name="role">The (identity) role.</param>
        public static void Register(IIdentityRole role)
        {

        }

        /// <summary>
        /// Registers a resource.
        /// </summary>
        /// <param name="resource">The resource.</param>
        public static void Register(IIdentityResource resource)
        {

        }

        /// <summary>
        /// Removes all identities, roles, and resources of an application.
        /// </summary>
        /// <param name="application">Die Anwendung</param>
        public static void Unregister(IApplicationContext application)
        {

        }

        /// <summary>
        /// Login an identity.
        /// </summary>
        /// <param name="login">The login id.</param>
        /// <param name="password">The password.</param>
        /// <returns>True if successful, false otherwise.</returns>
        public static bool Login(string login, SecureString password)
        {
            return false;
        }

        /// <summary>
        /// Logout an identity.
        /// </summary>
        public static void Logout()
        {

        }

        /// <summary>
        /// Checks for access rights.
        /// </summary>
        /// <param name="identiy">Returns or sets the id.entität</param>
        /// <param name="mode">The access mode (read | write | execute).</param>
        public static void CheckAccess(IIdentity identiy, string mode)
        {

        }
    }
}
