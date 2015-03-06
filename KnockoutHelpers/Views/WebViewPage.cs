using KnockoutHelpers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockoutHelpers.Views
{
    /// <summary>
    /// Represents a base class for all view pages
    /// </summary>
    public abstract class WebViewPage : System.Web.Mvc.WebViewPage
    {
        /// <summary>
        /// Gets or sets the knockout helper.
        /// </summary>
        /// <value>
        /// The ko.
        /// </value>
        public KnockoutHelper Ko { get; private set; }

        /// <summary>
        /// Inits the helpers.
        /// </summary>
        public override void InitHelpers()
        {
            base.InitHelpers();
            Ko = new KnockoutHelper(ViewContext);
        }


        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}