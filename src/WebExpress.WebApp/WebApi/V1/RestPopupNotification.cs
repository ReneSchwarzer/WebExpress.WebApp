using System.Collections;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebResource;
using WebExpress.WebApp.WebNotificaation;

namespace WebExpress.WebApp.WebAPI.V1
{
    /// <summary>
    /// Returns the status and progress of a task (WebTask).
    /// </summary>
    [Segment("popupnotifications", "")]
    [ContextPath("/api/v1")]
    [Module<Module>]
    [IncludeSubPaths(true)]
    [Optional]
    public sealed class RestPopupNotification : ResourceRest
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public RestPopupNotification()
        {
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialization(IResourceContext context)
        {
            base.Initialization(context);
        }

        /// <summary>
        /// Processing of the resource that was called via the get request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>An enumeration that can be serialized using the JsonSerializer.</returns>
        public override ICollection GetData(Request request)
        {
            return (ICollection)ComponentManager.GetComponent<NotificationManager>()?.GetNotifications(request);
        }

        /// <summary>
        /// Processing of the resource that was called via the delete request.
        /// </summary>
        /// <param name="id">The id to delete.</param>
        /// <param name="request">The request.</param>
        /// <returns>The result of the deletion.</returns>
        public override bool DeleteData(string id, Request request)
        {
            ComponentManager.GetComponent<NotificationManager>()?.RemoveNotification(request, id);

            return true;
        }
    }
}
