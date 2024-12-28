using WebExpress.WebApp.Test.Fixture;
using WebExpress.WebApp.WebControl;

namespace WebExpress.WebApp.Test.WebControl
{
    /// <summary>
    /// Tests the web app header navigation control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlWebAppHeaderAppNavigation
    {
        /// <summary>
        /// Tests the id property of the web app header navigation control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""p-0"">*</div>")]
        [InlineData("id", @"<div id=""id"" class=""p-0"">*</div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var application = componentHub.ApplicationManager.GetApplications(typeof(TestApplication)).FirstOrDefault();
            var context = UnitTestControlFixture.CrerateRenderContextMock(application);
            var control = new ControlWebAppHeaderAppNavigation(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
