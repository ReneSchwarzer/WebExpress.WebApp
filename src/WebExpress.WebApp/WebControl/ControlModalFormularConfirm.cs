using System;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebControl
{
    public class ControlModalFormularConfirm : ControlModalFormular
    {
        /// <summary>
        /// Event is triggered when deletion is confirmed.
        /// </summary>
        public event EventHandler<FormularEventArgs> Confirm;

        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public PropertyIcon ButtonIcon { get; set; }

        /// <summary>
        /// Returns or sets the color. der Schaltfläche
        /// </summary>
        public PropertyColorButton ButtonColor { get; set; }

        /// <summary>
        /// Returns or sets the label. der Schaltfläche
        /// </summary>
        public string ButtonLabel { get; set; }

        /// <summary>
        /// Returns or sets the content.
        /// </summary>
        public new ControlFormItem Content { get; set; }

        /// <summary>
        /// Returns or sets the redirect uri.
        /// </summary>
        public string RedirectUri { get { return Formular?.RedirectUri; } set { Formular.RedirectUri = value; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id.</param>
        public ControlModalFormularConfirm(string id = null)
            : this(id, null)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="content">Die Formularsteuerelemente</param>
        public ControlModalFormularConfirm(string id, params ControlFormItem[] content)
            : base(id, string.Empty, content)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Formular.ProcessFormular += (s, e) =>
            {
                OnConfirm(e.Context);
            };
        }

        /// <summary>
        /// Triggers the Confirm event.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        protected virtual void OnConfirm(RenderContextFormular context)
        {
            Confirm?.Invoke(this, new FormularEventArgs() { Context = context });
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

            return Render(context, content);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <param name="items">The formular items.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context, params ControlFormItem[] items)
        {
            if (string.IsNullOrWhiteSpace(Header))
            {
                Header = context.Page.I18N("webexpress.webapp", "confirm.header");
            }

            if (string.IsNullOrWhiteSpace(ButtonLabel))
            {
                ButtonLabel = context.Page.I18N("webexpress.webapp", "confirm.label");
            }

            if (ButtonColor == null)
            {
                ButtonColor = new PropertyColorButton(TypeColorButton.Primary);
            }

            Formular.RedirectUri = RedirectUri ?? context.Uri;
            Formular.SubmitButton.Text = ButtonLabel;
            Formular.SubmitButton.Icon = ButtonIcon;
            Formular.SubmitButton.Color = ButtonColor;

            return base.Render(context, items);
        }
    }
}
