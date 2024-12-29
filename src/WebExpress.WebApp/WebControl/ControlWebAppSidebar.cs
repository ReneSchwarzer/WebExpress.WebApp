using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// Sidebar for a web app.
    /// </summary>
    public class ControlWebAppSidebar : Control
    {
        /// <summary>
        /// Returns or sets the header area.
        /// </summary>
        public List<IControl> Header { get; protected set; } = [];

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
        public ControlWebAppSidebar(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            var header = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionSidebarHeader>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var preferences = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionSidebarPreferences>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var primary = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionSidebarPrimary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var secondary = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionSidebarSecondary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var settingsList = new List<IControlDropdownItem>
            {
                new ControlDropdownItemHeader() { Text = I18N.Translate(renderContext.Request?.Culture, "webexpress.webapp:header.setting.label") }
            };

            var headerList = Header.Union(header).ToList();
            var preferencesList = Preferences.Union(preferences).ToList();
            var primaryList = Primary.Union(primary).ToList();
            var secondaryList = Secondary.Union(secondary).ToList();

            if (!(headerList.Any() || preferencesList.Any() || primaryList.Any() || secondaryList.Any()))
            {
                return null;
            }

            var elements = new List<IHtmlNode>();
            elements.AddRange(headerList.Select(x => x.Render(renderContext)));
            elements.AddRange(preferencesList.Select(x => x.Render(renderContext)));
            elements.AddRange(primaryList.Select(x => x.Render(renderContext)));
            elements.AddRange(secondaryList.Select(x => x.Render(renderContext)));

            return new HtmlElementTextContentDiv(elements.ToArray())
            {
                Id = Id,
                Class = Css.Concatenate("sidebar", GetClasses()),
                Style = Style.Concatenate("display: block;", GetStyles()),
                Role = Role
            };
        }
    }
}
