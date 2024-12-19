//using WebExpress.WebCore.Internationalization;
//using WebExpress.WebCore.WebAttribute;
//using WebExpress.WebCore.WebMessage;
//using WebExpress.WebCore.WebResource;

//namespace WebExpress.WebApp.WebStatusPage
//{
//    /// <summary>
//    /// Statusseite
//    /// </summary>
//    [StatusCode(400)]
//    [Default]
//    public sealed class PageStatusWebAppBadRequest : PageStatusWebApp<ResponseBadRequest>
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        public PageStatusWebAppBadRequest()
//        {

//        }

//        /// <summary>
//        /// Initialization
//        /// </summary>
//        /// <param name="context">The context.</param>
//        public override void Initialization(IResourceContext context)
//        {
//            base.Initialization(context);

//            StatusTitle = this.I18N("webexpress.webapp", "status.400.title");

//            Title = $"{StatusCode} - {StatusTitle}";
//        }
//    }
//}
