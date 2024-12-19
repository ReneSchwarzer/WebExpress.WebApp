using WebExpress.WebApp.Test.Fixture;
using WebExpress.WebApp.WebControl;

namespace WebExpress.WebApp.Test.WebControl
{
    /// <summary>
    /// Tests the web app header app navigator control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlWebAppHeaderAppNavigator
    {
        /// <summary>
        /// Tests the id property of the web app header app navigator control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<img class="" p-2 mx-2"" height=""50"">")]
        [InlineData("id", @"<img id=""id"" class="" p-2 mx-2"" height=""50"">")]
        public void Id(string id, string expected)
        {
            // preconditions
            UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var context = UnitTestControlFixture.CrerateRenderContextMock();
            var control = new ControlWebAppHeaderAppNavigator(id)
            {
            };

            // test execution
            var html = control.Render(context);

            Assert.Equal(expected, UnitTestControlFixture.RemoveLineBreaks(html.ToString()));
        }
    }
}
