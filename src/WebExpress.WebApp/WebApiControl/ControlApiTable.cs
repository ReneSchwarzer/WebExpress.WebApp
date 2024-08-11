using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebApiControl
{
    public class ControlApiTable : ControlPanel, IControlApi
    {
        /// <summary>
        /// Returns or sets the uri that determines the data.
        /// </summary>
        public string RestUri { get; set; }

        /// <summary>
        /// Returns or sets the settings for the editing options (e.g. Edit, Delete, ...).
        /// </summary>
        public ControlApiTableOption OptionSettings { get; private set; } = new ControlApiTableOption();

        /// <summary>
        /// Returns or sets the editing options (e.g. Edit, Delete, ...).
        /// </summary>
        public ICollection<ControlApiTableOptionItem> OptionItems { get; private set; } = new List<ControlApiTableOptionItem>();

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlApiTable(string id = null)
            : base(id ?? Guid.NewGuid().ToString())
        {
        }

        /// <summary>
        /// Generates the javascript to control the control.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <param name="id">The id of the control.</param>
        /// <param name="css">The css classes that are assigned to the control.</param>
        /// <returns>The javascript code.</returns>
        protected virtual string GetScript(RenderContext context, string id, string css)
        {
            var settings = new
            {
                id = id,
                css = css,
                resturi = RestUri?.ToString(),
                optionsettings = OptionSettings,
                optionitems = OptionItems
            };

            var jsonOptions = new JsonSerializerOptions { WriteIndented = false };
            var settingsJson = JsonSerializer.Serialize(settings, jsonOptions);
            var builder = new StringBuilder();
            builder.AppendLine($"$(document).ready(function () {{");
            builder.AppendLine($"let settings = {settingsJson};");
            builder.AppendLine($"let container = $('#{id}');");
            builder.AppendLine($"let obj = new webexpress.webapp.tableCtrl(settings);");
            builder.AppendLine($"obj.on('webexpress.webui.change.columns', function() {{ obj.receiveData(); }});");
            builder.AppendLine($"container.replaceWith(obj.getCtrl);");
            builder.AppendLine($"}});");

            return builder.ToString();
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            var classes = Classes.ToList();

            var html = new HtmlElementTextContentDiv()
            {
                Id = Id,
                Style = GetStyles()
            };

            context.VisualTree.AddScript(Id, GetScript(context, Id, string.Join(" ", classes)));

            return html;
        }
    }
}
