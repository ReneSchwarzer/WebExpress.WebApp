//using System;
//using WebExpress.WebApp.WebNotificaation;
//using WebExpress.WebApp.WebSettingPage;
//using WebExpress.WebCore.Internationalization;
//using WebExpress.WebCore.WebComponent;
//using WebExpress.WebCore.WebResource;
//using WebExpress.WebUI.WebControl;

//namespace WebExpress.WebApp.WebPage
//{
//    /// <summary>
//    /// A form based page.
//    /// </summary>
//    public abstract class PageWebAppSettingForm<T> : PageWebAppSetting where T : ControlForm, new()
//    {
//        /// <summary>
//        /// Returns the form.
//        /// </summary>
//        protected T Form { get; private set; }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        public PageWebAppSettingForm()
//        {
//            Form = new T();
//        }

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The page id.</param>
//        public PageWebAppSettingForm(string id)
//        {
//            Form = Activator.CreateInstance(typeof(T), id) as T;
//        }

//        /// <summary>
//        /// Initialization
//        /// </summary>
//        /// <param name="context">The context.</param>
//        public override void Initialization(IResourceContext context)
//        {
//            base.Initialization(context);

//            Form.InitializeForm += OnInitializeForm;
//            Form.FillForm += OnFillForm;
//            Form.ProcessForm += OnProcessForm;
//        }

//        /// <summary>
//        /// Invoked when the form is initialized.
//        /// </summary>
//        /// <param name="sender">The trigger of the event.</param>
//        /// <param name="e">The event argument.</param>
//        protected virtual void OnInitializeForm(object sender, FormEventArgs e)
//        {
//        }

//        /// <summary>
//        /// Invoked when the form is about to be populated.
//        /// </summary>
//        /// <param name="sender">The trigger of the event.</param>
//        /// <param name="e">The event argument.</param>
//        protected virtual void OnFillForm(object sender, FormEventArgs e)
//        {
//        }

//        /// <summary>
//        /// Fired when the form is about to be processed.
//        /// </summary>
//        /// <param name="sender">The trigger of the event.</param>
//        /// <param name="e">The event argument./param>
//        protected virtual void OnProcessForm(object sender, FormEventArgs e)
//        {
//        }

//        /// <summary>
//        /// Returns the redirect uri.
//        /// </summary>
//        /// <returns>The redirect uri.</returns>
//        protected string SetRedirectUri()
//        {
//            return Form.RedirectUri;
//        }

//        /// <summary>
//        /// Sets the redirect uri.
//        /// </summary>
//        /// <param name="redirectUri">The redirect uri.</param>
//        protected void SetRedirectUri(string redirectUri)
//        {
//            Form.RedirectUri = redirectUri;
//        }

//        /// <summary>
//        /// Creates an notification.
//        /// </summary>
//        /// <param name="context">The context.</param>
//        /// <param name="title">The notification tiltle.</param>
//        /// <param name="text">The notification message.</param>
//        /// <param name="color">The notification color.</param>
//        /// <param name="image">The image.</param>
//        protected void AddNotification(RenderContextForm context, string title, string text, PropertyColorText color, string image)
//        {
//            ComponentManager.GetComponent<NotificationManager>()?.AddNotification
//            (
//                request: context.Request,
//                message: string.Format
//                (
//                    InternationalizationManager.I18N(Culture, title),
//                    new ControlText()
//                    {
//                        Text = text,
//                        TextColor = color,
//                        Format = TypeFormatText.Span
//                    }.Render(context).ToString().Trim()
//                ),
//                icon: image,
//                durability: 10000
//            );
//        }

//        /// <summary>
//        /// Processing of the resource.
//        /// </summary>
//        /// <param name="context">The context for rendering the page.</param>
//        public override void Process(RenderContextWebApp context)
//        {
//            base.Process(context);

//            context.VisualTree.Content.Primary.Add(Form);
//        }
//    }
//}
