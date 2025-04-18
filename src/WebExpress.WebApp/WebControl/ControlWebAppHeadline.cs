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
    /// Headline for an web app.
    /// </summary>
    public class ControlWebAppHeadline : Control
    {
        private readonly List<IControl> _prologue = [];
        private readonly List<IControl> _preferences = [];
        private readonly List<IControl> _primary = [];
        private readonly List<IControl> _secondary = [];
        private readonly List<IControl> _metadata = [];

        /// <summary>
        /// Returns the prologue area.
        /// </summary>
        public IEnumerable<IControl> Prologue => _prologue;

        /// <summary>
        /// Returns the preferences area.
        /// </summary>
        public IEnumerable<IControl> Preferences => _preferences;

        /// <summary>
        /// Returns the primary area.
        /// </summary>
        public IEnumerable<IControl> Primary => _primary;

        /// <summary>
        /// Returns the secondary area.
        /// </summary>
        public IEnumerable<IControl> Secondary => _secondary;

        /// <summary>
        /// Returns the secondary area for the metadata.
        /// </summary>
        public IEnumerable<IControl> Metadata => _metadata;

        /// <summary>
        /// Returns the more control.
        /// </summary>
        public ControlWebAppHeadlineMore More { get; } = new ControlWebAppHeadlineMore("wx-content-main-headline-more")
        {
        };

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppHeadline(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Adds items to the prologue area.
        /// </summary>
        /// <param name="items">The items to add to the prologue area.</param>
        public void AddPrologue(params IControlToolbarItem[] items)
        {
            _prologue.AddRange(items);
        }

        /// <summary>
        /// Removes an item from the prologue area.
        /// </summary>
        /// <param name="item">The item to remove from the prologue area.</param>
        public void RemovePrologue(IControlToolbarItem item)
        {
            _prologue.Remove(item);
        }

        /// <summary>
        /// Adds items to the preferences area.
        /// </summary>
        /// <param name="items">The items to add to the preferences area.</param>
        public void AddPreferences(params IControlToolbarItem[] items)
        {
            _preferences.AddRange(items);
        }

        /// <summary>
        /// Removes an item from the preferences area.
        /// </summary>
        /// <param name="item">The item to remove from the preferences area.</param>
        public void RemovePreference(IControlToolbarItem item)
        {
            _preferences.Remove(item);
        }

        /// <summary>
        /// Adds items to the primary area.
        /// </summary>
        /// <param name="items">The items to add to the primary area.</param>
        public void AddPrimary(params IControlToolbarItem[] items)
        {
            _primary.AddRange(items);
        }

        /// <summary>
        /// Removes an item from the primary area.
        /// </summary>
        /// <param name="item">The item to remove from the primary area.</param>
        public void RemovePrimary(IControlToolbarItem item)
        {
            _primary.Remove(item);
        }

        /// <summary>
        /// Adds items to the secondary area.
        /// </summary>
        /// <param name="items">The items to add to the secondary area.</param>
        public void AddSecondary(params IControlToolbarItem[] items)
        {
            _secondary.AddRange(items);
        }

        /// <summary>
        /// Removes an item from the secondary area.
        /// </summary>
        /// <param name="item">The item to remove from the secondary area.</param>
        public void RemoveSecondary(IControlToolbarItem item)
        {
            _secondary.Remove(item);
        }

        /// <summary>
        /// Adds items to the metadata area.
        /// </summary>
        /// <param name="items">The items to add to the metadata area.</param>
        public void AddMetadata(params IControlToolbarItem[] items)
        {
            _metadata.AddRange(items);
        }

        /// <summary>
        /// Removes an item from the metadata area.
        /// </summary>
        /// <param name="item">The item to remove from the metadata area.</param>
        public void RemoveMetadata(IControlToolbarItem item)
        {
            _metadata.Remove(item);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            var prologue = Prologue.Union(WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionHeadlinePrologue>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            ));

            var preferences = Preferences.Union(WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionHeadlinePreferences>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            ));

            var primary = Primary.Union(WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionHeadlinePrimary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            ));

            var secondary = Secondary.Union(WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionHeadlineSecondary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            ));

            var metadata = Metadata.Union(WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionHeadlineMetadata>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            ));

            return new HtmlElementSectionHeader
            (
                new ControlPanelFlexbox
                (
                    null,
                    prologue.Any() ? new ControlPanelFlexbox(null, [.. prologue])
                    {
                        Layout = TypeLayoutFlexbox.Default,
                        Align = TypeAlignFlexbox.Center,
                        Justify = TypeJustifiedFlexbox.Start
                    } : null,
                    new ControlText()
                    {
                        Text = I18N.Translate(renderContext.Request?.Culture, renderContext.PageContext?.PageTitle),
                        Format = TypeFormatText.H2,
                        Padding = new PropertySpacingPadding(PropertySpacing.Space.One),
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.Null)
                    },
                    preferences.Any() ? new ControlPanelFlexbox(null, [.. preferences])
                    {
                        Layout = TypeLayoutFlexbox.Default,
                        Align = TypeAlignFlexbox.Center,
                        Justify = TypeJustifiedFlexbox.Start
                    } : null,
                    primary.Any() ? new ControlPanelFlexbox(null, [.. primary])
                    {
                        Layout = TypeLayoutFlexbox.Default,
                        Align = TypeAlignFlexbox.Center,
                        Justify = TypeJustifiedFlexbox.Start
                    } : null,
                    secondary.Any() ? new ControlPanelFlexbox(null, [.. secondary])
                    {
                        Layout = TypeLayoutFlexbox.Default,
                        Align = TypeAlignFlexbox.Center,
                        Justify = TypeJustifiedFlexbox.End
                    } : null,
                    More
                )
                {
                    Layout = TypeLayoutFlexbox.Default,
                    Align = TypeAlignFlexbox.Center,
                    Justify = TypeJustifiedFlexbox.Between
                }.Render(renderContext, visualTree),
                metadata.Any() ? new HtmlElementTextContentDiv
                (
                    metadata.Select(x => x.Render(renderContext, visualTree)).ToArray()
                )
                {
                    Class = Css.Concatenate("ms-2 me-2 mb-3 text-secondary"),
                    Style = Style.Concatenate("font-size:0.75rem;")
                } : null
            )
            {
                Id = Id,
                Class = Css.Concatenate("", GetClasses()),
                Style = Style.Concatenate("display: block;", GetStyles()),
                Role = Role
            };
        }
    }
}
