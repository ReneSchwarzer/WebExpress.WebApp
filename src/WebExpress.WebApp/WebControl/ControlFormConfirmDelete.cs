//using WebExpress.WebCore.Internationalization;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;
//using WebExpress.WebUI.WebControl;

//namespace WebExpress.WebApp.WebControl
//{
//    public class ControlFormConfirmDelete : ControlFormConfirm
//    {
//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The control id.</param>
//        public ControlFormConfirmDelete()
//            : this(null)
//        {
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The control id.</param>
//        public ControlFormConfirmDelete(string id = null)
//            : base(id)
//        {
//            SubmitButtonIcon = new PropertyIcon(TypeIcon.TrashAlt);
//            SubmitButtonColor = new PropertyColorButton(TypeColorButton.Danger);
//        }

//        /// <summary>
//        /// Initializes the form.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        public override void Initialize(RenderContextForm context)
//        {
//            base.Initialize(context);

//            SubmitButtonLabel = context.Page.I18N("webexpress.webapp", "delete.label");
//            Content.Text = context.Page.I18N("webexpress.webapp", "delete.description");
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(RenderContext context)
//        {
//            SubmitButtonLabel = context.Page.I18N("webexpress.webapp", "delete.label");

//            return base.Render(context);
//        }
//    }
//}
