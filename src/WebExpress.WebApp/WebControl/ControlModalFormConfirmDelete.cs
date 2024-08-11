using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebControl
{
    public class ControlModalFormConfirmDelete : ControlModalFormConfirm
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlModalFormConfirmDelete(string id = null)
            : this(id, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        /// <param name="content">The form controls.</param>
        public ControlModalFormConfirmDelete(string id, params ControlFormItem[] content)
            : base(id, content)
        {
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            if (string.IsNullOrWhiteSpace(Header))
            {
                Header = context.Page.I18N("webexpress.webapp", "delete.header");
            }

            if (string.IsNullOrWhiteSpace(SubmitButtonLabel))
            {
                SubmitButtonLabel = context.Page.I18N("webexpress.webapp", "delete.label");
            }

            if (Content == null)
            {
                Content = new ControlFormItemStaticText() { Text = context.Page.I18N("webexpress.webapp", "delete.description") };
            }

            if (SubmitButtonIcon == null)
            {
                SubmitButtonIcon = new PropertyIcon(TypeIcon.TrashAlt);
            }

            if (SubmitButtonColor == null)
            {
                SubmitButtonColor = new PropertyColorButton(TypeColorButton.Danger);
            }

            return base.Render(context);
        }
    }
}
