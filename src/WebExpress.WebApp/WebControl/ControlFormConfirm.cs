//using System;
//using WebExpress.WebCore.Internationalization;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;
//using WebExpress.WebUI.WebControl;

//namespace WebExpress.WebApp.WebControl
//{
//    public class ControlFormConfirm : ControlForm
//    {
//        /// <summary>
//        /// Event is triggered when deletion is confirmed.
//        /// </summary>
//        public event EventHandler<FormEventArgs> Confirm;

//        /// <summary>
//        /// Returns or sets the submit button icon.
//        /// </summary>
//        public PropertyIcon SubmitButtonIcon { get => SubmitButton.Icon; set => SubmitButton.Icon = value; }

//        /// <summary>
//        /// Returns or sets the submit button color.
//        /// </summary>
//        public PropertyColorButton SubmitButtonColor { get => SubmitButton.Color; set => SubmitButton.Color = value; }

//        /// <summary>
//        /// Returns or sets the submit button label.
//        /// </summary>
//        public string SubmitButtonLabel { get => SubmitButton.Text; set => SubmitButton.Text = value; }

//        /// <summary>
//        /// Returns or sets the submit button.
//        /// </summary>
//        private ControlFormItemButtonSubmit SubmitButton { get; set; }

//        /// <summary>
//        /// Returns or sets the content.
//        /// </summary>
//        public ControlFormItemStaticText Content { get; } = new ControlFormItemStaticText()
//        {
//        };

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The control id.</param>
//        public ControlFormConfirm(string id = null)
//            : base(id, null)
//        {
//            SubmitButton = new ControlFormItemButtonSubmit("submit");
//            SubmitButtonColor = new PropertyColorButton(TypeColorButton.Primary);
//        }

//        /// <summary>
//        /// Triggers the confirm event.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        protected virtual void OnConfirm(RenderContextForm context)
//        {
//            Confirm?.Invoke(this, new FormEventArgs() { Context = context });
//        }

//        /// <summary>
//        /// Initializes the form.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        public override void Initialize(RenderContextForm context)
//        {
//            base.Initialize(context);

//            SubmitButtonLabel = context.Page.I18N("webexpress.webapp", "confirm.label");
//            Content.Text = context.Page.I18N("webexpress.webapp", "confirm.description");

//            Add(Content);
//        }

//        /// <summary>
//        /// Triggers the crocess event.
//        /// </summary>
//        /// <param name="context">The render context.</param>
//        protected override void OnProcess(RenderContextForm context)
//        {
//            base.OnProcess(context);

//            OnConfirm(context);
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
