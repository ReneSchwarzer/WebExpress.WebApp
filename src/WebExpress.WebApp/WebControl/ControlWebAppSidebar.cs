using System.Collections.Generic;
using System.Linq;
using WebExpress.Core.WebHtml;
using WebExpress.Core.WebPage;
using WebExpress.WebApp.WebPage;
using WebExpress.WebUI.WebControl;

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
        public List<IControl> Header { get; protected set; } = new List<IControl>();

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
        /// Determines whether content exists
        /// </summary>
        public bool HasContent => Header.Any() || Preferences.Any() || Primary.Any() || Secondary.Any();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppSidebar(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            BackgroundColor = LayoutSchema.SidebarBackground;
            //Height = TypeHeight.OneHundred;
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            if (!HasContent)
            {
                return null;
            }

            var elements = new List<IHtmlNode>();
            elements.AddRange(Header.Select(x => x.Render(context)));
            elements.AddRange(Preferences.Select(x => x.Render(context)));
            elements.AddRange(Primary.Select(x => x.Render(context)));
            elements.AddRange(Secondary.Select(x => x.Render(context)));

            return new HtmlElementTextContentDiv(elements)
            {
                Id = Id,
                Class = Css.Concatenate("sidebar", GetClasses()),
                Style = Style.Concatenate("display: block;", GetStyles()),
                Role = Role
            };
        }
    }
}
