﻿using WebExpress.WebApp.Test.Fixture;
using WebExpress.WebApp.WebControl;

namespace WebExpress.WebApp.Test.WebControl
{
    /// <summary>
    /// Tests the web app footer control.
    /// </summary>
    [Collection("NonParallelTests")]
    public class UnitTestControlWebAppFooter
    {
        /// <summary>
        /// Tests the id property of the web app footer control.
        /// </summary>
        [Theory]
        [InlineData(null, @"<div class=""footer""><div></div><div class=""justify-content-center""></div><div></div></div>")]
        [InlineData("id", @"<div id=""id"" class=""footer""><div></div><div class=""justify-content-center""></div><div></div></div>")]
        public void Id(string id, string expected)
        {
            // preconditions
            var componentHub = UnitTestControlFixture.CreateAndRegisterComponentHubMock();
            var application = componentHub.ApplicationManager.GetApplications(typeof(TestApplication)).FirstOrDefault();
            var context = UnitTestControlFixture.CrerateRenderContextMock(application);
            var control = new ControlWebAppFooter(id)
            {
            };

            // test execution
            var html = control.Render(context);

            AssertExtensions.EqualWithPlaceholders(expected, html);
        }
    }
}
