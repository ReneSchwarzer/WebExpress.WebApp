using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// App navigator for a WebApp.
    /// </summary>
    public class ControlWebAppHeaderAppNavigator : Control
    {
        /// <summary>
        /// Returns or sets the preferences area.
        /// </summary>
        public IEnumerable<IControlDropdownItem> Preferences { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the primary area.
        /// </summary>
        public IEnumerable<IControlDropdownItem> Primary { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the secondary area.
        /// </summary>
        public IEnumerable<IControlDropdownItem> Secondary { get; protected set; } = [];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppHeaderAppNavigator(string id = null)
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
            var application = renderContext?.PageContext?.ApplicationContext;

            var hamburger = new List<IControlDropdownItem>
            {
                new ControlDropdownItemHeader() { Text = I18N.Translate(renderContext.Request.Culture, application?.ApplicationName) }
            };

            hamburger.AddRange(Primary);

            if (Primary.Count() > 0 && Secondary.Count() > 0)
            {
                hamburger.Add(new ControlDropdownItemDivider());
            }

            hamburger.AddRange(Secondary);

            var logo = (hamburger.Count > 1) ?
            (IControl)new ControlDropdown(Id, hamburger.ToArray())
            {
                Image = application?.Icon,
                Height = 50,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None),
                Styles = ["padding: 0.5em;"]
            } :
            new ControlImage(Id)
            {
                Uri = application?.Icon,
                Height = 50,
                Padding = new PropertySpacingPadding(PropertySpacing.Space.Two),
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
            };

            return logo?.Render(renderContext);
        }
    }
}
