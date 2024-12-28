using WebExpress.WebApp.Test.Fixture;
using WebExpress.WebApp.WebControl;

namespace WebExpress.WebApp.Test.WebControl
{
    /// <summary>
    /// Tests the web app headline control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlWebAppHeadline
    {
        /// <summary>
        /// Tests the id property of the web app headline control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<header style=""display: block;"">*</header>")]
        [InlineData("id", @"<header id=""id"" style=""display: block;"">*</header>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var application = componentHub.ApplicationManager.GetApplications(typeof(TestApplication)).FirstOrDefault();
            var context = UnitTestControlFixture.CrerateRenderContextMock(application);
            var control = new ControlWebAppHeadline(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
