﻿//using System.Collections.Generic;
//using System.Linq;
//using WebExpress.WebCore.WebHtml;
//using WebExpress.WebCore.WebPage;
//using WebExpress.WebUI.WebFragment;
//using static WebExpress.WebCore.Internationalization.InternationalizationManager;

//namespace WebExpress.WebApp.WebFragment
//{
//    public abstract class FragmentCrudTable : FragmentControlPanel
//    {
//        /// <summary>
//        /// Returns the uri to the REST API interface.
//        /// </summary>
//        public string RestApiUri { get; protected set; }

//        /// <summary>
//        /// Returns the editors to manipulate the data.
//        /// </summary>
//        public ICollection<FragmentCrudTableEditorItem> Editors { get; } = new List<FragmentCrudTableEditorItem>();

//        /// <summary>
//        /// Initializes a new instance of the class.
//        /// </summary>
//        /// <param name="id">The fragment id.</param>
//        public FragmentCrudTable(string id = null)
//            : base(id)
//        {
//        }

//        /// <summary>
//        /// Initialization
//        /// </summary>
//        /// <param name="context">The context.</param>
//        /// <param name="page">The page where the fragment is active.</param>
//        public override void Initialization(IFragmentContext context, IPage page)
//        {
//            base.Initialization(context, page);
//        }

//        /// <summary>
//        /// Convert to html.
//        /// </summary>
//        /// <param name="context">The context in which the control is rendered.</param>
//        /// <returns>The control as html.</returns>
//        public override IHtmlNode Render(RenderContext context)
//        {
//            var search = $"Search: {{Placeholder: '{I18N(context.Culture, "webexpress.webapp:search.placeholder")}'}}";
//            var table = $"Table: {{}}";
//            var pagination = $"Pagination: {{ CSS: 'justify-content-end' }}";
//            var editors = $"Editors: [" + string.Join(",", Editors.Select
//            (
//                x =>
//                {
//                    if (x is FragmentCrudTableEditorLinkItem link)
//                    {
//                        return $"{{Label: '{I18N(context.Culture, link.Label)}', Icon: '{link.Icon.ToClass()}', Color: '{link.Color?.ToClass()}', CSS: 'dropdown-item' }}";
//                    }
//                    else if (x is FragmentCrudTableEditorSeperatorItem seperator)
//                    {
//                        return $"{{ CSS: 'dropdown-divider' }}";
//                    }

//                    return $"{{Label: '', Icon: '', Color: '' }}";
//                }
//            )) + "]";

//            var settings = $"{{{search}, {table}, {pagination}, {editors}}}";

//            context.VisualTree.AddScript
//            (
//                "webexpress.webapp.usermanagement.user",
//                $"var crud = new crudTable('{RestApiUri}', {settings}); var container = $('#{Id}'); container.append(crud.getCtrl);"
//            );

//            return base.Render(context);
//        }
//    }
//}
