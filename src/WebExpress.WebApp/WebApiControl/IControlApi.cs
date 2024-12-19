namespace WebExpress.WebApp.WebApiControl
{
    /// <summary>
    /// Interface for controlling API interactions.
    /// </summary>
    public interface IControlApi
    {
        /// <summary>
        /// Returns or sets the uri that determines the data.
        /// </summary>
        public string RestUri { get; set; }
    }
}
