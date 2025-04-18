using WebExpress.WebApp.Test.Fixture;
using WebExpress.WebApp.WebApiControl;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebApp.Test.WebApiControl
{
    /// <summary>
    /// Tests the api table control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlApiTable
    {
        /// <summary>
        /// Tests the id property of the api table control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div id=""*""></div>")]
        [InlineData("id", @"<div id=""id""></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var application = componentHub.ApplicationManager.GetApplications(typeof(TestApplication)).FirstOrDefault();
            var context = UnitTestControlFixture.CreateRenderContextMock(application);
            var visualTree = new VisualTreeControl(componentHub, context.PageContext);
            var control = new ControlApiTable(id)
            {
            };

            // test execution
            var html = control.Render(context, visualTree);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
