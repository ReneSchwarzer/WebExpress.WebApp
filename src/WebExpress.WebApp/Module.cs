using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebModule;

namespace WebExpress.WebApp
{
    [Application("*")]
    [Name("module.name")]
    [Description("module.description")]
    [Icon("/assets/img/Logo.png")]
    [AssetPath("/")]
    [ContextPath("/modules/wxapp")]
    public sealed class Module : WebCore.WebModule.Module
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Module()
        {
        }

        /// <summary>
        /// Instillation of the module. Here, for example, managed resources can be loaded. 
        /// </summary>
        /// <param name="moduleContext">The context that applies to the execution of the plugin.</param>
        public override void Initialization(IModuleContext moduleContext)
        {
            base.Initialization(moduleContext);
        }

        /// <summary>
        /// Invoked when the module starts working. The call is concurrent.
        /// </summary>
        public override void Run()
        {
            base.Run();
        }

        /// <summary>
        /// Release unmanaged resources that have been reserved during use.
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
