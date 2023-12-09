using System.Collections.Generic;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// Help control for a WebApp.
    /// </summary>
    public class ControlWebAppHeaderHelp : Control
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
        /// <param name="id">The controls id.</param>
        public ControlWebAppHeaderHelp(string id = null)
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
            var helpList = new List<IControlDropdownItem>
            {
                new ControlDropdownItemHeader() { Text = context.I18N("webexpress.webapp", "header.help.label") }
            };

            helpList.AddRange(Preferences);
            if (Preferences.Count > 0 && Primary.Count > 0)
            {
                helpList.Add(new ControlDropdownItemDivider());
            }

            helpList.AddRange(Primary);
            if (Primary.Count > 0 && Secondary.Count > 0)
            {
                helpList.Add(new ControlDropdownItemDivider());
            }

            helpList.AddRange(Secondary);

            var help = (helpList.Count > 1) ?
            new ControlDropdown(Id, helpList)
            {
                Icon = new PropertyIcon(TypeIcon.InfoCircle),
                AlignmentMenu = TypeAlignmentDropdownMenu.Right,
                BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None)
            } :
            null;

            return help?.Render(context);
        }
    }
}
