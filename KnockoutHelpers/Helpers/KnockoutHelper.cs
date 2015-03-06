using KnockoutHelpers.Entities;
using KnockoutHelpers.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnockoutHelpers.Helpers
{
    /// <summary>
    /// Helper class for knockout functionality
    /// </summary>
    public class KnockoutHelper
    {
     
        /// <summary>
        /// Gets the view context.
        /// </summary>
        /// <value>
        /// The view context.
        /// </value>
        public ViewContext ViewContext { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnockoutHelper" /> class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        public KnockoutHelper(ViewContext viewContext)
        {
            ViewContext = viewContext;
        }

        /// <summary>
        /// Helper method for a containerless if statement.
        /// </summary>
        /// <param name="expressionText">The expression.</param>
        /// <returns></returns>
        public KnockoutContainerlessIfStatement If(string expressionText)
        {
            return new KnockoutContainerlessIfStatement(ViewContext, expressionText);
        }

        /// <summary>
        /// Helper method for a containerless if statement with an equals expression.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expressionText">The expression text.</param>
        /// <param name="expectedValue">The expected.</param>
        /// <returns></returns>
        public KnockoutContainerlessIfStatement If<TValue>(string expressionText, TValue expectedValue)
        {
            return new KnockoutContainerlessIfStatement(ViewContext, EqualsExpression(expressionText, expectedValue));
        }

        /// <summary>
        /// Helper method for a containerless if and with statement.
        /// Combines an 'if - else { loading }' with a 'with' statement
        /// </summary>
        /// <param name="expressionText">The expression text.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public KnockoutContainerlessWithIfElseLoadingStatement WithIfElseLoading(string expressionText)
        {
            return new KnockoutContainerlessWithIfElseLoadingStatement(ViewContext  , expressionText);
        }

        /// <summary>
        /// Helper method for a containerless if statement with an equals expression.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expressionText">The expression text.</param>
        /// <param name="expectedValue">The expected.</param>
        /// <param name="operatorText">The operator text.</param>
        /// <returns></returns>
        public KnockoutContainerlessIfStatement If<TValue>(string expressionText, TValue expectedValue, string operatorText)
        {
            return new KnockoutContainerlessIfStatement(ViewContext, BinaryExpression(expressionText, expectedValue, operatorText));
        }


        /// <summary>
        /// Helper method for a containerless if statement with an not-equals expression.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expressionText">The expression text.</param>
        /// <param name="expectedValue">The expected.</param>
        /// <returns></returns>
        internal KnockoutContainerlessIfStatement IfNot<TValue>(string expressionText, TValue expectedValue)
        {
            return new KnockoutContainerlessIfStatement(ViewContext, NotEqualsExpression(expressionText, expectedValue));
        }

        /// <summary>
        /// Retrieves a disposable object. On creation, outputs a knockout containerless control flow 'with' statement. On disposed, it is closed.
        /// </summary>
        /// <param name="withExpression">The expression text.</param>
        /// <returns></returns>
        public KnockoutContainerlessWithStatement With(string withExpression)
        {
            return new KnockoutContainerlessWithStatement(ViewContext, withExpression);
        }


        /// <summary>
        /// Retrieves a disposable object which emits a containerless switch statement. On disposing closes the switch statement.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="firstCaseValue">The first case value.</param>
        /// <returns></returns>
        public KnockoutContainerlessSwitchStatement<TValue> Switch<TValue>(string expression, TValue firstCaseValue)
        {
            return new KnockoutContainerlessSwitchStatement<TValue>(ViewContext, expression, firstCaseValue);
        }

        /// <summary>
        /// Retrieves a disposable object which emits a containerless foreach statement. On disposing closes the foreach statement.
        /// </summary>
        /// <param name="expressionText">The expression text.</param>
        /// <returns></returns>
        public KnockoutContainerlessForEachStatement ForEach(string expressionText)
        {
            return new KnockoutContainerlessForEachStatement(ViewContext, expressionText);
        }

        /// <summary>
        /// Retrieves a knockout formatted message. Fills the parameter with a knockout binded span tag.
        /// </summary>
        /// <param name="messageFactory">The message factory.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public IHtmlString Message(Func<object, string> messageFactory, object expression)
        {
            string msg = @"<span data-bind=""text: {0}""></span>".ToFormattedString(expression);
            return new HtmlString(messageFactory(msg));
        }

        /// <summary>
        /// Retrieves an equals knockout expression.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="knockoutPropertyText">The knockout property text.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string EqualsExpression<TValue>(string knockoutPropertyText, TValue value)
        {
            return BinaryExpression(knockoutPropertyText, value, "===");
        }

        /// <summary>
        /// Retrieves an not- equals knockout expression.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="knockoutPropertyText">The knockout property text.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string NotEqualsExpression<TValue>(string knockoutPropertyText, TValue value)
        {
            return BinaryExpression(knockoutPropertyText, value, "!==");
        }

        /// <summary>
        /// Retrieves a binary knockout expression.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="knockoutPropertyText">The knockout property text.</param>
        /// <param name="value">The value.</param>
        /// <param name="operatorText">The operator text.</param>
        /// <returns></returns>
        public static string BinaryExpression<TValue>(string knockoutPropertyText, TValue value, string operatorText)
        {
            string valueText = "'{0}'".ToFormattedString(value.ToString());
            if (typeof(TValue).IsEnum)
            {
                valueText = ((int)(value as ValueType)).ToString();
            }
            return "{0}() {1} {2}".ToFormattedString(knockoutPropertyText, operatorText, valueText);
        }



        /// <summary>
        /// Retrieves a knockout logical And expression.
        /// </summary>
        /// <param name="knockoutExpression">The knockout expression.</param>
        /// <param name="secondKnockoutExpression">The second knockout expression.</param>
        /// <returns></returns>
        public static string And(string knockoutExpression, string secondKnockoutExpression)
        {
            return LogicalExpression(knockoutExpression, "&&", secondKnockoutExpression);
        }


        /// <summary>
        /// Retrieves a logical knockout expression.
        /// </summary>
        /// <param name="knockoutExpression">The knockout expression.</param>
        /// <param name="operatorText">The operator as text.</param>
        /// <param name="secondKnockoutExpression">The second knockout expression.</param>
        /// <returns></returns>
        public static string LogicalExpression(string knockoutExpression, string operatorText, string secondKnockoutExpression)
        {
            return "({0} {1} {2})".ToFormattedString(knockoutExpression, operatorText, secondKnockoutExpression);
        }

    }
}