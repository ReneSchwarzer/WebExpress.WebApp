using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebSection;
using WebExpress.WebApp.WebSettingPage;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.WebApp.WebFragment
{
    [Section(SectionWebApp.HeadlineSecondary)]
    [Module<Module>]
    [Scope<PageWebAppSettingUserManagementUser>]
    public sealed class FragmentUserManagementAddUser : FragmentControlButtonLink
    {
        /// <summary>
        /// Returns the modal dialog for adding a user.
        /// </summary>
        private ControlModalFormUserNew ModalDlg = new ControlModalFormUserNew("add_user");

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FragmentUserManagementAddUser()
            : base("add_user")
        {
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="page">The page where the fragment is active.</param>
        public override void Initialization(IFragmentContext context, IPage page)
        {
            base.Initialization(context, page);

            Text = "webexpress.webapp:setting.usermanager.user.add.label";
            Margin = new PropertySpacingMargin(PropertySpacing.Space.Two);
            BackgroundColor = new PropertyColorButton(TypeColorButton.Primary);
            Icon = new PropertyIcon(TypeIcon.Plus);
            Modal = new PropertyModal(TypeModal.Modal, ModalDlg);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            return base.Render(context);
        }
    }
}
