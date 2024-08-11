using WebExpress.WebApp.WebControl;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.WebApp.WebFragment
{
    public class FragmentControlModalFormConfirmDelete : ControlModalFormConfirmDelete, IFragment
    {
        /// <summary>
        /// Returns the context.
        /// </summary>
        public IFragmentContext FragmentContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The id of the fragment or null.</param>
        public FragmentControlModalFormConfirmDelete(string id = null)
            : base(id)
        {
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="page">The page where the fragment is active.</param>
        public virtual void Initialization(IFragmentContext context, IPage page)
        {
            FragmentContext = context;
        }
    }
}
