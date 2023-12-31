﻿using System.Collections.Generic;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebApp.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// Header for a web app.
    /// </summary>
    public class ControlWebAppHeader : Control
    {
        /// <summary>
        /// Returns or sets the text color.
        /// </summary>
        public new virtual PropertyColorNavbar TextColor
        {
            get => (PropertyColorNavbar)GetPropertyObject();
            set => SetProperty(value, () => value?.ToClass(), () => value?.ToStyle());
        }

        /// <summary>
        /// Returns or sets whether the arrangement is fixed.
        /// </summary>
        public virtual TypeFixed Fixed
        {
            get => (TypeFixed)GetProperty(TypeFixed.None);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets the fixed arrangement when the toolbar is at the top.
        /// </summary>
        public virtual TypeSticky Sticky
        {
            get => (TypeSticky)GetProperty(TypeSticky.None);
            set => SetProperty(value, () => value.ToClass());
        }

        /// <summary>
        /// Returns or sets the application navigator.
        /// </summary>
        public ControlWebAppHeaderAppNavigator AppNavigator { get; } = new ControlWebAppHeaderAppNavigator("webexpress.webapp.header.appnavigator")
        {
        };

        /// <summary>
        /// Returns or setss the name of the application.
        /// </summary>
        public ControlWebAppHeaderAppTitle AppTitle { get; } = new ControlWebAppHeaderAppTitle("webexpress.webapp.header.apptitle")
        {
        };

        /// <summary>
        /// Returns or sets the navigation of the application.
        /// </summary>
        public ControlWebAppHeaderAppNavigation AppNavigation { get; } = new ControlWebAppHeaderAppNavigation("webexpress.webapp.header.appnavigation")
        {
            Layout = TypeLayoutFlexbox.Inline,
            Justify = TypeJustifiedFlexbox.Start
        };

        /// <summary>
        /// Returns or sets the quick create.
        /// </summary>
        public ControlWebAppHeaderQuickCreate QuickCreate { get; } = new ControlWebAppHeaderQuickCreate("webexpress.webapp.header.quickcreate")
        {
        };

        /// <summary>
        /// Returns or sets the navigation of the application helpers.
        /// </summary>
        public ControlWebAppHeaderHelp Help { get; } = new ControlWebAppHeaderHelp("webexpress.webapp.header.help")
        {
        };

        /// <summary>
        /// Returns or sets the navigation of the application settings.
        /// </summary>
        public ControlWebAppHeaderSettings Settings { get; } = new ControlWebAppHeaderSettings("webexpress.webapp.header.settings")
        {
        };

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppHeader(string id = null)
            : base(id)
        {
            Init();
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Init()
        {
            Fixed = TypeFixed.Top;
            Styles = new List<string>(new[] { "position: sticky; top: 0; z-index: 99;" });
            Padding = new PropertySpacingPadding(PropertySpacing.Space.Null);
            BackgroundColor = LayoutSchema.HeaderBackground;
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is rendered.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            var content = new ControlPanelFlexbox
            (
                AppNavigator,
                AppTitle,
                AppNavigation,
                QuickCreate,
                new ControlPanel() { Margin = new PropertySpacingMargin(PropertySpacing.Space.Auto, PropertySpacing.Space.None) },
                Help,
                Settings
            )
            {
                Layout = TypeLayoutFlexbox.Default,
                Align = TypeAlignFlexbox.Center
            };

            return new HtmlElementSectionHeader(content.Render(context))
            {
                Id = Id,
                Class = Css.Concatenate("navbar", GetClasses()),
                Style = Style.Concatenate("display: block;", GetStyles()),
                Role = Role
            };
        }
    }
}
