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
    /// Quick create control element for a WebApp.
    /// </summary>
    public class ControlWebAppHeaderQuickCreate : Control
    {
        /// <summary>
        /// Returns or sets the preferences area.
        /// </summary>
        public List<IControlSplitButtonItem> Preferences { get; protected set; } = new List<IControlSplitButtonItem>();

        /// <summary>
        /// Returns or sets the primary area.
        /// </summary>
        public List<IControlSplitButtonItem> Primary { get; protected set; } = new List<IControlSplitButtonItem>();

        /// <summary>
        /// Returns or sets the secondary area.
        /// </summary>
        public List<IControlSplitButtonItem> Secondary { get; protected set; } = new List<IControlSplitButtonItem>();

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppHeaderQuickCreate(string id = null)
            : base(id)
        {
            Padding = new PropertySpacingPadding(PropertySpacing.Space.Null);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var preferences = WebEx.ComponentHub.FragmentManager.GetFragments<FragmentControlSplitButtonItemLink, SectionAppQuickcreatePreferences>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var primary = WebEx.ComponentHub.FragmentManager.GetFragments<FragmentControlSplitButtonItemLink, SectionAppQuickcreatePrimary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var secondary = WebEx.ComponentHub.FragmentManager.GetFragments<FragmentControlSplitButtonItemLink, SectionAppQuickcreateSecondary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var quickcreateList = new List<IControlSplitButtonItem>(Preferences.Union(preferences));
            quickcreateList.AddRange(Primary.Union(primary));
            quickcreateList.AddRange(Secondary.Union(secondary));

            var firstQuickcreate = (quickcreateList.FirstOrDefault() as ControlLink);
            firstQuickcreate?.Render(renderContext, visualTree);

            var quickcreate = (quickcreateList.Count > 1) ?
            (IControl)new ControlSplitButtonLink(Id, quickcreateList.Skip(1).ToArray())
            {
                Text = I18N.Translate(renderContext.Request?.Culture, "webexpress.webapp:header.quickcreate.label"),
                Uri = firstQuickcreate?.Uri,
                //BackgroundColor = LayoutSchema.HeaderQuickCreateButtonBackground,
                //Size = LayoutSchema.HeaderQuickCreateButtonSize,
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Auto, PropertySpacing.Space.None),
                OnClick = firstQuickcreate?.OnClick,
                Modal = firstQuickcreate?.Modal
            } :
            (Preferences.Count > 0) ?
            new ControlButtonLink(Id)
            {
                Text = I18N.Translate(renderContext.Request?.Culture, "webexpress.webapp:header.quickcreate.label"),
                Uri = firstQuickcreate?.Uri,
                //BackgroundColor = LayoutSchema.HeaderQuickCreateButtonBackground,
                //Size = LayoutSchema.HeaderQuickCreateButtonSize,
                //Margin = new PropertySpacingMargin(PropertySpacing.Space.Auto, PropertySpacing.Space.None),
                OnClick = firstQuickcreate?.OnClick,
                Modal = firstQuickcreate?.Modal
            } :
            null;

            return quickcreate?.Render(renderContext, visualTree);
        }
    }
}
