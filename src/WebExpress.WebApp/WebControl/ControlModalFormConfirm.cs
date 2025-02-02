﻿using System;
using System.Collections.Generic;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

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
        public ControlModalFormConfirm(string id = null, params ControlFormItem[] content)
            : base(id, content)
        {
            SubmitButton = new ControlFormItemButtonSubmit("submit");

            Form.ProcessForm += (s, e) =>
            {
                OnConfirm(e.Context);
            };

            Form.AddPrimaryButton(SubmitButton);
        }

        /// <summary>
        /// Triggers the confirm event.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        protected virtual void OnConfirm(IRenderControlFormContext context)
        {
            Confirm?.Invoke(this, new FormEventArgs() { Context = context });
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var content = Content ?? new ControlFormItemStaticText()
            {
                Text = I18N.Translate(renderContext.Request, "webexpress.webapp:confirm.description")
            };

            return Render(renderContext, visualTree, [content]);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <param name="items">The form items.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree, IEnumerable<ControlFormItem> items)
        {
            if (string.IsNullOrWhiteSpace(Header))
            {
                Header = I18N.Translate(renderContext.Request, "webexpress.webapp:confirm.header");
            }

            if (string.IsNullOrWhiteSpace(SubmitButtonLabel))
            {
                SubmitButtonLabel = I18N.Translate(renderContext.Request, "webexpress.webapp:confirm.label");
            }

            Form.RedirectUri = RedirectUri ?? renderContext.Request.Uri;

            return base.Render(renderContext, visualTree, items);
        }
    }
}
