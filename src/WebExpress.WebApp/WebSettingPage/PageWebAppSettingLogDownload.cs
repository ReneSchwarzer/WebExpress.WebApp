//using System.IO;
//using WebExpress.WebCore.WebAttribute;
//using WebExpress.WebCore.WebMessage;
//using WebExpress.WebCore.WebResource;
//using WebExpress.WebApp.WebScope;

//namespace WebExpress.WebApp.WebSettingPage
//{
//    /// <summary>
//    /// Download the log file.
//    /// </summary>
//    [Segment("download", "")]
//    [ContextPath("/")]
//    [Parent<PageWebAppSettingLog>]
//    [Module<Module>]
//    [Scope<ScopeAdmin>]
//    [Optional]
//    public sealed class PageWebAppSettingLogDownload : ResourceBinary
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        public PageWebAppSettingLogDownload()
//        {
//        }

//        /// <summary>
//        /// Processing of the resource.
//        /// </summary>
//        /// <param name="request">The request.</param>
//        /// <returns>The response.</returns>
//        public override Response Process(Request request)
//        {
//            if (!File.Exists(request.ServerContext.Log.Filename))
//            {
//                return new ResponseNotFound();
//            }

//            Data = File.ReadAllBytes(request.ServerContext.Log.Filename);

//            var response = base.Process(request);
//            response.Header.CacheControl = "no-cache";
//            response.Header.ContentType = "text/plain";

//            return response;
//        }
//    }
//}

