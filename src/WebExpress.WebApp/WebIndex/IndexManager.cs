﻿using System;
using System.Collections.Generic;
using WebExpress.Internationalization;
using WebExpress.WebComponent;
using WebExpress.WebIndex;
using WebExpress.WebPlugin;

namespace WebExpress.WebApp.WebIndex
{
    public sealed class IndexManager : WebExpress.WebIndex.IndexManager, IComponentPlugin
    {
        /// <summary>
        /// Returns the reference to the context of the host.
        /// </summary>
        public IHttpServerContext HttpServerContext { get; private set; }

        /// <summary>
        /// Returns an enumeration of the existing index documents.
        /// </summary>
        public Dictionary<Type, IIndexDocument> Documents { get; } = new Dictionary<Type, IIndexDocument>();

        /// <summary>
        /// Constructor
        /// </summary>
        internal IndexManager()
        {
            ComponentManager.PluginManager.AddPlugin += (s, pluginContext) =>
            {
                Register(pluginContext);
            };

            ComponentManager.PluginManager.RemovePlugin += (s, pluginContext) =>
            {
                Remove(pluginContext);
            };
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The reference to the context of the host.</param>
        public void Initialization(IHttpServerContext context)
        {
            HttpServerContext = context;

            HttpServerContext.Log.Debug
            (
                InternationalizationManager.I18N("webexpress.webapp:indexmanager.initialization")
            );
        }

        /// <summary>
        /// Discovers and registers entries from the specified plugin.
        /// </summary>
        /// <param name="pluginContext">A context of a plugin whose elements are to be registered.</param>
        public void Register(IPluginContext pluginContext)
        {

        }

        /// <summary>
        /// Discovers and registers entries from the specified plugin.
        /// </summary>
        /// <param name="pluginContexts">A list with plugin contexts that contain the components.</param>
        public void Register(IEnumerable<IPluginContext> pluginContexts)
        {
            foreach (var pluginContext in pluginContexts)
            {
                Register(pluginContext);
            }
        }

        /// <summary>
        /// Removes all components associated with the specified plugin context.
        /// </summary>
        /// <param name="pluginContext">The context of the plugin that contains the components to remove.</param>
        public void Remove(IPluginContext pluginContext)
        {
            //Dictionary.Remove(pluginContext);
        }

        /// <summary>
        /// Information about the component is collected and prepared for output in the log.
        /// </summary>
        /// <param name="pluginContext">The context of the plugin.</param>
        /// <param name="output">A list of log entries.</param>
        /// <param name="deep">The shaft deep.</param>
        public void PrepareForLog(IPluginContext pluginContext, IList<string> output, int deep)
        {

        }
    }
}
