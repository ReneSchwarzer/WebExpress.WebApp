//using System;
//using System.Linq;
//using WebExpress.WebApp.WebUser;
//using WebExpress.WebUI.WebControl;

//namespace WebExpress.WebApp.WebControl
//{
//    internal sealed class ControlModalFormGoupNew : ControlModalForm
//    {
//        /// <summary>
//        /// Returns the description of the form.
//        /// </summary>
//        private ControlFormItemStaticText Description { get; } = new ControlFormItemStaticText()
//        {
//            Text = "webexpress.webapp:setting.usermanager.group.add.description",
//            TextColor = new PropertyColorText(TypeColorText.Secondary)
//        };

//        /// <summary>
//        /// Returns the control element for entering the group name.
//        /// </summary>
//        private ControlFormItemInputTextBox GroupName { get; } = new ControlFormItemInputTextBox()
//        {
//            Label = "webexpress.webapp:setting.usermanager.group.add.name.label",
//            Name = "groupname"
//        };

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The control id.</param>
//        public ControlModalFormGoupNew(string id = null)
//            : base(id)
//        {
//            Add(Description);
//            Add(GroupName);

//            Header = "webexpress.webapp:setting.usermanager.group.add.header";

//            GroupName.Validation += OnGroupNameValidation;
//            //Form.SubmitButton.Text = "webexpress.webapp:setting.usermanager.group.add.confirm";
//            Form.ProcessForm += OnConfirm;
//        }

//        /// <summary>
//        /// Invoked when you want to check the group name you entered.
//        /// </summary>
//        /// <param name="sender">The trigger of the event.</param>
//        /// <param name="e">The event argument.</param>
//        private void OnGroupNameValidation(object sender, ValidationEventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(GroupName.Value))
//            {
//                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.group.add.name.error.empty"));
//            }

//            if (UserManager.Groups.Where(x => x.Name.Equals(GroupName.Value, StringComparison.OrdinalIgnoreCase)).Any())
//            {
//                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.group.add.name.error.duplicate"));
//            }
//        }

//        /// <summary>
//        /// Called when the delete action has been confirmed.
//        /// </summary>
//        /// <param name="sender">The trigger of the event.</param>
//        /// <param name="e">The event argument.</param>
//        private void OnConfirm(object sender, FormEventArgs e)
//        {
//            var group = new Group()
//            {
//                Id = Guid.NewGuid().ToString(),
//                Name = GroupName.Value,
//                Created = DateTime.Now,
//                Updated = DateTime.Now
//            };

//            UserManager.AddGroup(group);

//            e.Context.Page.Redirecting(e.Context.Uri);
//        }
//    }
//}
