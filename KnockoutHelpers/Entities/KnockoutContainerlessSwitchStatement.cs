using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnockoutHelpers.Util;
using KnockoutHelpers.Helpers;

namespace KnockoutHelpers.Entities
{
    /// <summary>
    /// Helper class for enabling nicer knockout containerless 'switch statement'-like flow
    /// </summary>
    public class KnockoutContainerlessSwitchStatement<TValue> : KnockoutContainerlessControlFlowStatement
    {
        public string _expressionText { get; set; }

        public KnockoutContainerlessSwitchStatement(ViewContext viewContext, string expressionText, TValue firstCaseValue) :
            base(viewContext, "if: {0}".ToFormattedString(KnockoutHelper.EqualsExpression(expressionText, firstCaseValue)))
        {
            _expressionText = expressionText;
        }

        /// <summary>
        /// Generates a knock out case statement (end if, if expressionText === nextCaseValue).
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Cannot be called twice</exception>
        public void Case(TValue nextCaseValue)
        {
            EmitEndTag();
            EmitOpenTag("if: {0}".ToFormattedString(KnockoutHelper.EqualsExpression(_expressionText, nextCaseValue)));
        }
    }
}