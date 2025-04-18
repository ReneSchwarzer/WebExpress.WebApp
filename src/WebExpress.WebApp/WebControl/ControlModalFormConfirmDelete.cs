﻿using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// Represents a modal confirmation form specifically for delete actions.
    /// </summary>
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
            SubmitButtonIcon = new IconTrash();
            SubmitButtonColor = new PropertyColorButton(TypeColorButton.Danger);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            if (string.IsNullOrWhiteSpace(Header))
            {
                Header = I18N.Translate(renderContext, "webexpress.webapp:delete.header");
            }

            SubmitButtonLabel ??= I18N.Translate(renderContext, "webexpress.webapp:delete.label");
            Content ??= new ControlFormItemStaticText() { Text = I18N.Translate(renderContext, "webexpress.webapp:delete.description") };

            return base.Render(renderContext, visualTree);
        }
    }
}
