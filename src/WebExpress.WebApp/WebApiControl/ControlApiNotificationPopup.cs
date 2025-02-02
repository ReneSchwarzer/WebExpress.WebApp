using System;
using System.Text;
using System.Text.Json;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebApp.WebApiControl
{
    /// <summary>
    /// Represents a control for displaying notification popups via API.
    /// </summary>
    public class ControlApiNotificationPopup : Control
    {
        private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = false };

        /// <summary>
        /// Initializes a new instance of the <see cref="ControlApiNotificationPopup"/> class.
        /// </summary>
        /// <param name="id">The optional identifier for the control. If not provided, a new GUID will be generated.</param>
        public ControlApiNotificationPopup(string id = null)
            : base(id ?? Guid.NewGuid().ToString())
        {
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var applicationContext = renderContext?.PageContext?.ApplicationContext;
            var settings = new
            {
                id = "26E517F5-56F7-485E-A212-6033618708F3",
                resturi = applicationContext?.ContextPath.Append("api/1/popupnotifications")?.ToString(),
                intervall = 15000
            };

            var settingsJson = JsonSerializer.Serialize(settings, _jsonOptions);
            var builder = new StringBuilder();

            builder.AppendLine($"$(document).ready(function () {{");
            builder.AppendLine($"let settings = {settingsJson};");
            builder.AppendLine($"let container = $('#{settings.id}');");
            builder.AppendLine($"let obj = new webexpress.webapp.popupNotificationCtrl(settings);");
            builder.AppendLine($"container.replaceWith(obj.getCtrl);");
            builder.AppendLine($"}});");

            visualTree.AddScript("webexpress.webapp:controlapinotificationpopup", builder.ToString());

            var ctrl = new ControlPanel(settings.id)
            {
                Classes = ["popupnotification"]
            };

            return ctrl.Render(renderContext, visualTree);
        }
    }
}
