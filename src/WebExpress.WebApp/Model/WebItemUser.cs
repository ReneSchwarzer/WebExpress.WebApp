using System.Collections.Generic;

namespace WebExpress.WebApp.Model
{
    /// <summary>
    /// Represents a user in the web item context.
    /// </summary>
    public class WebItemUser : WebItem
    {
        /// <summary>
        /// Returns the label of the object.
        /// </summary>
        public override string Label => !string.IsNullOrWhiteSpace(Firstname) ? $"{Lastname}, {Firstname}" : Lastname;

        /// <summary>
        /// Returns the name of the object.
        /// </summary>
        public override string Name => Label;

        /// <summary>
        /// Returns or sets the login name.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Returns or sets the first name.
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Returns or sets the last name.
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Returns or sets the email address.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Returns or sets the groups.
        /// </summary>
        public IEnumerable<WebItemGroup> Groups { get; set; }
    }
}
