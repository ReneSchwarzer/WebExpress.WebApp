﻿using System.Collections.Generic;
using System.Linq;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// Settings controls for a web app.
    /// </summary>
    public class ControlWebAppHeaderSettings : Control
    {
        /// <summary>
        /// Returns or sets the preferences area.
        /// </summary>
        public List<IControlDropdownItem> Preferences { get; protected set; } = new List<IControlDropdownItem>();

        /// <summary>
        /// Returns or sets the primary area.
        /// </summary>
        public List<IControlDropdownItem> Primary { get; protected set; } = new List<IControlDropdownItem>();

        /// <summary>
        /// Returns or sets the secondary area.
        /// </summary>
        public List<IControlDropdownItem> Secondary { get; protected set; } = new List<IControlDropdownItem>();

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
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            var preferences = WebEx.ComponentHub.FragmentManager.GetFragments<FragmentControlDropdownItemLink, SectionAppQuickcreatePreferences>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var primary = WebEx.ComponentHub.FragmentManager.GetFragments<FragmentControlDropdownItemLink, SectionAppQuickcreatePrimary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var secondary = WebEx.ComponentHub.FragmentManager.GetFragments<FragmentControlDropdownItemLink, SectionAppQuickcreateSecondary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var settingsList = new List<IControlDropdownItem>
            {
                new ControlDropdownItemHeader() { Text = I18N.Translate(renderContext.Request?.Culture, "webexpress.webapp:header.setting.label") }
            };

            var preferencesList = Preferences.Union(preferences).ToList();
            var primaryList = Primary.Union(primary).ToList();
            var secondaryList = Secondary.Union(secondary).ToList();

            settingsList.AddRange(preferencesList);
            if (preferencesList.Count > 0 && primaryList.Count > 0)
            {
                settingsList.Add(new ControlDropdownItemDivider());
            }

            settingsList.AddRange(primaryList);
            if (primaryList.Count > 0 && secondaryList.Count > 0)
            {
                settingsList.Add(new ControlDropdownItemDivider());
            }

            settingsList.AddRange(secondaryList);

            var settings = (settingsList.Count > 1) ?
            new ControlDropdown(Id, settingsList.ToArray())
            {
                Icon = new PropertyIcon(TypeIcon.Cog),
                AlignmentMenu = TypeAlignmentDropdownMenu.Right,
                BackgroundColor = new PropertyColorButton(TypeColorButton.Dark),
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None)
            } :
            null;

            return settings?.Render(renderContext);
        }
    }
}
