﻿//using WebExpress.WebCore.Internationalization;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;
//using WebExpress.WebUI.WebControl;
//using WebExpress.WebUI.WebFragment;

//namespace WebExpress.WebApp.WebFragment
//{
//    public abstract class FragmentHeaderSettingsSystemInformation : FragmentControlDropdownItemLink
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        public FragmentHeaderSettingsSystemInformation()
//            : base()
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

//            TextColor = new PropertyColorText(TypeColorText.Dark);
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(RenderContext context)
//        {
//            Text = InternationalizationManager.I18N("webexpress.webapp:systeminformation.label");
//            Uri = context.Request.Uri.ModuleRoot.Append("settings/systeminformation");
//            //Active = context.Page is IPageSettings ? TypeActive.Active : TypeActive.None;
//            Icon = new PropertyIcon(TypeIcon.InfoCircle);

//            return base.Render(context);
//        }
//    }
//}
