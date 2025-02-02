using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// Represents the content control for a web application.
    /// </summary>
    public class ControlWebAppContent : Control
    {
        /// <summary>
        /// Returns the toolbar.
        /// </summary>
        public ControlWebAppToolbar Toolbar { get; } = new ControlWebAppToolbar("webexpress-webapp-content-toolbar");

        /// <summary>
        /// Returns the main panel.
        /// </summary>
        public ControlWebAppMain MainPanel { get; } = new ControlWebAppMain("webexpress-webapp-content-main")
        {
            //BackgroundColor = new PropertyColorBackground(TypeColorBackground.Danger),
        };

        /// <summary>
        /// Returns the page properties.
        /// </summary>
        public ControlWebAppProperty Property { get; } = new ControlWebAppProperty("webexpress-webapp-content-property");

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppContent(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var contentCtlr = new ControlPanel
            (
                Id,
                Toolbar,
                new ControlPanelFlexbox(null, MainPanel, Property)
                {
                    Layout = TypeLayoutFlexbox.Default,
                    Align = TypeAlignFlexbox.Stretch
                }
            )
            {
                Classes = ["content"],
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
            };

            return contentCtlr?.Render(renderContext, visualTree);
        }
    }
}
