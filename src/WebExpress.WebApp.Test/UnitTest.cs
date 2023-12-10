using WebExpress.WebCore;
using Xunit.Abstractions;

namespace WebExpress.WebApp.Test
{
    public class UnitTest
    {
        public ITestOutputHelper Output { get; private set; }

        public UnitTest(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public void StartServer()
        {
            //Process.Start("http://localhost/");

            WebEx.Main([]);
        }
    }
}
