using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebPage
{
    public static class LayoutSchema
    {
        /// <summary>
        /// The background color of the header.
        /// </summary>
        public static PropertyColorBackground HeaderBackground => new(TypeColorBackground.Dark);

        /// <summary>
        /// The color of the header title.
        /// </summary>
        public static PropertyColorText HeaderTitle => new(TypeColorText.Light);

        /// <summary>
        /// The color of the header link.
        /// </summary>
        public static PropertyColorText HeaderNavigationLink => new(TypeColorText.Light);

        /// <summary>
        /// The color of the active background.
        /// </summary>
        public static PropertyColorBackground HeaderNavigationActiveBackground => new();

        /// <summary>
        /// The color of the active.
        /// </summary>
        public static PropertyColorText HeaderNavigationActive => new(TypeColorText.Info);

        /// <summary>
        /// The background color of the quick button.
        /// </summary>
        public static PropertyColorButton HeaderQuickCreateButtonBackground => new(TypeColorButton.Success);

        /// <summary>
        /// The size of the quick button.
        /// </summary>
        public static TypeSizeButton HeaderQuickCreateButtonSize => TypeSizeButton.Small;

        /// <summary>
        /// The color of the navigation on the left.
        /// </summary>
        public static PropertyColorText NavigationLink => new(TypeColorText.Primary);

        /// <summary>
        /// The color of the property background.
        /// </summary>
        public static PropertyColorBackground NavigationActiveBackground => new(TypeColorBackground.Primary);

        /// <summary>
        /// The active color in the navigation pane.
        /// </summary>
        public static PropertyColorText NavigationActive => new(TypeColorText.Light);

        /// <summary>
        /// The color of the property link.
        /// </summary>
        public static PropertyColorText Link => new(TypeColorText.Dark);

        /// <summary>
        /// The background color of the sidebar area.
        /// </summary>
        public static PropertyColorBackground SidebarBackground => new(TypeColorBackground.Light);

        /// <summary>
        /// The color of the active sidebar background.
        /// </summary>
        public static PropertyColorBackground SidebarNavigationActiveBackground => new(TypeColorBackground.Info);

        /// <summary>
        /// The color of the active sidebar navigation.
        /// </summary>
        public static PropertyColorText SidebarNavigationActive => new(TypeColorText.Light);

        /// <summary>
        /// The color of the active sidebar navigation link.
        /// </summary>
        public static PropertyColorText SidebarNavigationLink => new(TypeColorText.Dark);

        /// <summary>
        /// The color of the splitter.
        /// </summary>
        public static PropertyColorBackground SplitterColor => new(TypeColorBackground.Light);

        /// <summary>
        /// The background color of the headline area.
        /// </summary>
        public static PropertyColorBackground HeadlineBackground => new();

        /// <summary>
        /// The color of the headline title.
        /// </summary>
        public static PropertyColorText HeadlineTitle => new(TypeColorText.Dark);

        /// <summary>
        /// The background color of the property area.
        /// </summary>
        public static PropertyColorBackground PropertyBackground => new("#C6E2FF");

        /// <summary>
        /// The color of the active property navigation background.
        /// </summary>
        public static PropertyColorBackground PropertyNavigationActiveBackground => new(TypeColorBackground.Info);

        /// <summary>
        /// The color of the active property navigation.
        /// </summary>
        public static PropertyColorText PropertyNavigationActive => new(TypeColorText.Light);

        /// <summary>
        /// The color of the active property navigation link.
        /// </summary>
        public static PropertyColorText PropertyNavigationLink => new(TypeColorText.Dark);

        /// <summary>
        /// The background color of the breadcrumb area.
        /// </summary>
        public static PropertyColorBackground BreadcrumbBackground => new();

        /// <summary>
        /// The size of the breadcrumb area.
        /// </summary>
        public static TypeSizeButton BreadcrumbSize => TypeSizeButton.Small;

        /// <summary>
        /// The Toolbar background color.
        /// </summary>
        public static PropertyColorBackground ToolbarBackground => new();

        /// <summary>
        /// The link color of the toolbar.
        /// </summary>
        public static PropertyColorText ToolbarLink => new(TypeColorText.Dark);

        /// <summary>
        /// The background color of the content area.
        /// </summary>
        public static PropertyColorBackground ContentBackground => new();

        /// <summary>
        /// The background color of the formular area.
        /// </summary>
        public static PropertyColorBackground FormularBackground => new(TypeColorBackground.Light);

        /// <summary>
        /// The background color of a button.
        /// </summary>
        public static PropertyColorButton ButtonBackground => new(TypeColorButton.Success);

        /// <summary>
        /// The background color of the submit button.
        /// </summary>
        public static PropertyColorButton SubmitButtonBackground => new(TypeColorButton.Success);

        /// <summary>
        /// The background color of the next button.
        /// </summary>
        public static PropertyColorButton NextButtonBackground => new(TypeColorButton.Success);

        /// <summary>
        /// The background color of the cancel button.
        /// </summary>
        public static PropertyColorButton CancelButtonBackground => new(TypeColorButton.Secondary);

        /// <summary>
        /// The background color of the close button.
        /// </summary>
        public static PropertyColorButton CloseButtonBackground => new(TypeColorButton.Primary);

        /// <summary>
        /// The background color of a validation error message.
        /// </summary>
        public static PropertyColorBackground ValidationErrorBackground => new PropertyColorBackgroundAlert(TypeColorBackground.Danger);

        /// <summary>
        /// The background color of a validation warning message.
        /// </summary>
        public static PropertyColorBackground ValidationWarningBackground => new PropertyColorBackgroundAlert(TypeColorBackground.Warning);

        /// <summary>
        /// The background color of a validation success message.
        /// </summary>
        public static PropertyColorBackground ValidationSuccessBackground => new PropertyColorBackgroundAlert(TypeColorBackground.Success);

        /// <summary>
        /// The background color of the footer.
        /// </summary>
        public static PropertyColorBackground FooterBackground => new(TypeColorBackground.Light);

        /// <summary>
        /// The text color color of the footer.
        /// </summary>
        public static PropertyColorText FooterText => new(TypeColorText.Secondary);
    }
}
