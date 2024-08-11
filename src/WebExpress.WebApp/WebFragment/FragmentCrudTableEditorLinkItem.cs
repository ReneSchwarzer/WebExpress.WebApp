using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebFragment
{
    /// <summary>
    /// Meta information of a CRUD table function.
    /// </summary>
    public class FragmentCrudTableEditorLinkItem : FragmentCrudTableEditorItem
    {
        /// <summary>
        /// Returns or sets the label.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Returns or sets the icon.
        /// </summary>
        public PropertyIcon Icon { get; set; }

        /// <summary>
        /// Returns or sets the color.
        /// </summary>
        public PropertyColorText Color { get; set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="label">The label of the column.</param>
        public FragmentCrudTableEditorLinkItem(string label)
        {
            Label = label;
        }
    }
}
