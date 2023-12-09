using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebApp.WebPage;
using WebExpress.WebUI.WebControl;

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
        /// Constructor
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppProperty(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            BackgroundColor = LayoutSchema.PropertyBackground;
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            if (Preferences.Count == 0 && Primary.Count == 0 && Secondary.Count == 0)
            {
                return null;
            }

            var preferences = new HtmlElementTextContentDiv(Preferences.Select(x => x.Render(context)));
            var primary = new HtmlElementTextContentDiv(Primary.Select(x => x.Render(context)));
            var secondary = new HtmlElementTextContentDiv(Secondary.Select(x => x.Render(context)));

            return new HtmlElementTextContentDiv(preferences, primary, secondary)
            {
                Id = Id,
                Class = Css.Concatenate("proterty", GetClasses()),
                Style = GetStyles(),
                Role = Role
            };
        }
    }
}
