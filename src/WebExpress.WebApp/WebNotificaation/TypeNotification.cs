namespace WebExpress.WebApp.WebNotificaation
{
    /// <summary>
    /// The layout options of the notification.
    /// </summary>
    public enum TypeNotification
    {
        Default = 0,
        Primary = 1,
        Secondary = 2,
        Success = 3,
        Info = 4,
        Warning = 5,
        Danger = 6,
        Dark = 7,
        Light = 8,
        White = 9,
        Transparent = 10
    }

    public static class TypeLayoutTabExtensions
    {
        /// <summary>
        /// Conversion to a string.
        /// </summary>
        /// <param name="layout">The layout to be converted.</param>
        /// <returns>The converted layout.</returns>
        public static string ToClass(this TypeNotification layout)
        {
            return layout switch
            {
                TypeNotification.Primary => "bg-primary",
                TypeNotification.Secondary => "bg-secondary",
                TypeNotification.Success => "alert-success",
                TypeNotification.Info => "alert-info",
                TypeNotification.Warning => "alert-warning",
                TypeNotification.Danger => "alert-danger",
                TypeNotification.Light => "alert-light",
                TypeNotification.Dark => "alert-dark",
                TypeNotification.White => "bg-white",
                TypeNotification.Transparent => "bg-transparent",
                _ => string.Empty,
            };
        }
    }
}
