using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnockoutHelpers.Util;

namespace KnockoutHelpers.Entities
{
    /// <summary>
    /// Helper class for enabling nicer knockout containerless 'with' control flow
    /// </summary>
    public class KnockoutContainerlessWithStatement : KnockoutContainerlessControlFlowStatement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KnockoutContainerlessWithStatement" /> class.
        /// </summary>
        /// <param name="writeAction">The view context.</param>
        /// <param name="withExpression">The with expression.</param>
        public KnockoutContainerlessWithStatement(ViewContext viewContext, string withExpression) :
            base(viewContext, "with: {0}".ToFormattedString(withExpression))
        {
        }
    }
}