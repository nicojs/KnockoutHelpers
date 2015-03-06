using KnockoutHelpers.Entities;
using KnockoutHelpers.Helpers;
using KnockoutHelpers.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace KnockoutHelpers.Models
{
    /// <summary>
    /// Represents a meta data class to be used in knockout templating
    /// </summary>
    /// <typeparam name="TJsonModel">The type of the model which will be send as json to the client.</typeparam>
    public class KnockoutViewModel<TJsonModel>
        where TJsonModel : JsonViewModel
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="KnockoutViewModel{TJsonModel}" /> class.
        /// </summary>
        public KnockoutViewModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnockoutViewModel{TJsonModel}" /> class.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        public KnockoutViewModel(string entityId)
        {
            EntityId = entityId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KnockoutViewModel{TJsonModel}" /> class.
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        public KnockoutViewModel(int entityId)
        {
            EntityId = entityId.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        /// <value>
        /// The entity id.
        /// </value>
        public string EntityId { get; set; }

        /// <summary>
        /// Retrieves the pathes to object.
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public string PathTo<TValue>(Expression<Func<TJsonModel, TValue>> expression)
        {
            return ExpressionHelper.GetExpressionText(expression);
        }
        
        /// <summary>
        /// Retrieves a knockout equals expression
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public string EqualsExpressionFor<TValue>(Expression<Func<TJsonModel, TValue>> expression, TValue value)
        {
            return KnockoutHelper.EqualsExpression(PathTo(expression), value);
        }

        /// <summary>
        /// Retrieves a knockout equals expression
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public string ExpressionFor<TValue>(Expression<Func<TJsonModel, TValue>> expression, TValue value, string operatorText)
        {
            return KnockoutHelper.BinaryExpression(PathTo(expression), value, operatorText);
        }


        /// <summary>
        /// Retrieves a knockout equals expression
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public string NotEqualsExpressionFor<TValue>(Expression<Func<TJsonModel, TValue>> expression, TValue value)
        {
            return KnockoutHelper.EqualsExpression(PathTo(expression), value);
        }

        /// <summary>
        /// Retrieves a text binding for the expression. Like: "text: Title"
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public string TextBindingFor<TValue>(Expression<Func<TJsonModel, TValue>> expression)
        {
            return "text: " + PathTo(expression);
        }

        /// <summary>
        /// Retrieves a single attribut binding for the expression. Like: "attr: { title: value }".
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public string AttributeBindingFor<TValue>(string attributeName, Expression<Func<TJsonModel, TValue>> expression)
        {
            return "attr: {{ {0}: {1} }}".ToFormattedString(attributeName, PathTo(expression));
        }


        /// <summary>
        /// Retrieves a single attribut binding for the expression. Like: "attr: { title: value }".
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <typeparam name="TValue2">The type of the value2.</typeparam>
        /// <typeparam name="TValue3">The type of the value3.</typeparam>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="attributeName2">The attribute name2.</param>
        /// <param name="expression2">The expression2.</param>
        /// <param name="attributeName3">The attribute name3.</param>
        /// <param name="expression3">The expression3.</param>
        /// <returns></returns>
        public string AttributeBindingFor<TValue, TValue2, TValue3>(string attributeName, Expression<Func<TJsonModel, TValue>> expression, 
            string attributeName2, Expression<Func<TJsonModel, TValue2>> expression2,
            string attributeName3, Expression<Func<TJsonModel, TValue3>> expression3)
        {
            return "attr: {{ {0}: {1}, {2}: {3}, {4}: {5} }}".ToFormattedString(attributeName, PathTo(expression), attributeName2, PathTo(expression2), attributeName3, PathTo(expression3));
        }



        /// <summary>
        /// Retrieves a single attribut binding for the expression. Like: "attr: { title: value }".
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="attributeName">Name of the attribute.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="expression2">The expression2.</param>
        /// <returns></returns>
        public string AttributeBindingFor<TValue, TValue2>(string attributeName, Expression<Func<TJsonModel, TValue>> expression, string attributeName2, Expression<Func<TJsonModel, TValue2>> expression2)
        {
            return "attr: {{ {0}: {1}, {2}: {3} }}".ToFormattedString(attributeName, PathTo(expression), attributeName2, PathTo(expression2));
        }


        /// <summary>
        /// Retireves a visible binding for the expression. Like: "visible: visible"
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public IHtmlString VisibleBindingFor<TValue>(Expression<Func<TJsonModel, TValue>> expression)
        {
            return MvcHtmlString.Create("visible: " + PathTo(expression));
        }


        /// <summary>
        /// Retrieves a span with binding for the expression. Like: "&gt;span data-bind="text: Title" /&l;".
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public IHtmlString SpanWithBindingFor<TValue>(Expression<Func<TJsonModel, TValue>> expression)
        {
            return MvcHtmlString.Create(@"<span data-bind=""{0}""/>".ToFormattedString(TextBindingFor(expression)));
        }

    }
}