using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebSettingPage;
using WebExpress.WebCore.WebSettingPage.Model;

namespace WebExpress.WebApp.WebSettingPage
{
    /// <summary>
    /// Represents the general settings group for the web application.
    /// </summary>
    //[Icon(TypeIcon.Globe)]
    [Name("webexpress.webapp:setting.group.general.name")]
    [Description("webexpress.webapp:setting.group.general.description")]
    [SettingSection(SettingSection.Primary)]
    [SettingCategory<SettingCategoryGeneral>]
    public sealed class SettingGroupGeneral : ISettingGroup
    {

    }
}
