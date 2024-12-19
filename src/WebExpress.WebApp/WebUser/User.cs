//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Xml.Serialization;
//using WebExpress.WebIndex;

//namespace WebExpress.WebApp.WebUser
//{
//    public class User : IIndexItem
//    {
//        /// <summary>
//        /// Returns or sets the id.
//        /// </summary>
//        [XmlAttribute("id")]
//        public Guid Id { get; set; }

//        /// <summary>
//        /// Returns or sets the login id.
//        /// </summary>
//        [XmlAttribute("login")]
//        public string Login { get; set; }

//        /// <summary>
//        /// Returns or sets the name.
//        /// </summary>
//        [XmlAttribute("firstname")]
//        public string Firstname { get; set; }

//        /// <summary>
//        /// Returns or sets the name.
//        /// </summary>
//        [XmlAttribute("lastname")]
//        public string Lastname { get; set; }

//        /// <summary>
//        /// Returns or sets the email address.
//        /// </summary>
//        [XmlAttribute("email")]
//        public string Email { get; set; }

//        /// <summary>
//        /// Returns or sets the password.
//        /// </summary>
//        [XmlAttribute("password")]
//        public string Password { get; set; }

//        /// <summary>
//        /// Returns or sets the group ids
//        /// </summary>
//        [XmlElement("groups")]
//        public List<string> GroupIds { get; set; } = new List<string>();

//        /// <summary>
//        /// Returns the groups.
//        /// </summary>
//        [XmlIgnore]
//        public IEnumerable<Group> Groups => from group1 in UserManager.Groups join group2 in GroupIds on group1.Id equals group2 select group1;

//        /// <summary>
//        /// Returns or sets the timestamp of the creation.
//        /// </summary>
//        [XmlAttribute("created")]
//        public DateTime Created { get; set; }

//        /// <summary>
//        /// The timestamp of the last change.
//        /// </summary>
//        [XmlAttribute("updated")]
//        public DateTime Updated { get; set; }
//    }
//}
