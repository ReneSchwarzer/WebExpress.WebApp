using WebExpress.WebCore.WebTheme;

namespace WebExpress.WebApp.WebTheme
{
    /// <summary>
    /// Provides extension methods for the <see cref="IThemeManager"/> interface.
    /// </summary>
    public static class ThemeManagerExtensions
    {
        /// <summary>
        /// Retrieves the web application theme based on the provided theme context.
        /// </summary>
        /// <param name="themeManager">The theme manager instance.</param>
        /// <param name="themeContext">The context of the theme.</param>
        /// <returns>Returns an instance of <see cref="IThemeWebApp"/> if found; otherwise, null.</returns>
        public static IThemeWebApp GetWebAppTheme(this IThemeManager themeManager, IThemeContext themeContext)
        {
            return themeManager.GetTheme(themeContext) as IThemeWebApp;
        }
    }
}
