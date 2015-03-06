using KnockoutHelpers.Entities;
using KnockoutHelpers.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using KnockoutHelpers.Util;

namespace KnockoutHelpers.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class KnockoutHelperExtensions
    {

        private const string KNOCKOUT_SUMMARY_TEMPLATES_LOCATION = "KnockoutSummaryTemplates/";
        private const string KNOCKOUT_DISPLAY_TEMPLATES_LOCATION = "KnockoutDisplayTemplates/";
        private const string KNOCKOUT_EDITOR_TEMPLATES_LOCATION = "KnockoutEditorTemplates/";

        /// <summary>
        /// Displays a knockout summary for the type
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="modelType">Type of the model.</param>
        /// <returns></returns>
        public static MvcHtmlString KnockoutSummary<TJsonModel>(this HtmlHelper helper)
            where TJsonModel : JsonViewModel
        {
            var modelType = typeof(TJsonModel);
            return helper.KnockoutPartial<TJsonModel>(String.Concat(KNOCKOUT_SUMMARY_TEMPLATES_LOCATION, modelType.Name));
        }

        /// <summary>
        /// Displays a knockout display template
        /// </summary>
        /// <param name="helper">The helper.</param>
        /// <param name="modelType">Type of the model.</param>
        /// <returns></returns>
        public static MvcHtmlString KnockoutDisplay<TJsonModel>(this HtmlHelper helper)
            where TJsonModel : JsonViewModel
        {
            var modelType = typeof(TJsonModel);
            return helper.KnockoutPartial<TJsonModel>(String.Concat(KNOCKOUT_DISPLAY_TEMPLATES_LOCATION, modelType.Name));
        }

        /// <summary>
        /// Displays a knockout editor template
        /// </summary>
        /// <typeparam name="TJsonModel">The type of the json model.</typeparam>
        /// <param name="helper">The helper.</param>
        /// <returns></returns>
        public static MvcHtmlString KnockoutEditor<TJsonModel>(this HtmlHelper helper)
               where TJsonModel : JsonViewModel
        {
            var modelType = typeof(TJsonModel);
            return helper.KnockoutPartial<TJsonModel>(String.Concat(KNOCKOUT_EDITOR_TEMPLATES_LOCATION, modelType.Name));
        }

        /// <summary>
        /// Renders a knockout template as a partial.
        /// </summary>
        /// <typeparam name="TJsonModel">The type of the json model.</typeparam>
        /// <param name="helper">The helper.</param>
        /// <param name="viewName">Name of the view.</param>
        /// <returns></returns>
        public static MvcHtmlString KnockoutPartial<TJsonModel>(this HtmlHelper helper, string viewName)
            where TJsonModel : JsonViewModel
        {
            return helper.Partial(viewName, new KnockoutViewModel<TJsonModel>());
        }

        /// <summary>
        /// Retrieves a disposable object. On creation, outputs a knockout containerless control flow if statement. On disposed, it is closed.
        /// </summary>
        /// <typeparam name="TJsonModel">The type of the json model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="ko">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="expected">The expected value.</param>
        /// <returns></returns>
        public static KnockoutContainerlessIfStatement IfFor<TJsonModel, TValue>(this KnockoutHelper<KnockoutViewModel<TJsonModel>> ko, Expression<Func<TJsonModel, TValue>> expression, TValue expected)
            where TJsonModel : JsonViewModel
        {
            return ko.If(ko.Model.PathTo(expression), expected);
        }

        /// <summary>
        /// Retrieves a disposable object. On creation, outputs a knockout containerless control flow if statement. On disposed, it is closed.
        /// </summary>
        /// <typeparam name="TJsonModel">The type of the json model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="ko">The ko.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="operatorText">The operator text.</param>
        /// <returns></returns>
        public static KnockoutContainerlessIfStatement IfFor<TJsonModel, TValue>(this KnockoutHelper<KnockoutViewModel<TJsonModel>> ko, Expression<Func<TJsonModel, TValue>> expression, TValue expected, string operatorText)
                    where TJsonModel : JsonViewModel
        {
            return ko.If(ko.Model.PathTo(expression), expected, operatorText);
        }

        /// <summary>
        /// Retrieves a disposable object. On creation, outputs a knockout containerless control flow if-not statement. On disposed, it is closed.
        /// </summary>
        /// <typeparam name="TJsonModel">The type of the json model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="ko">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="expected">The expected value.</param>
        /// <returns></returns>
        public static KnockoutContainerlessIfStatement IfNotFor<TJsonModel, TValue>(this KnockoutHelper<KnockoutViewModel<TJsonModel>> ko, Expression<Func<TJsonModel, TValue>> expression, TValue expected)
            where TJsonModel : JsonViewModel
        {
            return ko.IfNot(ko.Model.PathTo(expression), expected);
        }

        /// <summary>
        /// Retrieves a disposable object. On creation, outputs a knockout containerless control flow 'with' statement. On disposed, it is closed.
        /// </summary>
        /// <typeparam name="TJsonModel">The type of the json model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="ko">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static KnockoutContainerlessWithStatement WithFor<TJsonModel, TValue>(this KnockoutHelper<KnockoutViewModel<TJsonModel>> ko, Expression<Func<TJsonModel, TValue>> expression)
            where TJsonModel : JsonViewModel
        {
            return ko.With(ko.Model.PathTo(expression));
        }

        /// <summary>
        /// Retrieves a disposable object. On creation, outputs a knockout containerless control flow if statement. On disposed, it is closed.
        /// </summary>
        /// <typeparam name="TJsonModel">The type of the json model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="ko">The ko.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static KnockoutContainerlessIfStatement IfFor<TJsonModel, TValue>(this KnockoutHelper<KnockoutViewModel<TJsonModel>> ko, Expression<Func<TJsonModel, TValue>> expression)
            where TJsonModel : JsonViewModel
        {
            return ko.If(ko.Model.PathTo(expression));
        }

        /// <summary>
        /// Retrieves a disposable object which emits a containerless switch statement. On disposing closes the switch statement.
        /// </summary>
        /// <typeparam name="TJsonModel">The type of the json model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="ko">The HTML.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="firstCaseValue">The first case value.</param>
        /// <returns></returns>
        public static KnockoutContainerlessSwitchStatement<TValue> SwitchFor<TJsonModel, TValue>(this KnockoutHelper<KnockoutViewModel<TJsonModel>> ko, Expression<Func<TJsonModel, TValue>> expression, TValue firstCaseValue)
            where TJsonModel : JsonViewModel
        {
            return ko.Switch(ko.Model.PathTo(expression), firstCaseValue);
        }

        /// <summary>
        /// Retrieves a disposable object which emits a containerless foreach statement for given expression. On disposing closes the foreach statement.
        /// </summary>
        /// <typeparam name="TJsonModel">The type of the json model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="ko">The ko.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static KnockoutContainerlessForEachStatement ForEachFor<TJsonModel, TValue>(this KnockoutHelper<KnockoutViewModel<TJsonModel>> ko, Expression<Func<TJsonModel, TValue>> expression)
            where TJsonModel : JsonViewModel
        {
            return ko.ForEach(ko.Model.PathTo(expression));
        }

        /// <summary>
        /// Retrieves a knockout formatted message. Fills the parameter with a knockout binded span tag.
        /// </summary>
        /// <typeparam name="TJsonModel">The type of the json model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="ko">The HTML.</param>
        /// <param name="messageFactory">The message factory.</param>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static IHtmlString MessageFor<TJsonModel, TValue>(this KnockoutHelper<KnockoutViewModel<TJsonModel>> ko, Func<object, string> messageFactory, Expression<Func<TJsonModel, TValue>> expression)
            where TJsonModel : JsonViewModel
        {
            return ko.Message(messageFactory, ko.Model.PathTo(expression));
        }

    }
}