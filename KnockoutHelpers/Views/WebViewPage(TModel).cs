using KnockoutHelpers.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnockoutHelpers.Views
{
    /// <summary>
    /// Represents a base class for all view pages with a view model.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public abstract class WebViewPage<TModel> : WebViewPage
    {
        /// <summary>
        /// Gets or sets the knockout helper.
        /// </summary>
        /// <value>
        /// The ko.
        /// </value>
        public new KnockoutHelper<TModel> Ko { get; private set; }

        private ViewDataDictionary<TModel> _viewData;

        public new AjaxHelper<TModel> Ajax { get; set; }

        public new HtmlHelper<TModel> Html { get; set; }

        public new TModel Model
        {
            get { return ViewData.Model; }
        }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "This is the mechanism by which the ViewPage gets its ViewDataDictionary object.")]
        public new ViewDataDictionary<TModel> ViewData
        {
            get
            {
                if (_viewData == null)
                {
                    SetViewData(new ViewDataDictionary<TModel>());
                }
                return _viewData;
            }
            set { SetViewData(value); }
        }

        public override void InitHelpers()
        {
            base.InitHelpers();

            Ajax = new AjaxHelper<TModel>(ViewContext, this);
            Html = new HtmlHelper<TModel>(ViewContext, this);
            Ko = new KnockoutHelper<TModel>(ViewContext, Model);
        }

        protected override void SetViewData(ViewDataDictionary viewData)
        {
            _viewData = new ViewDataDictionary<TModel>(viewData);

            base.SetViewData(_viewData);
        }
    }
}