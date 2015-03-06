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
    public class KnockoutContainerlessForEachStatement : KnockoutContainerlessControlFlowStatement
    {
        public string _expressionText { get; set; }

        public KnockoutContainerlessForEachStatement(ViewContext viewContext, string expressionText) :
            base(viewContext, "foreach: {0}".ToFormattedString(expressionText))
        {
            _expressionText = expressionText;
        }

    }
}