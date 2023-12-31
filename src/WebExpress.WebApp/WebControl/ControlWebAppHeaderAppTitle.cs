﻿using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebApp.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// App title for a web app.
    /// </summary>
    public class ControlWebAppHeaderAppTitle : ControlLink
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppHeaderAppTitle(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Decoration = TypeTextDecoration.None;
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            var apptitle = new ControlText()
            {
                Text = context.I18N(context.ApplicationContext, context.ApplicationContext?.ApplicationName),
                TextColor = LayoutSchema.HeaderTitle,
                Format = TypeFormatText.H1,
                Padding = new PropertySpacingPadding(PropertySpacing.Space.One),
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.Null)
            };

            return new HtmlElementTextSemanticsA(apptitle.Render(context))
            {
                Id = Id,
                Href = context?.Page?.ApplicationContext?.ContextPath?.ToString(),
                Class = Css.Concatenate("", GetClasses()),
                Style = Style.Concatenate("", GetStyles()),
                Role = Role
            };
        }
    }
}
