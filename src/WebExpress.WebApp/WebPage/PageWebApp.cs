﻿using WebExpress.WebCore.WebPage;

namespace WebExpress.WebApp.WebPage
{
    /// <summary>
    /// Represents an abstract base class for a web application page.
    /// </summary>
    public abstract class PageWebApp : IPage<VisualTreeWebApp>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public PageWebApp()
        {
        }

        /// <summary>
        /// Processing of the page.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree control to be processed.</param>
        public virtual void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
        }
    }
}
