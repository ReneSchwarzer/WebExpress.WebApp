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
    /// Properties for a web app.
    /// </summary>
    public class ControlWebAppProperty : Control
    {
        /// <summary>
        /// Returns or sets the preferences area.
        /// </summary>
        public List<IControl> Preferences { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the primary area.
        /// </summary>
        public List<IControl> Primary { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the secondary area.
        /// </summary>
        public List<IControl> Secondary { get; protected set; } = [];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppProperty(string id = null)
            : base(id)
        {
            //BackgroundColor = LayoutSchema.PropertyBackground;
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            var preferences = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionPropertyPreferences>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var primary = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionPropertyPrimary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var secondary = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionPropertySecondary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var preferencesList = Preferences.Union(preferences).ToList();
            var primaryList = Primary.Union(primary).ToList();
            var secondaryList = Secondary.Union(secondary).ToList();

            if (Preferences.Count == 0 && Primary.Count == 0 && Secondary.Count == 0)
            {
                return null;
            }

            var preferencesCtrl = new HtmlElementTextContentDiv(preferencesList.Select(x => x.Render(renderContext)).ToArray());
            var primaryCtrl = new HtmlElementTextContentDiv(primaryList.Select(x => x.Render(renderContext)).ToArray());
            var secondaryCtrl = new HtmlElementTextContentDiv(secondaryList.Select(x => x.Render(renderContext)).ToArray());

            return new HtmlElementTextContentDiv(preferencesCtrl, primaryCtrl, secondaryCtrl)
            {
                Id = Id,
                Class = Css.Concatenate("proterty", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };
        }
    }
}
