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
    public class KnockoutContainerlessIfStatement : KnockoutContainerlessControlFlowStatement
    {
        public bool _elseCalled { get; set; }
        public string _expressionText { get; set; }

        public KnockoutContainerlessIfStatement(ViewContext viewContext, string expressionText) :
            base(viewContext, "if: {0}".ToFormattedString(expressionText))
        {
            _expressionText = expressionText;
        }

        /// <summary>
        /// Generates a knock out else statement (end if, ifnot).
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Cannot be called twice</exception>
        public void Else()
        {
            if (_elseCalled)
            {
                throw new InvalidOperationException(TechnicalMessages.KnockOutIfStatementElseCalledTwice.ToFormattedString(_expressionText));
            }
            _elseCalled = true;
            EmitEndTag();
            EmitOpenTag("ifnot: {0}".ToFormattedString(_expressionText));
        }

    }
}