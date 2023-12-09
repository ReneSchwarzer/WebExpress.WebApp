using System;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebApp.WebUser;
using WebExpress.WebUI.WebControl;
using static WebExpress.WebCore.Internationalization.InternationalizationManager;

namespace WebExpress.WebApp.WebControl
{
    internal sealed class ControlModalFormularGroupDelete : ControlModalFormularConfirmDelete
    {
        /// <summary>
        /// Returns or sets the group to be edited.
        /// </summary>
        public Group Item { get; set; }

        /// <summary>
        /// Returns the description.
        /// </summary>
        private ControlFormItemStaticText Description { get; } = new ControlFormItemStaticText();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlModalFormularGroupDelete(string id = null)
            : base("delete_" + id)
        {
            Confirm += OnConfirm;

            Header = "webexpress.webapp:setting.usermanager.group.delete.header";
            Content = Description;
        }

        /// <summary>
        /// Invoked when the deletion is confirmed.
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnConfirm(object sender, FormularEventArgs e)
        {
            UserManager.RemoveGroup(Item);

            e.Context.Page.Redirecting(e.Context.Uri);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            Description.Text = string.Format(I18N(context.Culture, "webexpress.webapp:setting.usermanager.group.delete.description"), Item.Name);

            return base.Render(context);
        }
    }
}
