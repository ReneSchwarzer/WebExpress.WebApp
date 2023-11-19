using WebExpress.Core.Internationalization;
using WebExpress.Core.WebAttribute;
using WebExpress.Core.WebMessage;
using WebExpress.Core.WebResource;

namespace WebExpress.WebApp.WebStatusPage
{
    /// <summary>
    /// The status page 404.
    /// </summary>
    [StatusCode(404)]
    [Default]
    public sealed class PageStatusWebAppNotFound : PageStatusWebApp<ResponseNotFound>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PageStatusWebAppNotFound()
        {

        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialization(IResourceContext context)
        {
            base.Initialization(context);

            StatusTitle = this.I18N("webexpress.webapp", "status.404.title");

            Title = $"{StatusCode} - {StatusTitle}";

            StatusMessage = this.I18N("webexpress.webapp", "status.404.description");
        }
    }
}
