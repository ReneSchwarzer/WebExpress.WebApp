﻿//using System;
//using System.Linq;
//using WebExpress.WebApp.WebUser;
//using WebExpress.WebUI.WebControl;


//namespace WebExpress.WebApp.WebControl
//{
//    internal sealed class ControlModalFormUserNew : ControlModalForm
//    {
//        /// <summary>
//        /// Returns the description of the form.
//        /// </summary>
//        private ControlFormItemStaticText Description { get; } = new ControlFormItemStaticText()
//        {
//            Text = "webexpress.webapp:setting.usermanager.user.add.description",
//            TextColor = new PropertyColorText(TypeColorText.Secondary)
//        };

//        /// <summary>
//        /// Returns the control for entering the login id.
//        /// </summary>
//        private ControlFormItemInputTextBox Login { get; } = new ControlFormItemInputTextBox()
//        {
//            Label = "webexpress.webapp:setting.usermanager.user.add.login.label",
//            Name = "login"
//        };

//        /// <summary>
//        /// Returns the control for entering the first name.
//        /// </summary>
//        private ControlFormItemInputTextBox Firstname { get; } = new ControlFormItemInputTextBox()
//        {
//            Label = "webexpress.webapp:setting.usermanager.user.add.firstname.label",
//            Name = "firstname"
//        };

//        /// <summary>
//        /// Returns the control for entering the last name.
//        /// </summary>
//        private ControlFormItemInputTextBox Lastname { get; } = new ControlFormItemInputTextBox()
//        {
//            Label = "webexpress.webapp:setting.usermanager.user.add.lastname.label",
//            Name = "lastname"
//        };

//        /// <summary>
//        /// Returns the control for entering the email address.
//        /// </summary>
//        private ControlFormItemInputTextBox Email { get; } = new ControlFormItemInputTextBox()
//        {
//            Label = "webexpress.webapp:setting.usermanager.user.add.email.label",
//            Name = "email",
//            Placeholder = "user@example.com"
//        };

//        /// <summary>
//        /// Returns the groups.
//        /// </summary>
//        private ControlFormItemInputMove Groups { get; } = new ControlFormItemInputMove("group")
//        {
//            Name = "groups",
//            Label = "webexpress.webapp:setting.usermanager.user.edit.groups.label",
//            Help = "webexpress.webapp:setting.usermanager.user.edit.groups.description",
//            SelectedHeader = "webexpress.webapp:setting.usermanager.user.edit.groups.selected",
//            AvailableHeader = "webexpress.webapp:setting.usermanager.user.edit.groups.available",
//            Icon = new PropertyIcon(TypeIcon.Users)
//        };

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The id.</param>
//        public ControlModalFormUserNew(string id = null)
//            : base(id)
//        {
//            Login.Validation += OnLoginValidation;
//            Firstname.Validation += OnFirstnameValidation;
//            Lastname.Validation += OnLastnameValidation;
//            Email.Validation += OnEmailValidation;

//            Add(Description);
//            Add(Login);
//            Add(new ControlFormItemGroupColumnVertical(Firstname, Lastname) { Distribution = new int[] { 50 } });
//            Add(Email);
//            Add(Groups);
//            //Form.SubmitButton.Text = "webexpress.webapp:setting.usermanager.user.add.confirm";
//            Form.FillForm += OnFillForm;
//            Form.ProcessForm += OnConfirm;

//            Header = "webexpress.webapp:setting.usermanager.user.add.header";
//        }

//        /// <summary>
//        /// Invoked when the form is to be filled with initial values.
//        /// </summary>
//        /// <param name="sender">The trigger of the event.</param>
//        /// <param name="e">The event argument.</param>
//        private void OnFillForm(object sender, FormEventArgs e)
//        {
//            foreach (var v in UserManager.Groups.OrderBy(x => x.Name))
//            {
//                Groups.Options.Add(new ControlFormItemInputSelectionItem()
//                {
//                    Id = v.Id,
//                    Label = v.Name
//                });
//            }
//        }

//        /// <summary>
//        /// Called when the entered login id is to be checked.
//        /// </summary>
//        /// <param name="sender">The trigger of the event.</param>
//        /// <param name="e">The event argument.</param>
//        private void OnLoginValidation(object sender, ValidationEventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(Login.Value))
//            {
//                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.user.add.login.error.empty"));
//            }

//            if (UserManager.Users.Where(x => x.Login.Equals(Login.Value, StringComparison.OrdinalIgnoreCase)).Any())
//            {
//                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.user.add.login.error.duplicate"));
//            }
//        }

//        /// <summary>
//        /// Called when the entered first name is to be checked.
//        /// </summary>
//        /// <param name="sender">The trigger of the event.</param>
//        /// <param name="e">The event argument.</param>
//        private void OnFirstnameValidation(object sender, ValidationEventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(Firstname.Value))
//            {
//                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.user.add.firstname.error.empty"));
//            }
//        }

//        /// <summary>
//        /// Called when the entered last name is to be checked.
//        /// </summary>
//        /// <param name="sender">The trigger of the event.</param>
//        /// <param name="e">The event argument.</param>
//        private void OnLastnameValidation(object sender, ValidationEventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(Lastname.Value))
//            {
//                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.user.add.lastname.error.empty"));
//            }
//        }

//        /// <summary>
//        /// Invoked when the entered email address is to be verified.
//        /// </summary>
//        /// <param name="sender">The trigger of the event.</param>
//        /// <param name="e">The event argument.</param>
//        private void OnEmailValidation(object sender, ValidationEventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(Email.Value))
//            {
//                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.user.add.email.error.empty"));
//            }
//        }

//        /// <summary>
//        /// Called when the delete action has been confirmed.
//        /// </summary>
//        /// <param name="sender">The trigger of the event.</param>
//        /// <param name="e">The event argument.</param>
//        private void OnConfirm(object sender, FormEventArgs e)
//        {
//            var user = new User()
//            {
//                Id = Guid.NewGuid(),
//                Login = Login.Value,
//                Firstname = Firstname.Value,
//                Lastname = Lastname.Value,
//                Email = Email.Value,
//                Created = DateTime.Now,
//                Updated = DateTime.Now
//            };

//            UserManager.AddUser(user);

//            e.Context.Page.Redirecting(e.Context.Uri);
//        }
//    }
//}
