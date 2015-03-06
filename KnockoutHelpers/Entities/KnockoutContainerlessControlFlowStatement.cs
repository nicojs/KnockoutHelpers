using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KnockoutHelpers.Util;
using System.Web.Mvc;

namespace KnockoutHelpers.Entities
{
    /// <summary>
    /// Helper class for enabling nicer knockout containerless control flow
    /// </summary>
    public class KnockoutContainerlessControlFlowStatement : IDisposable
    {

        private ViewContext _viewContext;

        public KnockoutContainerlessControlFlowStatement(ViewContext viewContext, string statementText)
        {
            _viewContext = viewContext;
            EmitOpenTag(statementText);
        }

        /// <summary>
        /// Emits &lt;!-- ko {0} --&gt;
        /// </summary>
        /// <param name="text">The text.</param>
        protected void EmitOpenTag(string text)
        {
            Emit("<!-- ko {0} -->".ToFormattedString(text));
        }

        /// <summary>
        /// Emits &lt;!-- /ko --&gt;;
        /// </summary>
        protected void EmitEndTag()
        {
            Emit("<!-- /ko -->");
        }

        /// <summary>
        /// Emits (output in view) the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        protected void Emit(string text)
        {
            _viewContext.Writer.Write(text);
        }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                EmitEndTag();
            }
        }

        #endregion
    }
}