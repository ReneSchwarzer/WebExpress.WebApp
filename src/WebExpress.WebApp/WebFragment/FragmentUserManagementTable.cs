﻿//using WebExpress.WebApp.WebSection;
//using WebExpress.WebApp.WebSettingPage;
//using WebExpress.WebCore.WebAttribute;
//using WebExpress.WebCore.WebComponent;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;
//using WebExpress.WebUI.WebAttribute;
//using WebExpress.WebUI.WebControl;
//using WebExpress.WebUI.WebFragment;

//namespace WebExpress.WebApp.WebFragment
//{
//    [Section(SectionWebApp.ContentPrimary)]
//    [Module<Module>]
//    [Scope<PageWebAppSettingUserManagementUser>]
//    [Cache()]
//    public sealed class FragmentUserManagementTable : FragmentCrudTable
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        public FragmentUserManagementTable()
//            : base("4fd155dd-f6e2-4411-b6ed-14ee78713272")
//        {
//        }

//        /// <summary>
//        /// Initialization
//        /// </summary>
//        /// <param name="context">The context of the component.</param>
//        /// <param name="page">The page to display the component.</param>
//        public override void Initialization(IFragmentContext context, IPage page)
//        {
//            base.Initialization(context, page);

//            var module = ComponentManager.ModuleManager.GetModule(page?.ResourceContext.ApplicationContext, typeof(Module));

//            RestApiUri = module.ContextPath.Append("/api/v1/user");

//            Editors.Add(new FragmentCrudTableEditorLinkItem("webexpress.webapp:setting.usermanager.group.edit.label") { Icon = new PropertyIcon(TypeIcon.Edit) });
//            Editors.Add(new FragmentCrudTableEditorSeperatorItem());
//            Editors.Add(new FragmentCrudTableEditorLinkItem("webexpress.webapp:setting.usermanager.group.delete.label") { Icon = new PropertyIcon(TypeIcon.TrashAlt), Color = new PropertyColorText(TypeColorText.Danger) });
//        }

//        /// <summary>
//        /// Convert to HTML.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as HTML.</returns>
//        public override IHtmlNode Render(RenderContext context)
//        {
//            return base.Render(context);
//        }
//    }
//}
