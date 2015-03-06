using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnockoutHelpers.Util;

namespace KnockoutHelpers.Entities
{
    /// <summary>
    /// Helper class for enabling nicer knockout containerless control flow
    /// </summary>
    public class KnockoutContainerlessWithIfElseLoadingStatement : KnockoutContainerlessIfStatement
    {
        private KnockoutContainerlessWithStatement _innerWithStatement;

        /// <summary>
        /// Initializes a new instance of the <see cref="KnockoutContainerlessWithIfElseLoadingStatement" /> class.
        /// Combines an 'if - else { loading }' with a 'with' statement
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        /// <param name="expressionText">The expression text.</param>
        public KnockoutContainerlessWithIfElseLoadingStatement(ViewContext viewContext, string expressionText) :
            base(viewContext, expressionText)
        {
            _expressionText = expressionText;
            _innerWithStatement = new KnockoutContainerlessWithStatement(viewContext, expressionText);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _innerWithStatement.Dispose();
            Else();
            Emit(@"<div class=""content-loading-overlay""><img src=""{0}"" alt=""Loading"" /></div>".ToFormattedString(Links.Content.images.ajax_loader_big_gif));
            base.Dispose(disposing);
        }

    }
}