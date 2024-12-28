using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

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
        public IEnumerable<IControlNavigationItem> Preferences { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the primary area.
        /// </summary>
        public IEnumerable<IControlNavigationItem> Primary { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the secondary area.
        /// </summary>
        public IEnumerable<IControlNavigationItem> Secondary { get; protected set; } = [];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppHeaderAppNavigation(string id = null)
            : base(id)
        {
            Padding = new PropertySpacingPadding(PropertySpacing.Space.Null);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            var preferences = WebEx.ComponentHub.FragmentManager.GetFragments<FragmentControlNavigationItemLink, SectionAppNavigationPreferences>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var preferencesCtrl = new ControlNavigation("webexpress.webapp.header.appnavigation.preferences", Preferences.Union(preferences).ToArray())
            {
                Layout = TypeLayoutTab.Default,
                //ActiveColor = LayoutSchema.HeaderNavigationActiveBackground,
                //ActiveTextColor = LayoutSchema.HeaderNavigationActive,
                //LinkColor = LayoutSchema.HeaderNavigationLink
            };

            var primary = WebEx.ComponentHub.FragmentManager.GetFragments<FragmentControlNavigationItemLink, SectionAppNavigationPrimary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var primaryCtrl = new ControlNavigation("webexpress.webapp.header.appnavigation.primary", Primary.Union(primary).ToArray())
            {
                Layout = TypeLayoutTab.Default,
                //ActiveColor = LayoutSchema.HeaderNavigationActiveBackground,
                //ActiveTextColor = LayoutSchema.HeaderNavigationActive,
                //LinkColor = LayoutSchema.HeaderNavigationLink
            };

            var secondary = WebEx.ComponentHub.FragmentManager.GetFragments<FragmentControlNavigationItemLink, SectionAppNavigationSecondary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var secondaryCtrl = new ControlNavigation("webexpress.webapp.header.appnavigation.secondary", Secondary.Union(secondary).ToArray())
            {
                Layout = TypeLayoutTab.Default,
                //ActiveColor = LayoutSchema.HeaderNavigationActiveBackground,
                //ActiveTextColor = LayoutSchema.HeaderNavigationActive,
                //LinkColor = LayoutSchema.HeaderNavigationLink
            };

            return new HtmlElementTextContentDiv(preferencesCtrl.Render(renderContext), primaryCtrl.Render(renderContext), secondaryCtrl.Render(renderContext))
            {
                Id = Id,
                Class = Css.Concatenate("", GetClasses()),
                Style = Style.Concatenate("", GetStyles()),
                Role = Role
            };
        }
    }
}
