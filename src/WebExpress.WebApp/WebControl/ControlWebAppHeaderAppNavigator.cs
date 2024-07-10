using System.Collections.Generic;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

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
        public List<IControlDropdownItem> Preferences { get; protected set; } = new List<IControlDropdownItem>();

        /// <summary>
        /// Returns or sets the primary area.
        /// </summary>
        public List<IControlDropdownItem> Primary { get; protected set; } = new List<IControlDropdownItem>();

        /// <summary>
        /// Returns or sets the secondary area.
        /// </summary>
        public List<IControlDropdownItem> Secondary { get; protected set; } = new List<IControlDropdownItem>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppHeaderAppNavigator(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Padding = new PropertySpacingPadding(PropertySpacing.Space.Null);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            var application = ComponentManager.ApplicationManager.GetApplcation(context.Page?.ResourceContext.ApplicationContext?.ApplicationId);

            var hamburger = new List<IControlDropdownItem>
            {
                new ControlDropdownItemHeader() { Text = context.I18N(context.Page?.ResourceContext.ApplicationContext, context.Page?.ResourceContext.ApplicationContext?.ApplicationName) }
            };

            hamburger.AddRange(Primary);

            if (Primary.Count > 0 && Secondary.Count > 0)
            {
                hamburger.Add(new ControlDropdownItemDivider());
            }

            hamburger.AddRange(Secondary);

            var logo = (hamburger.Count > 1) ?
            (IControl)new ControlDropdown("webexpress.webapp.header.icon", hamburger)
            {
                Image = application?.Icon,
                Height = 50,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None),
                Styles = new List<string>() { "padding: 0.5em;" }
            } :
            new ControlImage("webexpress.webapp.header.icon")
            {
                Uri = application?.Icon,
                Height = 50,
                Padding = new PropertySpacingPadding(PropertySpacing.Space.Two),
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None)
            };

            return logo?.Render(context);
        }
    }
}
