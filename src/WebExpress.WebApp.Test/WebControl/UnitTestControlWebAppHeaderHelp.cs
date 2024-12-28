using WebExpress.WebApp.Test.Fixture;
using WebExpress.WebApp.WebControl;

namespace WebExpress.WebApp.Test.WebControl
{
    /// <summary>
    /// Tests the web app header help control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlWebAppHeaderHelp
    {
        /// <summary>
        /// Tests the id property of the web app header help control.
        /// </summary>
        [Theory]
        [InlineData(null, null)]
        [InlineData("id", null)]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var application = componentHub.ApplicationManager.GetApplications(typeof(TestApplication)).FirstOrDefault();
            var context = UnitTestControlFixture.CrerateRenderContextMock(application);
            var control = new ControlWebAppHeaderHelp(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
