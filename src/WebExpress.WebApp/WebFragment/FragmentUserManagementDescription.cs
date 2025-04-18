﻿//using WebExpress.WebApp.WebSection;
//using WebExpress.WebApp.WebSettingPage;
//using WebExpress.WebCore.WebAttribute;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;
//using WebExpress.WebUI.WebAttribute;
//using WebExpress.WebUI.WebControl;
//using WebExpress.WebUI.WebFragment;

//namespace WebExpress.WebApp.WebFragment
//{
//    [Section(SectionWebApp.ContentPreferences)]
//    [Module<Module>]
//    [Scope<PageWebAppSettingUserManagementUser>]
//    [Cache()]
//    public sealed class FragmentUserManagementDescription : FragmentControlPanel
//    {
//        /// <summary>
//        /// Returns the label.
//        /// </summary>
//        private ControlText Label { get; } = new ControlText()
//        {
//            Text = "webexpress.webapp:setting.usermanager.user.help",
//            Margin = new PropertySpacingMargin(PropertySpacing.Space.Two),
//            TextColor = new PropertyColorText(TypeColorText.Info)
//        };

//        /// <summary>
//        /// Returns the description.
//        /// </summary>
//        private ControlText Description { get; } = new ControlText()
//        {
//            Text = "webexpress.webapp:setting.usermanager.user.description",
//            Margin = new PropertySpacingMargin(PropertySpacing.Space.Two)
//        };

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        public FragmentUserManagementDescription()
//        {
//        }

//        /// <summary>
//        /// Initialization
//        /// </summary>
//        /// <param name="context">The context.</param>
//        /// <param name="page">The page where the fragment is active.</param>
//        public override void Initialization(IFragmentContext context, IPage page)
//        {
//            base.Initialization(context, page);

//            Content.Add(Label);
//            Content.Add(Description);
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(RenderContext context)
//        {
//            return base.Render(context);
//        }
//    }
//}
