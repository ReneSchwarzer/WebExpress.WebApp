using System.Collections;
using System.Linq;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebResource;

namespace WebExpress.WebApp.WebAPI.V1
{
    /// <summary>
    /// Determines the status and progress of a task (WebTask).
    /// </summary>
    [Segment("taskstatus", "")]
    [ContextPath("/api/v1")]
    [IncludeSubPaths(true)]
    [Module<Module>]
    [Optional]
    public sealed class RestTaskStatus : ResourceRest
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public RestTaskStatus()
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
        /// Processing of the resource.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>An enumeration that can be serialized using the JsonSerializer.</returns>
        public override ICollection GetData(Request request)
        {
            var id = request.Uri.PathSegments.Last().Value;

            if (ComponentManager.TaskManager.ContainsTask(id))
            {
                var task = ComponentManager.TaskManager.GetTask(id);

                return new object[]
                {
                    new
                    {
                        Id = id,
                        task.State,
                        task.Progress,
                        task.Message
                    }
                };
            }

            return new object[]
            {
                new
                {
                    Id = id,
                    State = default(string),
                    Progress = 0
                }
            };
        }
    }
}
