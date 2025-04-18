using System.Text.Json.Serialization;

namespace WebExpress.WebApp.WebApi
{
    /// <summary>
    /// Represents a column in a REST CRUD resource.
    /// </summary>
    public class RestApiCrudColumn
    {
        /// <summary>
        /// Returns or sets the label. der Splalte
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; }

        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        /// <summary>
        /// Returns or sets the width of the table column in percentage, null for auto.
        /// </summary>
        [JsonPropertyName("width")]
        public uint? Width { get; set; }

        /// <summary>
        /// Returns or sets the Javascript code that renders the data of the cell.
        /// </summary>
        [JsonPropertyName("render")]
        public string Render { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="label">The label of the column.</param>
        public RestApiCrudColumn(string label)
        {
            Label = label;
        }
    }
}
