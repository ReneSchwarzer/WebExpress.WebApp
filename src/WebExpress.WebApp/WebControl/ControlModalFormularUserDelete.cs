using WebExpress.Core.WebHtml;
using WebExpress.Core.WebPage;
using WebExpress.WebApp.WebUser;
using WebExpress.WebUI.WebControl;
using static WebExpress.Core.Internationalization.InternationalizationManager;

namespace WebExpress.WebApp.WebControl
{
    internal sealed class ControlModalFormularUserDelete : ControlModalFormularConfirmDelete
    {
        /// <summary>
        /// Returns or sets the user to be deleted.
        /// </summary>
        public User Item { get; set; }

        /// <summary>
        /// Returns the description.
        /// </summary>
        private ControlFormItemStaticText Description { get; } = new ControlFormItemStaticText();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlModalFormularUserDelete(string id = null)
            : base("delete_" + id)
        {
            Confirm += OnConfirm;

            Header = "webexpress.webapp:setting.usermanager.user.delete.header";
            Content = Description;
        }

        /// <summary>
        /// Invoked when the deletion is confirmed.
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        private void OnConfirm(object sender, FormularEventArgs e)
        {
            UserManager.RemoveUser(Item);

            e.Context.Page.Redirecting(e.Context.Uri);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            Description.Text = string.Format(I18N(context.Culture, "webexpress.webapp:setting.usermanager.user.delete.description"), Item.Login);

            return base.Render(context);
        }
    }
}
