using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using static WebExpress.WebCore.Internationalization.InternationalizationManager;

namespace WebExpress.WebApp.WebControl
{
    public class ControlModalFormFileUpload : ControlModalForm
    {
        /// <summary>
        /// Returns or sets the files that are accepted.
        /// </summary>
        public ICollection<string> AcceptFile { get => File.AcceptFile; set => File.AcceptFile = value; }

        /// <summary>
        /// Event is triggered when the upload is confirmed.
        /// </summary>
        public event EventHandler<FormUploadEventArgs> Upload;

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
        public string SubmitButtonLabel { get { return SubmitButton?.Text; } set { SubmitButton.Text = value; } }

        /// <summary>
        /// Returns or sets the prologue area.
        /// </summary>
        public ControlFormItem Prologue { get; set; }

        /// <summary>
        /// Returns or sets the epilogue area.
        /// </summary>
        public ControlFormItem Epilogue { get; set; }

        /// <summary>
        /// Returns or sets the redirect uri.
        /// </summary>
        public string RedirectUri { get { return Form?.RedirectUri; } set { Form.RedirectUri = value; } }

        /// <summary>
        /// Returns or sets the submit button.
        /// </summary>
        private ControlFormItemButtonSubmit SubmitButton { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlModalFormFileUpload(string id = null)
            : this(id, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        /// <param name="content">The form controls.</param>
        public ControlModalFormFileUpload(string id, params ControlFormItem[] content)
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
            Header = I18N("webexpress.webapp:fileupload.header");
            SubmitButtonLabel = I18N("webexpress.webapp:fileupload.label");
            SubmitButtonIcon = new PropertyIcon(TypeIcon.Upload);
            SubmitButtonColor = new PropertyColorButton(TypeColorButton.Primary);

            File.Validation += OnValidationFile;
            Form.ProcessForm += OnProcessForm;

            Form.Add(File);
            Form.AddPrimaryButton(SubmitButton);

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
        /// Processing of the form.
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        private void OnProcessForm(object sender, FormEventArgs e)
        {
            if (e.Context.Request.GetParameter(File.Name) is ParameterFile file)
            {
                OnUpload(new FormUploadEventArgs(e) { File = file });
            }
        }

        /// <summary>
        /// Löst das Upload-Event aus
        /// </summary>
        /// <param name="args">The event argument.</param>
        protected virtual void OnUpload(FormUploadEventArgs args)
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
            Form.RedirectUri = RedirectUri ?? context.Uri;

            var list = new[] { Epilogue }
                .Concat(Form.Items)
                .Concat([Prologue]);

            return base.Render(context, list.Where(x => x != null));
        }
    }
}
