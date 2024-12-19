using System.Collections.Generic;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;

namespace WebExpress.WebApp.WebPage
{
    /// <summary>
    /// Represents the visual tree of the web application.
    /// </summary>
    public class VisualTreeWebApp : IVisualTree
    {
        // header
        private readonly List<FragmentContext> _headerAppNavigatorPreferences = [];
        private readonly List<FragmentContext> _headerAppNavigatorPrimary = [];
        private readonly List<FragmentContext> _headerAppNavigatorSecondary = [];
        private readonly List<FragmentContext> _headerNavigationPreferences = [];
        private readonly List<FragmentContext> _headerNavigationPrimary = [];
        private readonly List<FragmentContext> _headerNavigationSecondary = [];
        private readonly List<FragmentContext> _headerQuickCreatePreferences = [];
        private readonly List<FragmentContext> _headerQuickCreatePrimary = [];
        private readonly List<FragmentContext> _headerQuickCreateSecondary = [];
        private readonly List<FragmentContext> _headerHelpPreferences = [];
        private readonly List<FragmentContext> _headerHelpPrimary = [];
        private readonly List<FragmentContext> _headerHelpSecondary = [];
        private readonly List<FragmentContext> _headerSettingsPreferences = [];
        private readonly List<FragmentContext> _headerSettingsPrimary = [];
        private readonly List<FragmentContext> _headerSettingsSecondary = [];
        // sidebar
        private readonly List<FragmentContext> _sidebarHeader = [];
        private readonly List<FragmentContext> _sidebarPreferences = [];
        private readonly List<FragmentContext> _sidebarPrimary = [];
        private readonly List<FragmentContext> _sidebarSecondary = [];
        // headline
        private readonly List<FragmentContext> _contentHeadlinePrologue = [];
        private readonly List<FragmentContext> _contentHeadlinePreferences = [];
        private readonly List<FragmentContext> _contentHeadlinePrimary = [];
        private readonly List<FragmentContext> _contentHeadlineSecondary = [];
        private readonly List<FragmentContext> _contentHeadlineMorePreferences = [];
        private readonly List<FragmentContext> _contentHeadlineMorePrimary = [];
        private readonly List<FragmentContext> _contentHeadlineMoreSecondary = [];
        private readonly List<FragmentContext> _contentHeadlineMetadata = [];
        // property
        private readonly List<FragmentContext> _contentPropertyPreferences = [];
        private readonly List<FragmentContext> _contentPropertyPrimary = [];
        private readonly List<FragmentContext> _contentPropertySecondary = [];
        // content
        private readonly List<FragmentContext> _contentPreferences = [];
        private readonly List<FragmentContext> _contentPrimary = [];
        private readonly List<FragmentContext> _contentSecondary = [];
        // footer
        private readonly List<FragmentContext> _footerPreferences = [];
        private readonly List<FragmentContext> _footerPrimary = [];
        private readonly List<FragmentContext> _footerSecondary = [];

        /// <summary>
        /// Returns or sets the header.
        /// </summary>
        //public ControlWebAppHeader Header { get; protected set; } = new ControlWebAppHeader("webexpress.webapp.header");

        ///// <summary>
        ///// Returns or sets the content.
        ///// </summary>
        //public new ControlWebAppContent Content { get; protected set; } = new ControlWebAppContent("webexpress.webapp.content");

        ///// <summary>
        ///// Returns or sets the footer.
        ///// </summary>
        //public ControlWebAppFooter Footer { get; protected set; } = new ControlWebAppFooter("webexpress.webapp.footer");

        ///// <summary>
        ///// Returns or sets the area for the toast messages.
        ///// </summary>
        //public ControlPanelToast Toast { get; protected set; } = new ControlPanelToast("webexpress.webapp.toast");

        ///// <summary>
        ///// Returns or sets the range for the path specification.
        ///// </summary>
        //public ControlBreadcrumb Breadcrumb { get; protected set; } = new ControlBreadcrumb("webexpress.webapp.breadcrumb");

        ///// <summary>
        ///// Returns or sets the area for prologue.
        ///// </summary>
        //public ControlPanel Prologue { get; protected set; } = new ControlPanel("webexpress.webapp.prologue");

        ///// <summary>
        ///// Returns or sets the range for the search options.
        ///// </summary>
        //public ControlPanel SearchOptions { get; protected set; } = new ControlPanel("webexpress.webapp.searchoptions");

        ///// <summary>
        ///// Returns or sets the sidebar.
        ///// </summary>
        //public ControlWebAppSidebar Sidebar { get; protected set; } = new ControlWebAppSidebar("webexpress.webapp.sidebar");

        ///// <summary>
        ///// Initializes a new instance of the class.
        ///// </summary>
        //public VisualTreeWebApp()
        //{
        //    Header.Fixed = TypeFixed.Top;
        //    Header.Styles = new List<string>(new[] { "position: sticky; top: 0; z-index: 99;" });

        //    Breadcrumb.Margin = new PropertySpacingMargin(PropertySpacing.Space.Null);
        //    Breadcrumb.BackgroundColor = LayoutSchema.BreadcrumbBackground;
        //    Breadcrumb.Size = LayoutSchema.BreadcrumbSize;

        //    Toast.BackgroundColor = LayoutSchema.ValidationWarningBackground;

        //    Sidebar.BackgroundColor = LayoutSchema.SidebarBackground;

        //    Content.BackgroundColor = LayoutSchema.ContentBackground;
        //    Content.Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None);
        //    //Content.Width = TypeWidth.OneHundred;

        //    Footer.BackgroundColor = LayoutSchema.FooterBackground;
        //}


        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public VisualTreeWebApp()
        {
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context for rendering the page.</param>
        /// <returns>The page as an html tree.</returns>
        public virtual IHtmlNode Render(IVisualTreeContext context)
        {
            var html = new HtmlElementRootHtml();
            //html.Head.Title = I18N.Translate(context.Request, Title);
            //html.Head.Favicons = Favicons?.Select(x => new Favicon(x.Url, x.Mediatype));
            //html.Head.Styles = Styles;
            //html.Head.Meta = Meta;
            //html.Head.Scripts = HeaderScripts;
            ////html.Body.Elements.AddRange(Content?.Where(x => x.Enable).Select(x => x.Render(context)));
            //html.Body.Scripts = [.. Scripts.Values];

            //html.Head.CssLinks = CssLinks.Where(x => x != null).Select(x => x.ToString());
            //html.Head.ScriptLinks = HeaderScriptLinks?.Where(x => x != null).Select(x => x.ToString());

            return html;
        }
    }
}
