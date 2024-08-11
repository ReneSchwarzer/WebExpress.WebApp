using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebUser;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebControl
{
    internal sealed class ControlModalFormUserEdit : ControlModalForm
    {
        /// <summary>
        /// Returns or sets the user to edit.
        /// </summary>
        public User Item { get; set; }

        /// <summary>
        /// Returns the description of the form.
        /// </summary>
        private ControlFormItemStaticText Description { get; } = new ControlFormItemStaticText()
        {
            Text = "webexpress.webapp:setting.usermanager.user.edit.description",
            TextColor = new PropertyColorText(TypeColorText.Secondary)
        };

        /// <summary>
        /// Returns the control for entering the login id.
        /// </summary>
        private ControlFormItemInputTextBox Login { get; } = new ControlFormItemInputTextBox()
        {
            Label = "webexpress.webapp:setting.usermanager.user.edit.login.label",
            Name = "login"
        };

        /// <summary>
        /// Returns the control for entering the first name.
        /// </summary>
        private ControlFormItemInputTextBox Firstname { get; } = new ControlFormItemInputTextBox()
        {
            Label = "webexpress.webapp:setting.usermanager.user.edit.firstname.label",
            Name = "firstname"
        };

        /// <summary>
        /// Returns the control for entering the last name.
        /// </summary>
        private ControlFormItemInputTextBox Lastname { get; } = new ControlFormItemInputTextBox()
        {
            Label = "webexpress.webapp:setting.usermanager.user.edit.lastname.label",
            Name = "lastname"
        };

        /// <summary>
        /// Returns the control for entering the email address.
        /// </summary>
        private ControlFormItemInputTextBox Email { get; } = new ControlFormItemInputTextBox()
        {
            Label = "webexpress.webapp:setting.usermanager.user.edit.email.label",
            Name = "email",
            Placeholder = "user@example.com"
        };

        /// <summary>
        /// Returns or sets the groups.
        /// </summary>
        private ControlFormItemInputMove Groups { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id.</param>
        public ControlModalFormUserEdit(string id = null)
            : base(id)
        {
            Groups = new ControlFormItemInputMove(id)
            {
                Name = "groups",
                Label = "webexpress.webapp:setting.usermanager.user.edit.groups.label",
                Help = "webexpress.webapp:setting.usermanager.user.edit.groups.description",
                SelectedHeader = "webexpress.webapp:setting.usermanager.user.edit.groups.selected",
                AvailableHeader = "webexpress.webapp:setting.usermanager.user.edit.groups.available",
                Icon = new PropertyIcon(TypeIcon.Users)
            };

            Login.Validation += OnLoginValidation;
            Firstname.Validation += OnFirstnameValidation;
            Lastname.Validation += OnLastnameValidation;
            Email.Validation += OnEmailValidation;

            Add(Description);
            Add(Login);
            Add(new ControlFormItemGroupColumnVertical(Firstname, Lastname) { Distribution = new int[] { 50 } });
            Add(Email);
            Add(Groups);
            //Form.SubmitButton.Text = "webexpress.webapp:setting.usermanager.user.edit.confirm";
            Form.FillForm += OnFillForm;
            Form.ProcessForm += OnConfirm;

            Header = "webexpress.webapp:setting.usermanager.user.edit.header";
        }

        /// <summary>
        /// Invoked when the form is to be filled with initial values.
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        private void OnFillForm(object sender, FormEventArgs e)
        {
            Login.Value = Item?.Login;
            Firstname.Value = Item?.Firstname;
            Lastname.Value = Item?.Lastname;
            Email.Value = Item?.Email;

            foreach (var v in UserManager.Groups.OrderBy(x => x.Name))
            {
                Groups.Options.Add(new ControlFormItemInputSelectionItem()
                {
                    Id = v.Id,
                    Label = v.Name
                });
            }

            Groups.Value = string.Join(";", Item.GroupIds);
        }

        /// <summary>
        /// Called when the entered login id is to be checked.
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        private void OnLoginValidation(object sender, ValidationEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Login.Value))
            {
                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.user.edit.login.error.empty"));
            }

            if (UserManager.Users.Where(x => x != Item && x.Login.Equals(Login.Value, StringComparison.OrdinalIgnoreCase)).Any())
            {
                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.user.edit.login.error.duplicate"));
            }
        }

        /// <summary>
        /// Called when the entered first name is to be checked.
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        private void OnFirstnameValidation(object sender, ValidationEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Firstname.Value))
            {
                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.user.edit.firstname.error.empty"));
            }
        }

        /// <summary>
        /// Called when the entered last name is to be checked.
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        private void OnLastnameValidation(object sender, ValidationEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Lastname.Value))
            {
                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.user.edit.lastname.error.empty"));
            }
        }

        /// <summary>
        /// Invoked when the entered email address is to be verified.
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        private void OnEmailValidation(object sender, ValidationEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email.Value))
            {
                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.user.edit.email.error.empty"));
            }
        }

        /// <summary>
        /// Called when the delete action has been confirmed.
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        private void OnConfirm(object sender, FormEventArgs e)
        {
            Item.Login = Login.Value;
            Item.Firstname = Firstname.Value;
            Item.Lastname = Lastname.Value;
            Item.Email = Email.Value;

            var groups = Groups.Value?.Split(";", StringSplitOptions.RemoveEmptyEntries);
            Item.GroupIds = new List<string>();
            Item.GroupIds.AddRange(groups);

            UserManager.UpdateUser(Item);

            e.Context.Page.Redirecting(e.Context.Uri);
        }
    }
}
