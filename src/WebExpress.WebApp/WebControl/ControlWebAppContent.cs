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
    /// Content of a web app page.
    /// </summary>
    public class ControlWebAppContent : ControlPanel
    {
        /// <summary>
        /// Returns the preferences area.
        /// </summary>
        public List<IControl> Preferences { get; } = [];

        /// <summary>
        /// Returns the primary area.
        /// </summary>
        public List<IControl> Primary { get; } = [];

        /// <summary>
        /// Returns the secondary area.
        /// </summary>
        public List<IControl> Secondary { get; } = [];

        /// <summary>
        /// Returns the main panel.
        /// </summary>
        private ControlPanelMain MainPanel { get; } = new ControlPanelMain("webexpress.webapp.content.main")
        {
            Padding = new PropertySpacingPadding(PropertySpacing.Space.Two, PropertySpacing.Space.Null),
            Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two, PropertySpacing.Space.Null, PropertySpacing.Space.Null),
            //BackgroundColor = LayoutSchema.ContentBackground,
            Classes = new() { "flex-grow-1" }
        };

        /// <summary>
        /// Returns the flexbox.
        /// </summary>
        private ControlPanelFlexbox Flexbox { get; } = new ControlPanelFlexbox()
        {
            Layout = TypeLayoutFlexbox.Default,
            Align = TypeAlignFlexbox.Stretch
        };

        /// <summary>
        /// Returns the page properties.
        /// </summary>
        public ControlWebAppProperty Property { get; } = new ControlWebAppProperty("webexpress.webapp.content.property");

        /// <summary>
        /// Returns the toolbar.
        /// </summary>
        public ControlToolbar Toolbar { get; } = new ControlToolbar("webexpress.webapp.content.toolbar");

        /// <summary>
        /// Returns the headline control.
        /// </summary>
        public ControlWebAppHeadline Headline { get; } = new ControlWebAppHeadline("webexpress.webapp.content.main.headline");

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppContent(string id = null)
            : base(id)
        {
            //BackgroundColor = LayoutSchema.ContentBackground;
            //Toolbar.BackgroundColor = LayoutSchema.ToolbarBackground;
            Margin = new PropertySpacingMargin(PropertySpacing.Space.Two);

            Flexbox.Add(MainPanel);
            Flexbox.Add(Property);

            Add(Toolbar);
            Add(Flexbox);

            Classes.Add("content");
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            var preferences = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionContentPreferences>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var primary = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionContentPrimary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var secondary = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionContentSecondary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var preferencesList = Preferences.Union(preferences).ToList();
            var primaryList = Primary.Union(primary).ToList();
            var secondaryList = Secondary.Union(secondary).ToList();

            MainPanel.Clear();

            MainPanel.Add(Headline);
            MainPanel.Add(new ControlPanel("webexpress.webapp.content.main.preferences", preferencesList.ToArray()));
            MainPanel.Add(new ControlPanel("webexpress.webapp.content.main.primary", primaryList.ToArray()));
            MainPanel.Add(new ControlPanel("webexpress.webapp.content.main.secondary", secondaryList.ToArray()));

            Clear();

            if (Toolbar.Items.Any())
            {
                Add(Toolbar);
            }

            if (Property.Preferences.Any() || Property.Primary.Any() || Property.Secondary.Any())
            {
                Add(Flexbox);
            }
            else
            {
                Add(MainPanel);
            }

            return base.Render(renderContext);
        }
    }
}
