using WebExpress.WebApp.Test.Fixture;
using WebExpress.WebApp.WebControl;

namespace WebExpress.WebApp.Test.WebControl
{
    /// <summary>
    /// Tests the web app content control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlWebAppContent
    {
        /// <summary>
        /// Tests the id property of the web app content control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""content m-2"">*</div>")]
        [InlineData("id", @"<div id=""id"" class=""content m-2"">*</div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var application = componentHub.ApplicationManager.GetApplications(typeof(TestApplication)).FirstOrDefault();
            var context = UnitTestControlFixture.CrerateRenderContextMock(application);
            var control = new ControlWebAppContent(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
