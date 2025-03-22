﻿using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebSettingPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebIcon;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// Settings controls for a web app.
    /// </summary>
    public class ControlWebAppHeaderSettings : Control
    {
        private readonly List<IControlDropdownItem> _preferences = [];
        private readonly List<IControlDropdownItem> _primary = [];
        private readonly List<IControlDropdownItem> _secondary = [];

        /// <summary>
        /// Returns the preferences area.
        /// </summary>
        public IEnumerable<IControlDropdownItem> Preferences => _preferences;

        /// <summary>
        /// Returns the primary area.
        /// </summary>
        public IEnumerable<IControlDropdownItem> Primary => _primary;

        /// <summary>
        /// Returns the secondary area.
        /// </summary>
        public IEnumerable<IControlDropdownItem> Secondary => _secondary;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppHeaderSettings(string id = null)
            : base(id)
        {
            Padding = new PropertySpacingPadding(PropertySpacing.Space.Null);
        }

        /// <summary>
        /// Adds items to the preferences area.
        /// </summary>
        /// <param name="items">The items to add to the preferences area.</param>
        public void AddPreferences(params IControlDropdownItem[] items)
        {
            _preferences.AddRange(items);
        }

        /// <summary>
        /// Removes an item from the preferences area.
        /// </summary>
        /// <param name="item">The item to remove from the preferences area.</param>
        public void RemovePreference(IControlDropdownItem item)
        {
            _preferences.Remove(item);
        }

        /// <summary>
        /// Adds items to the primary area.
        /// </summary>
        /// <param name="items">The items to add to the primary area.</param>
        public void AddPrimary(params IControlDropdownItem[] items)
        {
            _primary.AddRange(items);
        }

        /// <summary>
        /// Removes an item from the primary area.
        /// </summary>
        /// <param name="item">The item to remove from the primary area.</param>
        public void RemovePrimary(IControlDropdownItem item)
        {
            _primary.Remove(item);
        }

        /// <summary>
        /// Adds items to the secondary area.
        /// </summary>
        /// <param name="items">The items to add to the secondary area.</param>
        public void AddSecondary(params IControlDropdownItem[] items)
        {
            _secondary.AddRange(items);
        }

        /// <summary>
        /// Removes an item from the secondary area.
        /// </summary>
        /// <param name="item">The item to remove from the secondary area.</param>
        public void RemoveSecondary(IControlDropdownItem item)
        {
            _secondary.Remove(item);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var items = GetItems(renderContext);

            var settingCtlr = items.Any() ?
            new ControlDropdown(Id, [.. items])
            {
                Icon = new IconCog(),
                AlignmentMenu = TypeAlignmentDropdownMenu.Right,
                BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None)
            } :
            null;

            return settingCtlr?.Render(renderContext, visualTree);
        }

        /// <summary>
        /// Retrieves the items to be displayed in the dropdown.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>A collection of dropdown items.</returns>
        private IEnumerable<IControlDropdownItem> GetItems(IRenderControlContext renderContext)
        {
            var settinPageManager = WebEx.ComponentHub.SettingPageManager;
            var appicationContext = renderContext.PageContext?.ApplicationContext;
            var preferenceCategories = settinPageManager?.GetSettingCategories(appicationContext)
                .Where(x => x.Section == SettingSection.Preferences)
                .Select
                (
                    x => new ControlDropdownItemLink()
                    {
                        Text = I18N.Translate(renderContext, x?.Name),
                        Uri = settinPageManager.GetFirstSettingPage(appicationContext, x)?.Uri,
                        Icon = x.Icon
                    }
                );
            var primaryCategories = settinPageManager?.GetSettingCategories(appicationContext)
                .Where(x => x.Section == SettingSection.Primary)
                .Select
                (
                    x => new ControlDropdownItemLink()
                    {
                        Text = I18N.Translate(renderContext, x?.Name),
                        Uri = settinPageManager.GetFirstSettingPage(appicationContext, x)?.Uri,
                        Icon = x.Icon
                    }
                );
            var secondaryCategories = settinPageManager?.GetSettingCategories(appicationContext)
                .Where(x => x.Section == SettingSection.Secondary)
                .Select
                (
                    x => new ControlDropdownItemLink()
                    {
                        Text = I18N.Translate(renderContext, x?.Name),
                        Uri = settinPageManager.GetFirstSettingPage(appicationContext, x)?.Uri,
                        Icon = x.Icon
                    }
                );

            var preferences = Preferences.Union(WebEx.ComponentHub.FragmentManager.GetFragments<FragmentControlDropdownItemLink, SectionAppSettingsPreferences>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            ));

            var primary = Primary.Union(WebEx.ComponentHub.FragmentManager.GetFragments<FragmentControlDropdownItemLink, SectionAppSettingsPrimary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            ));

            var secondary = Secondary.Union(WebEx.ComponentHub.FragmentManager.GetFragments<FragmentControlDropdownItemLink, SectionAppSettingsSecondary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            ));

            if (preferences.Any() || primary.Any() || secondary.Any() || preferenceCategories.Any())
            {
                yield return new ControlDropdownItemHeader(I18N.Translate(renderContext.Request, "webexpress.webapp:header.setting.label"));
            }

            foreach (var item in preferenceCategories)
            {
                yield return item;
            }

            foreach (var item in preferences)
            {
                yield return item;
            }

            if ((preferenceCategories.Any() || preferences.Any()) && (primary.Any() || secondary.Any()))
            {
                yield return new ControlDropdownItemDivider();
            }

            foreach (var item in primaryCategories)
            {
                yield return item;
            }

            foreach (var item in primary)
            {
                yield return item;
            }

            if ((primaryCategories.Any() || primary.Any()) && secondary.Any())
            {
                yield return new ControlDropdownItemDivider();
            }

            foreach (var item in secondaryCategories)
            {
                yield return item;
            }

            foreach (var item in secondary)
            {
                yield return item;
            }
        }
    }
}
