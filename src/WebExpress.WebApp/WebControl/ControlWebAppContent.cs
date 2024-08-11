using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebApp.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// Content of a web app page.
    /// </summary>
    public class ControlWebAppContent : ControlPanel
    {
        /// <summary>
        /// Returns the main panel.
        /// </summary>
        private ControlPanelMain MainPanel { get; } = new ControlPanelMain("webexpress.webapp.content.main")
        {
            Padding = new PropertySpacingPadding(PropertySpacing.Space.Two, PropertySpacing.Space.Null),
            Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two, PropertySpacing.Space.Null, PropertySpacing.Space.Null),
            BackgroundColor = LayoutSchema.ContentBackground,
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
        /// Returns the preferences area.
        /// </summary>
        public List<IControl> Preferences { get; } = new List<IControl>();

        /// <summary>
        /// Returns the primary area.
        /// </summary>
        public List<IControl> Primary { get; } = new List<IControl>();

        /// <summary>
        /// Returns the secondary area.
        /// </summary>
        public List<IControl> Secondary { get; } = new List<IControl>();

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppContent(string id = null)
            : base(id)
        {
            Init();

            Classes.Add("content");
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            BackgroundColor = LayoutSchema.ContentBackground;
            Toolbar.BackgroundColor = LayoutSchema.ToolbarBackground;
            Margin = new PropertySpacingMargin(PropertySpacing.Space.Two);

            Flexbox.Content.Add(MainPanel);
            Flexbox.Content.Add(Property);

            Content.Add(Toolbar);
            Content.Add(Flexbox);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            MainPanel.Content.Clear();

            MainPanel.Content.Add(Headline);
            MainPanel.Content.Add(new ControlPanel("webexpress.webapp.content.main.preferences", Preferences));
            MainPanel.Content.Add(new ControlPanel("webexpress.webapp.content.main.primary", Primary));
            MainPanel.Content.Add(new ControlPanel("webexpress.webapp.content.main.secondary", Secondary));

            Content.Clear();

            if (Toolbar.Items.Any())
            {
                Content.Add(Toolbar);
            }

            if (Property.Preferences.Any() || Property.Primary.Any() || Property.Secondary.Any())
            {
                Content.Add(Flexbox);
            }
            else
            {
                Content.Add(MainPanel);
            }

            return base.Render(context);
        }
    }
}
