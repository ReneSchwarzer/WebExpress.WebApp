using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebResource;
using WebExpress.WebIndex;
using WebExpress.WebIndex.WebAttribute;
using WebExpress.WebIndex.Wql;

namespace WebExpress.WebApp.WebResource
{
    public abstract class ResourceRestCrud<T> : ResourceRest where T : IIndexItem
    {
        /// <summary>
        /// Returns the lock object.
        /// </summary>
        protected object Guard { get; } = new object();

        /// <summary>
        /// Processing of the resource that was called via the get request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>An enumeration of which json serializer can be serialized.</returns>
        public abstract IEnumerable<object> GetColumns(Request request);

        /// <summary>
        /// Processing of the resource that was called via the get request.
        /// </summary>
        /// <param name="wql">The filtering and sorting options.</param>
        /// <param name="request">The request.</param>
        /// <returns>An enumeration of which json serializer can be serialized.</returns>
        public abstract IEnumerable<T> GetData(IWqlStatement<T> wql, Request request);

        /// <summary>
        /// Processing of the resource that was called via the get request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>An enumeration of which json serializer can be serialized.</returns>
        public override object GetData(Request request)
        {
            var itemCount = 50;
            var search = request.HasParameter("search") ? request.GetParameter("search").Value : string.Empty;
            var wql = request.HasParameter("wql") ? request.GetParameter("wql").Value : null;
            var page = request.GetParameter("page");
            var columns = request.HasParameter("columns");
            var pagenumber = !string.IsNullOrWhiteSpace(page?.Value) ? Convert.ToInt32(page?.Value) : 0;

            if (columns)
            {
                return new { Columns = GetColumns(request) };
            }

            lock (Guard)
            {
                var wqlStatement = ComponentManager.GetComponent<WebIndex.IndexManager>().Retrieve<T>(wql ?? $"{GetDefaultSearchAttribute()}='{search}'");
                var data = GetData(wqlStatement, request);

                var count = data.Count();
                var totalpage = Math.Round(count / (double)itemCount, MidpointRounding.ToEven);

                if (page == null)
                {
                    return new { Data = data };
                }

                return new { data = data.Skip(itemCount * pagenumber).Take(itemCount), pagination = new { pagenumber = pagenumber, totalpage = totalpage } };
            }
        }

        /// <summary>
        /// Returns the attribute name that has been set as for search queries.
        /// </summary>
        /// <returns>The name of the default attribute.</returns>
        protected virtual string GetDefaultSearchAttribute()
        {
            return typeof(T).GetProperties()
                //.Where(x => x.GetCustomAttribute<IndexDefaultSearchAttribute>() != null)
                .Where(x => x.GetCustomAttribute<IndexIgnoreAttribute>() == null)
                .Select(x => x.Name)
                .FirstOrDefault();
        }
    }
}
