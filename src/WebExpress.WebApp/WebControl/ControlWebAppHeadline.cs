using System.Collections.Generic;
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
        /// <summary>
        /// Returns or sets the prologue area.
        /// </summary>
        public List<IControl> Prologue { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the preferences area.
        /// </summary>
        public List<IControl> Preferences { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the primary area.
        /// </summary>
        public List<IControl> Primary { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the secondary area.
        /// </summary>
        public List<IControl> Secondary { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the preferences area for the more control.
        /// </summary>
        public List<IControlDropdownItem> MorePreferences { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the primary area for the more control.
        /// </summary>
        public List<IControlDropdownItem> MorePrimary { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the secondary area for the more control.
        /// </summary>
        public List<IControlDropdownItem> MoreSecondary { get; protected set; } = [];

        /// <summary>
        /// Returns or sets the secondary area for the metadata.
        /// </summary>
        public List<IControl> Metadata { get; protected set; } = [];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The control id.</param>
        public ControlWebAppHeadline(string id = null)
            : base(id)
        {
            // BackgroundColor = LayoutSchema.HeadlineBackground;
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            var preferences = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionHeadlinePreferences>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var primary = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionHeadlinePrimary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var secondary = WebEx.ComponentHub.FragmentManager.GetFragments<IFragmentControl, SectionHeadlineSecondary>
            (
                renderContext?.PageContext?.ApplicationContext,
                renderContext?.PageContext?.Scopes
            );

            var preferencesList = Preferences.Union(preferences).ToList();
            var primaryList = Primary.Union(primary).ToList();
            var secondaryList = Secondary.Union(secondary).ToList();

            var prologue = new ControlPanelFlexbox(null, Prologue.ToArray()) { Layout = TypeLayoutFlexbox.Default, Align = TypeAlignFlexbox.Center, Justify = TypeJustifiedFlexbox.Start };
            prologue.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext.Request?.Culture, renderContext.PageContext?.PageTitle),
                //TextColor = LayoutSchema.HeadlineTitle,
                Format = TypeFormatText.H2,
                Padding = new PropertySpacingPadding(PropertySpacing.Space.One),
                Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.Null)
            });
            prologue.Add(Preferences);

            var epilog = new ControlPanelFlexbox(null, secondaryList.ToArray())
            {
                Layout = TypeLayoutFlexbox.Default,
                Align = TypeAlignFlexbox.Center,
                Justify = TypeJustifiedFlexbox.End
            };

            if (MorePreferences.Count() > 0 || MorePrimary.Count() > 0 || MoreSecondary.Count() > 0)
            {
                var more = new ControlDropdown("more")
                {
                    Text = I18N.Translate(renderContext.Request?.Culture, "webexpress.webapp:headline.more.title"),
                    Icon = new PropertyIcon(TypeIcon.EllipsisHorizontal),
                    //TextColor = LayoutSchema.HeadlineTitle,
                    Padding = new PropertySpacingPadding(PropertySpacing.Space.One),
                    Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.Two, PropertySpacing.Space.None, PropertySpacing.Space.Null)
                };

                foreach (var v in MorePreferences)
                {
                    more.Add(v);
                }

                if (MorePreferences.Count > 0 && (MorePrimary.Count > 0 || MoreSecondary.Count > 0))
                {
                    more.AddSeperator();
                }

                foreach (var v in MorePrimary)
                {
                    more.Add(v);
                }

                if (MorePrimary.Count() > 0 && MoreSecondary.Count > 0)
                {
                    more.AddSeperator();
                }

                foreach (var v in MoreSecondary)
                {
                    more.Add(v);
                }

                epilog.Add(more);
            }

            var content = new ControlPanelFlexbox
            (
                null,
                prologue,
                new ControlPanelFlexbox(null, primaryList.ToArray())
                {
                    Layout = TypeLayoutFlexbox.Default,
                    Align = TypeAlignFlexbox.Center,
                    Justify = TypeJustifiedFlexbox.End
                },
                epilog
            )
            {
                Layout = TypeLayoutFlexbox.Default,
                Align = TypeAlignFlexbox.Center,
                Justify = TypeJustifiedFlexbox.Between
            };

            var metadata = new HtmlElementTextContentDiv
            (
                Metadata.Select(x => x.Render(renderContext)).ToArray()
            )
            {
                Class = Css.Concatenate("ms-2 me-2 mb-3 text-secondary"),
                Style = Style.Concatenate("font-size:0.75rem;")
            };

            return new HtmlElementSectionHeader
            (
                content.Render(renderContext),
                Metadata.Count > 0 ? metadata : null
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
