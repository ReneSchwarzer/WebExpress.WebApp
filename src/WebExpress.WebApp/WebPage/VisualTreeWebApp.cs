using System.Collections.Generic;
using WebExpress.WebApp.WebControl;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebApp.WebPage
{
    public class VisualTreeWebApp : VisualTreeControl
    {
        /// <summary>
        /// Returns or sets the header.
        /// </summary>
        public ControlWebAppHeader Header { get; protected set; } = new ControlWebAppHeader("webexpress.webapp.header");

        /// <summary>
        /// Returns or sets the content.
        /// </summary>
        public new ControlWebAppContent Content { get; protected set; } = new ControlWebAppContent("webexpress.webapp.content");

        /// <summary>
        /// Returns or sets the footer.
        /// </summary>
        public ControlWebAppFooter Footer { get; protected set; } = new ControlWebAppFooter("webexpress.webapp.footer");

        /// <summary>
        /// Returns or sets the area for the toast messages.
        /// </summary>
        public ControlPanelToast Toast { get; protected set; } = new ControlPanelToast("webexpress.webapp.toast");

        /// <summary>
        /// Returns or sets the range for the path specification.
        /// </summary>
        public ControlBreadcrumb Breadcrumb { get; protected set; } = new ControlBreadcrumb("webexpress.webapp.breadcrumb");

        /// <summary>
        /// Returns or sets the area for prologue.
        /// </summary>
        public ControlPanel Prologue { get; protected set; } = new ControlPanel("webexpress.webapp.prologue");

        /// <summary>
        /// Returns or sets the range for the search options.
        /// </summary>
        public ControlPanel SearchOptions { get; protected set; } = new ControlPanel("webexpress.webapp.searchoptions");

        /// <summary>
        /// Returns or sets the sidebar.
        /// </summary>
        public ControlWebAppSidebar Sidebar { get; protected set; } = new ControlWebAppSidebar("webexpress.webapp.sidebar");

        /// <summary>
        /// Constructor
        /// </summary>
        public VisualTreeWebApp()
        {
            Header.Fixed = TypeFixed.Top;
            Header.Styles = new List<string>(new[] { "position: sticky; top: 0; z-index: 99;" });

            Breadcrumb.Margin = new PropertySpacingMargin(PropertySpacing.Space.Null);
            Breadcrumb.BackgroundColor = LayoutSchema.BreadcrumbBackground;
            Breadcrumb.Size = LayoutSchema.BreadcrumbSize;

            Toast.BackgroundColor = LayoutSchema.ValidationWarningBackground;

            Sidebar.BackgroundColor = LayoutSchema.SidebarBackground;

            Content.BackgroundColor = LayoutSchema.ContentBackground;
            Content.Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None);
            //Content.Width = TypeWidth.OneHundred;

            Footer.BackgroundColor = LayoutSchema.FooterBackground;
        }

    }
}
