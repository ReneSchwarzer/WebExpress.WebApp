using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// App title for a web app.
    /// </summary>
    public class ControlWebAppHeaderAppTitle : ControlLink
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppHeaderAppTitle(string id = null)
            : base(id)
        {
            Decoration = TypeTextDecoration.None;
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            var apptitle = new ControlText()
            {
                Text = I18N.Translate(renderContext.Request.Culture, renderContext.PageContext?.ApplicationContext?.ApplicationName),
                //TextColor = LayoutSchema.HeaderTitle,
                Format = TypeFormatText.H1,
                Padding = new PropertySpacingPadding(PropertySpacing.Space.One),
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.Null)
            };

            return new HtmlElementTextSemanticsA(apptitle.Render(renderContext))
            {
                Id = Id,
                Href = renderContext?.PageContext?.ApplicationContext?.ContextPath?.ToString(),
                Class = Css.Concatenate("", GetClasses()),
                Style = Style.Concatenate("", GetStyles()),
                Role = Role
            };
        }
    }
}
