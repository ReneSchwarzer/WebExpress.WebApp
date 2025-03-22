﻿using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebApiControl;
using WebExpress.WebApp.WebControl;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebTheme;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebApp.WebPage
{
    /// <summary>
    /// Represents the visual tree of the web application.
    /// </summary>
    public class VisualTreeWebApp : VisualTreeControl
    {
        /// <summary>
        /// Returns or sets the theme of the web application.
        /// </summary>
        public IThemeContext Theme { get; set; }

        /// <summary>
        /// Returns header control.
        /// </summary>
        public ControlWebAppHeader Header { get; } = new ControlWebAppHeader("wx-header");

        /// <summary>
        /// Returns the area for the toast messages control.
        /// </summary>
        public ControlPanelToast Toast { get; protected set; } = new ControlPanelToast("wx-toast");

        /// <summary>
        /// Returns the range for the path specification.
        /// </summary>
        public ControlBreadcrumb Breadcrumb { get; protected set; } = new ControlBreadcrumb("wx-breadcrumb");

        /// <summary>
        /// Returns the area for prologue.
        /// </summary>
        public ControlPanel Prologue { get; protected set; } = new ControlPanel("wx-prologue");

        ///// <summary>
        ///// Returns the range for the search options control.
        ///// </summary>
        //public ControlPanel SearchOptions { get; protected set; } = new ControlPanel("wx-searchoptions");

        /// <summary>
        /// Returns the sidebar control.
        /// </summary>
        public ControlWebAppSidebar Sidebar { get; protected set; } = new ControlWebAppSidebar("wx-sidebar");


        /// <summary>
        /// Returns the content control.
        /// </summary>
        public new ControlWebAppContent Content { get; protected set; } = new ControlWebAppContent("wx-content");

        /// <summary>
        /// Returns the footer control.
        /// </summary>
        public ControlWebAppFooter Footer { get; protected set; } = new ControlWebAppFooter("wx-footer");

        /// <summary>
        /// Returns the control for displaying notification popups via API.
        /// </summary>
        public ControlApiNotificationPopup NotificationPopup { get; protected set; } = new ControlApiNotificationPopup("wx-notificationpopup");

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub.</param>
        /// <param name="pageContext">The page context.</param>
        public VisualTreeWebApp(IComponentHub componentHub, IPageContext pageContext)
            : base(componentHub, pageContext)
        {
            var applicationContext = pageContext?.ApplicationContext;

            Header.Fixed = TypeFixed.Top;
            Header.Styles = new List<string>(["position: sticky; top: 0; z-index: 99;"]);

            Breadcrumb.Uri = pageContext?.Uri;
            Breadcrumb.Margin = new PropertySpacingMargin(PropertySpacing.Space.Null);
            Content.Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None);

            AddCssLink(UriResource.Combine(applicationContext?.ContextPath, "/assets/css/webexpress.webapp.css"));
            AddCssLink(UriResource.Combine(applicationContext?.ContextPath, "/assets/css/webexpress.webapp.popupnotification.css"));
            AddCssLink(UriResource.Combine(applicationContext?.ContextPath, "/assets/css/webexpress.webapp.taskprogressbar.css"));
            AddCssLink(Theme?.ThemeStyle ?? UriResource.Combine(applicationContext?.ContextPath, "/assets/css/webexpress.webapp.theme.css"));
            AddHeaderScriptLink(UriResource.Combine(applicationContext?.ContextPath, "assets/js/webexpress.webapp.js"));
            AddHeaderScriptLink(UriResource.Combine(applicationContext?.ContextPath, "assets/js/webexpress.webapp.popupnotification.js"));
            AddHeaderScriptLink(UriResource.Combine(applicationContext?.ContextPath, "assets/js/webexpress.webapp.selection.js"));
            AddHeaderScriptLink(UriResource.Combine(applicationContext?.ContextPath, "assets/js/webexpress.webapp.table.js"));
            AddHeaderScriptLink(UriResource.Combine(applicationContext?.ContextPath, "assets/js/webexpress.webapp.taskprogressbar.js"));
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context for rendering the page.</param>
        /// <returns>The page as an html tree.</returns>
        public override IHtmlNode Render(IVisualTreeContext context)
        {
            var html = new HtmlElementRootHtml();
            var body = new HtmlElementSectionBody();
            var renderContext = new RenderControlContext(context.RenderContext);
            html.Head.Title = I18N.Translate(context.Request, Title);
            html.Head.Favicons = Favicons;
            html.Head.Styles = Styles;
            html.Head.Meta = Meta;
            html.Head.Scripts = HeaderScripts;
            html.Head.CssLinks = CssLinks.Where(x => x != null).Select(x => x.ToString());
            html.Head.ScriptLinks = HeaderScriptLinks?.Where(x => x != null).Select(x => x.ToString());

            // header
            Header.AppTitle.Text = html.Head.Title;
            if (Theme?.ThemeMode == ThemeMode.Dark)
            {
                html.Body.AddUserAttribute("data-bs-theme", "dark");
            }
            html.Body.Add(Header.Render(renderContext, this));
            html.Body.Add(Toast.Render(renderContext, this));
            html.Body.Add(Breadcrumb.Render(renderContext, this));
            html.Body.Add(Prologue.Render(renderContext, this));

            var split = new ControlPanelSplit
            (
                "wx-split",
                [Sidebar],
                [Content]
            )
            {
                Border = new PropertyBorder(true),
                Orientation = TypeOrientationSplit.Horizontal,
                Panel1InitialSize = 20,
                Panel1MinSize = 150
            };

            html.Body.Add(split.Render(renderContext, this));
            html.Body.Add(Footer.Render(renderContext, this));
            html.Body.Add(NotificationPopup.Render(renderContext, this));

            html.Body.Scripts = [.. Scripts.Values];

            return html;
        }
    }
}
