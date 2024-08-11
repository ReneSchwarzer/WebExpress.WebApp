using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebPage;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

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
        public List<IControl> Preferences { get; protected set; } = new List<IControl>();

        /// <summary>
        /// Returns or sets the primary area.
        /// </summary>
        public List<IControl> Primary { get; protected set; } = new List<IControl>();

        /// <summary>
        /// Returns or sets the secondary area.
        /// </summary>
        public List<IControl> Secondary { get; protected set; } = new List<IControl>();

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppFooter(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            BackgroundColor = LayoutSchema.FooterBackground;
            TextColor = LayoutSchema.FooterText;
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            var elements = new List<IHtmlNode>
            {
                new HtmlElementTextContentDiv(Preferences.Select(x => x.Render(context))),
                new HtmlElementTextContentDiv(Primary.Select(x => x.Render(context))) { Class = "justify-content-center" },
                new HtmlElementTextContentDiv(Secondary.Select(x => x.Render(context)))
            };

            return new HtmlElementTextContentDiv(elements)
            {
                Id = Id,
                Class = Css.Concatenate("footer", GetClasses()),
                Style = Style.Concatenate("", GetStyles()),
                Role = Role
            };
        }
    }
}
