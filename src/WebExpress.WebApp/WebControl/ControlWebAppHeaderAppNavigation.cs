﻿using System.Collections.Generic;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebApp.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// Header for a web app.
    /// </summary>
    public class ControlWebAppHeaderAppNavigation : ControlPanelFlexbox
    {
        /// <summary>
        /// Returns or sets the preferences area.
        /// </summary>
        public List<IControlNavigationItem> Preferences { get; protected set; } = new List<IControlNavigationItem>();

        /// <summary>
        /// Returns or sets the primary area.
        /// </summary>
        public List<IControlNavigationItem> Primary { get; protected set; } = new List<IControlNavigationItem>();

        /// <summary>
        /// Returns or sets the secondary area.
        /// </summary>
        public List<IControlNavigationItem> Secondary { get; protected set; } = new List<IControlNavigationItem>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppHeaderAppNavigation(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Padding = new PropertySpacingPadding(PropertySpacing.Space.Null);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {

            var preferences = new ControlNavigation("webexpress.webapp.header.appnavigation.preferences", Preferences)
            {
                Layout = TypeLayoutTab.Default,
                ActiveColor = LayoutSchema.HeaderNavigationActiveBackground,
                ActiveTextColor = LayoutSchema.HeaderNavigationActive,
                LinkColor = LayoutSchema.HeaderNavigationLink
            };

            var primary = new ControlNavigation("webexpress.webapp.header.appnavigation.primary", Primary)
            {
                Layout = TypeLayoutTab.Default,
                ActiveColor = LayoutSchema.HeaderNavigationActiveBackground,
                ActiveTextColor = LayoutSchema.HeaderNavigationActive,
                LinkColor = LayoutSchema.HeaderNavigationLink
            };

            var secondary = new ControlNavigation("webexpress.webapp.header.appnavigation.secondary", Secondary)
            {
                Layout = TypeLayoutTab.Default,
                ActiveColor = LayoutSchema.HeaderNavigationActiveBackground,
                ActiveTextColor = LayoutSchema.HeaderNavigationActive,
                LinkColor = LayoutSchema.HeaderNavigationLink
            };

            return new HtmlElementTextContentDiv(preferences.Render(context), primary.Render(context), secondary.Render(context))
            {
                Id = Id,
                Class = Css.Concatenate("", GetClasses()),
                Style = Style.Concatenate("", GetStyles()),
                Role = Role
            };
        }
    }
}
