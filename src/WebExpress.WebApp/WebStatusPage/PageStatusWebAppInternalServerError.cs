﻿using WebExpress.Core.Internationalization;
using WebExpress.Core.WebAttribute;
using WebExpress.Core.WebMessage;
using WebExpress.Core.WebResource;

namespace WebExpress.WebApp.WebStatusPage
{
    /// <summary>
    /// The status page 500.
    /// </summary>
    [StatusCode(500)]
    [Default]
    public sealed class PageStatusWebAppInternalServerError : PageStatusWebApp<ResponseInternalServerError>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PageStatusWebAppInternalServerError()
        {

        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialization(IResourceContext context)
        {
            base.Initialization(context);

            StatusTitle = this.I18N("webexpress.webapp", "status.500.title");

            Title = $"{StatusCode} - {StatusTitle}";
        }
    }
}
