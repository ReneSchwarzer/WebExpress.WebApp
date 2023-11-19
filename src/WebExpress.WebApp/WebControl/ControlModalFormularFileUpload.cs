using System;
using System.Collections.Generic;
using WebExpress.Core.WebHtml;
using WebExpress.Core.WebMessage;
using WebExpress.Core.WebPage;
using WebExpress.WebUI.WebControl;
using static WebExpress.Core.Internationalization.InternationalizationManager;

namespace WebExpress.WebApp.WebControl
{
    public class ControlModalFormularFileUpload : ControlModalFormular
    {
        /// <summary>
        /// Returns or sets the files that are accepted.
        /// </summary>
        public ICollection<string> AcceptFile { get => File.AcceptFile; set => File.AcceptFile = value; }

        /// <summary>
        /// Event is triggered when the upload is confirmed.
        /// </summary>
        public event EventHandler<FormularUploadEventArgs> Upload;

        /// <summary>
        /// Returns or sets the document.
        /// </summary>
        public ControlFormItemInputFile File { get; } = new ControlFormItemInputFile()
        {
            Name = "file",
            Help = "webexpress.webapp:fileupload.file.description",
            //Icon = new PropertyIcon(TypeIcon.Image),
            //AcceptFile = new string[] { "image/*, video/*, audio/*, .pdf, .doc, .docx, .txt" },
            Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Three)
        };

        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public PropertyIcon ButtonIcon { get; set; }

        /// <summary>
        /// Returns or sets the button color.
        /// </summary>
        public PropertyColorButton ButtonColor { get; set; }

        /// <summary>
        /// Returns or sets the button label.
        /// </summary>
        public string ButtonLabel { get; set; }

        /// <summary>
        /// Teh prologue.
        /// </summary>
        private ControlFormItem prologue;

        /// <summary>
        /// Returns or sets the prologue area.
        /// </summary>
        public ControlFormItem Prologue
        {
            get => prologue;
            set { Formular.Items.Remove(prologue); prologue = value; Formular.Items.Insert(0, prologue); }
        }

        /// <summary>
        /// The epilogue.
        /// </summary>
        private ControlFormItem epilogue;


        /// <summary>
        /// Returns or sets the epilogue area.
        /// </summary>
        public ControlFormItem Epilogue
        {
            get => epilogue;
            set { Formular.Items.Remove(epilogue); epilogue = value; Formular.Items.Add(epilogue); }
        }

        /// <summary>
        /// Returns or sets the redirect uri.
        /// </summary>
        public string RedirectUri { get { return Formular?.RedirectUri; } set { Formular.RedirectUri = value; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlModalFormularFileUpload(string id = null)
            : this(id, null)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The control id.</param>
        /// <param name="content">Die Formularsteuerelemente</param>
        public ControlModalFormularFileUpload(string id, params ControlFormItem[] content)
            : base(id, string.Empty, content)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Header = I18N("webexpress.webapp:fileupload.header");
            ButtonLabel = I18N("webexpress.webapp:fileupload.label");
            ButtonIcon = new PropertyIcon(TypeIcon.Upload);
            ButtonColor = new PropertyColorButton(TypeColorButton.Primary);

            File.Validation += OnValidationFile;
            Formular.ProcessFormular += OnProcessFormular;

            Formular.Add(File);
        }

        /// <summary>
        /// Validation of the upload file.
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        private void OnValidationFile(object sender, ValidationEventArgs e)
        {
            if (!(e.Context.Request.GetParameter(File.Name) is ParameterFile))
            {
                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:fileupload.file.validation.error.nofile"));
            }
        }

        /// <summary>
        /// Processing of the resource. des Formulares
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        private void OnProcessFormular(object sender, FormularEventArgs e)
        {
            if (e.Context.Request.GetParameter(File.Name) is ParameterFile file)
            {
                OnUpload(new FormularUploadEventArgs(e) { File = file });
            }
        }

        /// <summary>
        /// Löst das Upload-Event aus
        /// </summary>
        /// <param name="args">The event argument.</param>
        protected virtual void OnUpload(FormularUploadEventArgs args)
        {
            Upload?.Invoke(this, args);
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            Formular.RedirectUri = RedirectUri ?? context.Uri;
            Formular.SubmitButton.Text = ButtonLabel;
            Formular.SubmitButton.Icon = ButtonIcon;
            Formular.SubmitButton.Color = ButtonColor;

            return base.Render(context);
        }
    }
}
