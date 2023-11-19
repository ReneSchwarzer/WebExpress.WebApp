using WebExpress.Core.WebMessage;
using WebExpress.WebUI.WebControl;

namespace WebExpress.WebApp.WebControl
{
    public class FormularUploadEventArgs : FormularEventArgs
    {
        /// <summary>
        /// Returns or sets the file.
        /// </summary>
        public ParameterFile File { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args">The event argument.</param>
        public FormularUploadEventArgs(FormularEventArgs args)
        {
            Context = args.Context;
        }
    }
}
