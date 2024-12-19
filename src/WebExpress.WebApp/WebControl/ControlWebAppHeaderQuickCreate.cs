//using System.Collections.Generic;
//using System.Linq;
//using WebExpress.WebCore.Internationalization;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;
//using WebExpress.WebApp.WebPage;
//using WebExpress.WebUI.WebControl;

//namespace WebExpress.WebApp.WebControl
//{
//    /// <summary>
//    /// Quick create control element for a WebApp.
//    /// </summary>
//    public class ControlWebAppHeaderQuickCreate : Control
//    {
//        /// <summary>
//        /// Returns or sets the preferences area.
//        /// </summary>
//        public List<IControlSplitButtonItem> Preferences { get; protected set; } = new List<IControlSplitButtonItem>();

//        /// <summary>
//        /// Returns or sets the primary area.
//        /// </summary>
//        public List<IControlSplitButtonItem> Primary { get; protected set; } = new List<IControlSplitButtonItem>();

//        /// <summary>
//        /// Returns or sets the secondary area.
//        /// </summary>
//        public List<IControlSplitButtonItem> Secondary { get; protected set; } = new List<IControlSplitButtonItem>();

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The control id.</param>
//        public ControlWebAppHeaderQuickCreate(string id = null)
//            : base(id)
//        {
//            Init();
//        }

//        /// <summary>
//        /// Initialization
//        /// </summary>
//        private void Init()
//        {
//            Padding = new PropertySpacingPadding(PropertySpacing.Space.Null);
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(RenderContext context)
//        {
//            var quickcreateList = new List<IControlSplitButtonItem>(Preferences);
//            quickcreateList.AddRange(Primary);
//            quickcreateList.AddRange(Secondary);

//            var firstQuickcreate = (quickcreateList.FirstOrDefault() as ControlLink);
//            firstQuickcreate?.Render(context);

//            var quickcreate = (quickcreateList.Count > 1) ?
//            (IControl)new ControlSplitButtonLink(Id, quickcreateList.Skip(1))
//            {
//                Text = context.I18N("webexpress.webapp", "header.quickcreate.label"),
//                Uri = firstQuickcreate?.Uri,
//                BackgroundColor = LayoutSchema.HeaderQuickCreateButtonBackground,
//                Size = LayoutSchema.HeaderQuickCreateButtonSize,
//                Margin = new PropertySpacingMargin(PropertySpacing.Space.Auto, PropertySpacing.Space.None),
//                OnClick = firstQuickcreate?.OnClick,
//                Modal = firstQuickcreate?.Modal
//            } :
//            (Preferences.Count > 0) ?
//            new ControlButtonLink(Id)
//            {
//                Text = context.I18N("webexpress.webapp", "header.quickcreate.label"),
//                Uri = firstQuickcreate?.Uri,
//                BackgroundColor = LayoutSchema.HeaderQuickCreateButtonBackground,
//                Size = LayoutSchema.HeaderQuickCreateButtonSize,
//                Margin = new PropertySpacingMargin(PropertySpacing.Space.Auto, PropertySpacing.Space.None),
//                OnClick = firstQuickcreate?.OnClick,
//                Modal = firstQuickcreate?.Modal
//            } :
//            null;

//            return quickcreate?.Render(context);
//        }
//    }
//}
