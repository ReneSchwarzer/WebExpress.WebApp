using WebExpress.WebCore.WebAttribute;

namespace WebExpress.WebApp.WebResource
{
    /// <summary>
    /// Delivery of a resource embedded in the assamby.
    /// </summary>
    [Segment("assets")]
    [ContextPath("/")]
    [IncludeSubPaths(true)]
    [Module<Module>]
    public sealed class Asset : WebExpress.WebCore.WebResource.ResourceAsset
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Asset()
        {
        }
    }
}