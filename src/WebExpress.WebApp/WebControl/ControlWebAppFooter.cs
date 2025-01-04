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
    /// Footer for a web app.
    /// </summary>
    public class ControlWebAppFooter : Control
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
        public ControlWebAppFooter(string id = null)
            : base(id)
        {
            //BackgroundColor = LayoutSchema.FooterBackground;
            //TextColor = LayoutSchema.FooterText;
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var preferences = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionFooterPreferences>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var primary = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionFooterPrimary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var secondary = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionFooterSecondary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var preferencesList = Preferences.Union(preferences).ToList();
            var primaryList = Primary.Union(primary).ToList();
            var secondaryList = Secondary.Union(secondary).ToList();

            var elements = new List<IHtmlNode>
            {
                new HtmlElementTextContentDiv(preferencesList.Select(x => x.Render(renderContext, visualTree)).ToArray()),
                new HtmlElementTextContentDiv(primaryList.Select(x => x.Render(renderContext, visualTree)).ToArray()) { Class = "justify-content-center" },
                new HtmlElementTextContentDiv(secondaryList.Select(x => x.Render(renderContext, visualTree)).ToArray())
            };

            return new HtmlElementTextContentDiv(elements.ToArray())
            {
                Id = Id,
                Class = Css.Concatenate("footer", GetClasses()),
                Style = Style.Concatenate("", GetStyles()),
                Role = Role
            };
        }
    }
}
