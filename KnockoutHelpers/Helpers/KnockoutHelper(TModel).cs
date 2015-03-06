using KnockoutHelpers.Entities;
using KnockoutHelpers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnockoutHelpers.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public class KnockoutHelper<TModel> : KnockoutHelper
    {
        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public TModel Model { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnockoutHelper{TJsonModel}" /> class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <param name="model">The model.</param>
        public KnockoutHelper(ViewContext viewContext, TModel model)
            : base(viewContext)
        {
            Model = model;
        }

    }
}