﻿using WebExpress.WebApp.Test.Fixture;
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
        [InlineData(null, @"<div class=""dropdown mx-2"">*</div>")]
        [InlineData("id", @"<div id=""id"" class=""dropdown mx-2"">*</div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var application = componentHub.ApplicationManager.GetApplications(typeof(TestApplication)).FirstOrDefault();
            var context = UnitTestControlFixture.CrerateRenderContextMock(application);
            var control = new ControlWebAppHeaderAppNavigator(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
