using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebSettingPage;
using WebExpress.WebCore.WebSettingPage.Model;

namespace WebExpress.WebApp.WebSettingPage
{
    /// <summary>
    /// Represents the general settings category for the web application.
    /// </summary>
    //[Icon(TypeIcon.Globe)]
    [Name("webexpress.webapp:setting.category.general.name")]
    [Description("webexpress.webapp:setting.category.general.description")]
    [SettingSection(SettingSection.Primary)]
    public sealed class SettingCategoryGeneral : ISettingCategory
    {

    }
}
