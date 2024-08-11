using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebApiControl;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebResource;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebApp.WebPage
{
    /// <summary>
    /// Page consisting of a vertically arranged header, content and footer area.
    /// </summary>
    public abstract class PageWebApp : PageControl<RenderContextWebApp>
    {
        // header
        private List<FragmentCacheItem> HeaderAppNavigatorPreferences { get; } = [];
        private List<FragmentCacheItem> HeaderAppNavigatorPrimary { get; } = [];
        private List<FragmentCacheItem> HeaderAppNavigatorSecondary { get; } = [];
        private List<FragmentCacheItem> HeaderNavigationPreferences { get; } = [];
        private List<FragmentCacheItem> HeaderNavigationPrimary { get; } = [];
        private List<FragmentCacheItem> HeaderNavigationSecondary { get; } = [];
        private List<FragmentCacheItem> HeaderQuickCreatePreferences { get; } = [];
        private List<FragmentCacheItem> HeaderQuickCreatePrimary { get; } = [];
        private List<FragmentCacheItem> HeaderQuickCreateSecondary { get; } = [];
        private List<FragmentCacheItem> HeaderHelpPreferences { get; } = [];
        private List<FragmentCacheItem> HeaderHelpPrimary { get; } = [];
        private List<FragmentCacheItem> HeaderHelpSecondary { get; } = [];
        private List<FragmentCacheItem> HeaderSettingsPreferences { get; } = [];
        private List<FragmentCacheItem> HeaderSettingsPrimary { get; } = [];
        private List<FragmentCacheItem> HeaderSettingsSecondary { get; } = [];

        // sidebar
        private List<FragmentCacheItem> SidebarHeader { get; } = [];
        private List<FragmentCacheItem> SidebarPreferences { get; } = [];
        private List<FragmentCacheItem> SidebarPrimary { get; } = [];
        private List<FragmentCacheItem> SidebarSecondary { get; } = [];

        // headline
        private List<FragmentCacheItem> ContentHeadlinePrologue { get; } = [];
        private List<FragmentCacheItem> ContentHeadlinePreferences { get; } = [];
        private List<FragmentCacheItem> ContentHeadlinePrimary { get; } = [];
        private List<FragmentCacheItem> ContentHeadlineSecondary { get; } = [];
        private List<FragmentCacheItem> ContentHeadlineMorePreferences { get; } = [];
        private List<FragmentCacheItem> ContentHeadlineMorePrimary { get; } = [];
        private List<FragmentCacheItem> ContentHeadlineMoreSecondary { get; } = [];
        private List<FragmentCacheItem> ContentHeadlineMetadata { get; } = [];

        // property
        private List<FragmentCacheItem> ContentPropertyPreferences { get; } = [];
        private List<FragmentCacheItem> ContentPropertyPrimary { get; } = [];
        private List<FragmentCacheItem> ContentPropertySecondary { get; } = [];

        // content
        private List<FragmentCacheItem> ContentPreferences { get; } = [];
        private List<FragmentCacheItem> ContentPrimary { get; } = [];
        private List<FragmentCacheItem> ContentSecondary { get; } = [];

        // footer
        private List<FragmentCacheItem> FooterPreferences { get; } = [];
        private List<FragmentCacheItem> FooterPrimary { get; } = [];
        private List<FragmentCacheItem> FooterSecondary { get; } = [];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public PageWebApp()
        {
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialization(IResourceContext context)
        {
            base.Initialization(context);

            var fm = ComponentManager.GetComponent<FragmentManager>();
            var module = ComponentManager.ModuleManager.GetModule(ApplicationContext, typeof(Module));
            if (module != null)
            {
                CssLinks.Add(UriResource.Combine(module.ContextPath, "/assets/css/webexpress.webapp.css"));
                CssLinks.Add(UriResource.Combine(module.ContextPath, "/assets/css/webexpress.webapp.popupnotification.css"));
                CssLinks.Add(UriResource.Combine(module.ContextPath, "/assets/css/webexpress.webapp.taskprogressbar.css"));
                HeaderScriptLinks.Add(UriResource.Combine(module.ContextPath, "assets/js/webexpress.webapp.js"));
                HeaderScriptLinks.Add(UriResource.Combine(module.ContextPath, "assets/js/webexpress.webapp.popupnotification.js"));
                HeaderScriptLinks.Add(UriResource.Combine(module.ContextPath, "assets/js/webexpress.webapp.selection.js"));
                HeaderScriptLinks.Add(UriResource.Combine(module.ContextPath, "assets/js/webexpress.webapp.table.js"));
                HeaderScriptLinks.Add(UriResource.Combine(module.ContextPath, "assets/js/webexpress.webapp.taskprogressbar.js"));
            }

            // header
            HeaderAppNavigatorPreferences.AddRange(fm.GetCacheableFragments<IControlDropdownItem>(SectionWebApp.AppPreferences, this, context.Scopes));
            HeaderAppNavigatorPrimary.AddRange(fm.GetCacheableFragments<IControlDropdownItem>(SectionWebApp.AppPrimary, this, context.Scopes));
            HeaderAppNavigatorSecondary.AddRange(fm.GetCacheableFragments<IControlDropdownItem>(SectionWebApp.AppSecondary, this, context.Scopes));
            HeaderNavigationPreferences.AddRange(fm.GetCacheableFragments<IControlNavigationItem>(SectionWebApp.AppNavigationPreferences, this, context.Scopes));
            HeaderNavigationPrimary.AddRange(fm.GetCacheableFragments<IControlNavigationItem>(SectionWebApp.AppNavigationPrimary, this, context.Scopes));
            HeaderNavigationSecondary.AddRange(fm.GetCacheableFragments<IControlNavigationItem>(SectionWebApp.AppNavigationSecondary, this, context.Scopes));
            HeaderQuickCreatePreferences.AddRange(fm.GetCacheableFragments<IControlSplitButtonItem>(SectionWebApp.AppQuickcreatePreferences, this, context.Scopes));
            HeaderQuickCreatePrimary.AddRange(fm.GetCacheableFragments<IControlSplitButtonItem>(SectionWebApp.AppQuickcreatePrimary, this, context.Scopes));
            HeaderQuickCreateSecondary.AddRange(fm.GetCacheableFragments<IControlSplitButtonItem>(SectionWebApp.AppQuickcreateSecondary, this, context.Scopes));
            HeaderHelpPreferences.AddRange(fm.GetCacheableFragments<IControlDropdownItem>(SectionWebApp.AppHelpPreferences, this, context.Scopes));
            HeaderHelpPrimary.AddRange(fm.GetCacheableFragments<IControlDropdownItem>(SectionWebApp.AppHelpPrimary, this, context.Scopes));
            HeaderHelpSecondary.AddRange(fm.GetCacheableFragments<IControlDropdownItem>(SectionWebApp.AppHelpSecondary, this, context.Scopes));
            HeaderSettingsPrimary.AddRange(fm.GetCacheableFragments<IControlDropdownItem>(SectionWebApp.AppSettingsPrimary, this, context.Scopes));
            HeaderSettingsSecondary.AddRange(fm.GetCacheableFragments<IControlDropdownItem>(SectionWebApp.AppSettingsSecondary, this, context.Scopes));

            // sidebar
            SidebarHeader.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.SidebarHeader, this, context.Scopes));
            SidebarPreferences.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.SidebarPreferences, this, context.Scopes));
            SidebarPrimary.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.SidebarPrimary, this, context.Scopes));
            SidebarSecondary.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.SidebarSecondary, this, context.Scopes));

            // headline
            ContentHeadlinePrologue.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.HeadlinePrologue, this, context.Scopes));
            ContentHeadlinePreferences.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.HeadlinePreferences, this, context.Scopes));
            ContentHeadlinePrimary.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.HeadlinePrimary, this, context.Scopes));
            ContentHeadlineSecondary.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.HeadlineSecondary, this, context.Scopes));
            ContentHeadlineMorePreferences.AddRange(fm.GetCacheableFragments<IControlDropdownItem>(SectionWebApp.MorePreferences, this, context.Scopes));
            ContentHeadlineMorePrimary.AddRange(fm.GetCacheableFragments<IControlDropdownItem>(SectionWebApp.MorePrimary, this, context.Scopes));
            ContentHeadlineMoreSecondary.AddRange(fm.GetCacheableFragments<IControlDropdownItem>(SectionWebApp.MoreSecondary, this, context.Scopes));
            ContentHeadlineMetadata.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.Metadata, this, context.Scopes));

            // property
            ContentPropertyPreferences.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.PropertyPreferences, this, context.Scopes));
            ContentPropertyPrimary.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.PropertyPrimary, this, context.Scopes));
            ContentPropertySecondary.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.PropertySecondary, this, context.Scopes));

            // content
            ContentPreferences.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.ContentPreferences, this, context.Scopes));
            ContentPrimary.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.ContentPrimary, this, context.Scopes));
            ContentSecondary.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.ContentSecondary, this, context.Scopes));

            // footer
            FooterPreferences.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.FooterPreferences, this, context.Scopes));
            FooterPrimary.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.FooterPrimary, this, context.Scopes));
            FooterSecondary.AddRange(fm.GetCacheableFragments<IControl>(SectionWebApp.FooterSecondary, this, context.Scopes));
        }

        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="context">The context for rendering the page.</param>
        public override void Process(RenderContextWebApp context)
        {
            base.Process(context);

            context.VisualTree.Favicons.Add(new Favicon(context.ApplicationContext?.Icon));
            //context.VisualTree.Header.Logo = context.Application?.Icon;
            //context.VisualTree.Header.AppTitle.Title = this.I18N(context.Application, context.Application?.ApplicationName);

            context.VisualTree.Breadcrumb.Uri = context.Uri;

            // header
            context.VisualTree.Header.AppNavigator.Preferences.AddRange(HeaderAppNavigatorPreferences.SelectMany(x => x.CreateInstance<IControlDropdownItem>(this, context.Request)));
            context.VisualTree.Header.AppNavigator.Primary.AddRange(HeaderAppNavigatorPrimary.SelectMany(x => x.CreateInstance<IControlDropdownItem>(this, context.Request)));
            context.VisualTree.Header.AppNavigator.Secondary.AddRange(HeaderAppNavigatorSecondary.SelectMany(x => x.CreateInstance<IControlDropdownItem>(this, context.Request)));
            context.VisualTree.Header.AppNavigation.Preferences.AddRange(HeaderNavigationPreferences.SelectMany(x => x.CreateInstance<IControlNavigationItem>(this, context.Request)));
            context.VisualTree.Header.AppNavigation.Primary.AddRange(HeaderNavigationPrimary.SelectMany(x => x.CreateInstance<IControlNavigationItem>(this, context.Request)));
            context.VisualTree.Header.AppNavigation.Secondary.AddRange(HeaderNavigationSecondary.SelectMany(x => x.CreateInstance<IControlNavigationItem>(this, context.Request)));
            context.VisualTree.Header.QuickCreate.Preferences.AddRange(HeaderQuickCreatePreferences.SelectMany(x => x.CreateInstance<IControlSplitButtonItem>(this, context.Request)));
            context.VisualTree.Header.QuickCreate.Primary.AddRange(HeaderQuickCreatePrimary.SelectMany(x => x.CreateInstance<IControlSplitButtonItem>(this, context.Request)));
            context.VisualTree.Header.QuickCreate.Secondary.AddRange(HeaderQuickCreateSecondary.SelectMany(x => x.CreateInstance<IControlSplitButtonItem>(this, context.Request)));
            context.VisualTree.Header.Help.Preferences.AddRange(HeaderHelpPreferences.SelectMany(x => x.CreateInstance<IControlDropdownItem>(this, context.Request)));
            context.VisualTree.Header.Help.Primary.AddRange(HeaderHelpPrimary.SelectMany(x => x.CreateInstance<IControlDropdownItem>(this, context.Request)));
            context.VisualTree.Header.Help.Secondary.AddRange(HeaderHelpSecondary.SelectMany(x => x.CreateInstance<IControlDropdownItem>(this, context.Request)));
            context.VisualTree.Header.Settings.Preferences.AddRange(HeaderSettingsPreferences.SelectMany(x => x.CreateInstance<IControlDropdownItem>(this, context.Request)));
            context.VisualTree.Header.Settings.Primary.AddRange(HeaderSettingsPrimary.SelectMany(x => x.CreateInstance<IControlDropdownItem>(this, context.Request)));
            context.VisualTree.Header.Settings.Secondary.AddRange(HeaderSettingsSecondary.SelectMany(x => x.CreateInstance<IControlDropdownItem>(this, context.Request)));

            // sidebar
            context.VisualTree.Sidebar.Header.AddRange(SidebarHeader.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Sidebar.Preferences.AddRange(SidebarPreferences.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Sidebar.Primary.AddRange(SidebarPrimary.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Sidebar.Secondary.AddRange(SidebarSecondary.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));

            // headline
            context.VisualTree.Content.Headline.Prologue.AddRange(ContentHeadlinePrologue.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Content.Headline.Preferences.AddRange(ContentHeadlinePreferences.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Content.Headline.Primary.AddRange(ContentHeadlinePrimary.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Content.Headline.Secondary.AddRange(ContentHeadlineSecondary.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Content.Headline.MorePreferences.AddRange(ContentHeadlineMorePreferences.SelectMany(x => x.CreateInstance<IControlDropdownItem>(this, context.Request)));
            context.VisualTree.Content.Headline.MorePrimary.AddRange(ContentHeadlineMorePrimary.SelectMany(x => x.CreateInstance<IControlDropdownItem>(this, context.Request)));
            context.VisualTree.Content.Headline.MoreSecondary.AddRange(ContentHeadlineMoreSecondary.SelectMany(x => x.CreateInstance<IControlDropdownItem>(this, context.Request)));
            context.VisualTree.Content.Headline.Metadata.AddRange(ContentHeadlineMetadata.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));

            // property
            context.VisualTree.Content.Property.Preferences.AddRange(ContentPropertyPreferences.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Content.Property.Primary.AddRange(ContentPropertyPrimary.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Content.Property.Secondary.AddRange(ContentPropertySecondary.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));

            // content
            context.VisualTree.Content.Preferences.AddRange(ContentPreferences.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Content.Primary.AddRange(ContentPrimary.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Content.Secondary.AddRange(ContentSecondary.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));

            // footer
            context.VisualTree.Footer.Preferences.AddRange(FooterPreferences.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Footer.Primary.AddRange(FooterPrimary.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));
            context.VisualTree.Footer.Secondary.AddRange(FooterSecondary.SelectMany(x => x.CreateInstance<IControl>(this, context.Request)));

            if (context.VisualTree is VisualTreeControl visualTreeControl)
            {
                var split = new ControlPanelSplit
                (
                    "split",
                    [context.VisualTree.Sidebar],
                    [context.VisualTree.Content]
                )
                {
                    Orientation = TypeOrientationSplit.Horizontal,
                    SplitterColor = LayoutSchema.SplitterColor,
                    Panel1InitialSize = 20,
                    Panel1MinSize = 150,
                    Styles = ["min-height: 85%;"]
                };

                visualTreeControl.Content.Add(context.VisualTree.Header);
                visualTreeControl.Content.Add(context.VisualTree.Toast);
                visualTreeControl.Content.Add(context.VisualTree.Breadcrumb);
                visualTreeControl.Content.Add(context.VisualTree.Prologue);
                visualTreeControl.Content.Add(context.VisualTree.SearchOptions);
                visualTreeControl.Content.Add(context.VisualTree.Sidebar.HasContent ? split : context.VisualTree.Content);
                visualTreeControl.Content.Add(context.VisualTree.Footer);
                visualTreeControl.Content.Add(new ControlApiNotificationPopup("popup_notification"));
            }
        }
    }
}
