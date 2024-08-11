using System.Collections.Generic;
using System.Linq;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebResource;
using WebExpress.WebApp.Model;
using WebExpress.WebApp.WebResource;
using WebExpress.WebIndex.Wql;
using WebExpress.WebUI;
using static WebExpress.WebCore.Internationalization.InternationalizationManager;

namespace WebExpress.WebAPI.V1
{
    /// <summary>
    /// REST API for user management.
    /// </summary>
    [Segment("user", "")]
    [ContextPath("/api/v1")]
    [Module<Module>]
    [Optional]
    public sealed class RestUserManagement : ResourceRestCrud<WebItemUser>
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public RestUserManagement()
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
        /// <returns>An enumeration of which json serializer can be serialized.</returns>
        public override IEnumerable<ResourceRestCrudColumn> GetColumns(Request request)
        {
            return new ResourceRestCrudColumn[]
            {
                new ResourceRestCrudColumn(I18N(request, "webexpress.webapp:setting.usermanager.user.login.label"))
                {
                    Render = "return item.Login;",
                    Width = 5
                },
                new ResourceRestCrudColumn(I18N(request, "webexpress.webapp:setting.usermanager.user.name.label"))
                {
                    Render = "return item.Lastname + ', ' + item.Firstname;"
                },
                new ResourceRestCrudColumn(I18N(request, "webexpress.webapp:setting.usermanager.user.groups.label"))
                {
                    Render = "var html = '<ul>' + item.Groups.map(function(group) { return '<li>' + group.Name + '</li>'; }).join('') + '</ul>'; return html;"
                },
                new ResourceRestCrudColumn(I18N(request, "webexpress.webapp:setting.usermanager.user.email.label"))
                {
                    Render = "return item.Email;"
                }
            };
        }

        /// <summary>
        /// Processing of the resource that was called via the get request.
        /// </summary>
        /// <param name="wql">The filtering and sorting options.</param>
        /// <param name="request">The request.</param>
        /// <returns>An enumeration of which json serializer can be serialized.</returns>
        public override IEnumerable<WebItemUser> GetData(IWqlStatement<WebItemUser> wql, Request request)
        {
            var users = wql.Apply();

            return users.Select(x => new WebItemUser()
            {
                Id = x.Id,
                Login = x.Login,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Email = x.Email,
                Groups = x.Groups.Select(y => new WebItemGroup() { Id = y.Id, Name = y.Name })
            });
        }

        /// <summary>
        /// Processing of the resource that was called via the delete request.
        /// </summary>
        /// <param name="id">The id to delete.</param>
        /// <param name="request">The request.</param>
        /// <returns>The result of the deletion.</returns>
        public override bool DeleteData(string id, Request request)
        {
            return true;
        }
    }
}
