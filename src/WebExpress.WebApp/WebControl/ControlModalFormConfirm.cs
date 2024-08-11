using System;
using System.Collections.Generic;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// Represents a modal confirmation form.
    /// </summary>
    public class ControlModalFormConfirm : ControlModalForm
    {
        /// <summary>
        /// Event is triggered when deletion is confirmed.
        /// </summary>
        public event EventHandler<FormEventArgs> Confirm;

        /// <summary>
        /// Returns or sets the submit button icon.
        /// </summary>
        public PropertyIcon SubmitButtonIcon { get { return SubmitButton?.Icon; } set { SubmitButton.Icon = value; } }

        /// <summary>
        /// Returns or sets the submit button color.
        /// </summary>
        public PropertyColorButton SubmitButtonColor { get { return SubmitButton?.Color; } set { SubmitButton.Color = value; } }

        /// <summary>
        /// Returns or sets the submit button label.
        /// </summary>
        public string SubmitButtonLabel { get; set; }

        /// <summary>
        /// Returns or sets the content.
        /// </summary>
        public new ControlFormItem Content { get; set; }

        /// <summary>
        /// Returns or sets the submit button.
        /// </summary>
        private ControlFormItemButtonSubmit SubmitButton { get; set; }

        /// <summary>
        /// Returns or sets the redirect uri.
        /// </summary>
        public string RedirectUri { get { return Form?.RedirectUri; } set { Form.RedirectUri = value; } }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id.</param>
        public ControlModalFormConfirm(string id = null)
            : this(id, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="content">The form controls.</param>
        public ControlModalFormConfirm(string id, params ControlFormItem[] content)
            : base(id, string.Empty, content)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            SubmitButton = new ControlFormItemButtonSubmit("submit");

            Form.ProcessForm += (s, e) =>
            {
                OnConfirm(e.Context);
            };

            Form.AddPrimaryButton(SubmitButton);
        }

        /// <summary>
        /// Triggers the Confirm event.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        protected virtual void OnConfirm(RenderContextForm context)
        {
            Confirm?.Invoke(this, new FormEventArgs() { Context = context });
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            var content = Content ?? new ControlFormItemStaticText()
            {
                Text = context.Page.I18N("webexpress.webapp", "confirm.description")
            };

            return Render(context, [content]);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <param name="items">The form items.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context, IEnumerable<ControlFormItem> items)
        {
            if (string.IsNullOrWhiteSpace(Header))
            {
                Header = context.Page.I18N("webexpress.webapp", "confirm.header");
            }

            if (string.IsNullOrWhiteSpace(SubmitButtonLabel))
            {
                SubmitButtonLabel = context.Page.I18N("webexpress.webapp", "confirm.label");
            }

            Form.RedirectUri = RedirectUri ?? context.Uri;

            return base.Render(context, items);
        }
    }
}
