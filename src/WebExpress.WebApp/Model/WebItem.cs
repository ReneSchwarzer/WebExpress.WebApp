using System;
using System.Text.Json.Serialization;
using WebExpress.WebIndex;
using WebExpress.WebIndex.WebAttribute;

namespace WebExpress.WebApp.Model
{
    public class WebItem : IIndexItem
    {
        /// <summary>
        /// Returns or sets the id.
        /// </summary>
        [JsonPropertyName("id")]
        [IndexIgnore]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Returns or sets the uri of the web item.
        /// </summary>
        [JsonPropertyName("uri")]
        public virtual string Uri { get; set; }

        /// <summary>
        /// Returns or sets the label of the web item.
        /// </summary>
        [JsonPropertyName("label")]
        public virtual string Label { get; set; }

        /// <summary>
        /// Returns or sets the name of the web item.
        /// </summary>
        [JsonPropertyName("name")]
        public virtual string Name { get; set; }

        /// <summary>
        /// Returns or sets the image uri of the web item.
        /// </summary>
        [JsonPropertyName("image")]
        public virtual string Image { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public WebItem()
        {
        }

        /// <summary>
        /// Copy-Constructor
        /// Creates a deep copy.
        /// </summary>
        /// <param name="item">The web item to be copied.</param>
        public WebItem(WebItem item)
        {
            Id = item.Id;
            Uri = item.Uri;
            Label = item.Label;
            Name = item.Name;
            Image = item.Image;
        }

        /// <summary>
        /// Conversion to string.
        /// </summary>
        /// <returns>The object in its string representation.</returns>
        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}
