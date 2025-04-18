﻿using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPlugin;

namespace WebExpress.WebApp.Test
{
    /// <summary>
    /// A dummy plugin for testing purposes.
    /// </summary>
    [Name("TestPlugin")]
    [Description("plugin.description")]
    [Icon("/assets/img/Logo.png")]
    [Application<TestApplication>()]
    public sealed class TestPlugin : IPlugin
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pluginContext">The plugin context.</param>
        private TestPlugin(IPluginContext pluginContext)
        {

        }

        /// <summary>
        /// Called when the plugin starts working. The call is concurrent.
        /// </summary>
        public void Run()
        {
        }
    }
}
