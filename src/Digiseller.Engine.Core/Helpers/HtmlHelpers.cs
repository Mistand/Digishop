using System;
using Digiseller.Client.Core.Enums;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Digiseller.Engine.Core.Helpers
{
    public static class HtmlHelpers
    {

        public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {
            if (string.IsNullOrEmpty(cssClass))
                cssClass = "active";

            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (string.IsNullOrEmpty(controller))
                controller = currentController;

            if (string.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : string.Empty;
        }

        public static string PageClass(this IHtmlHelper htmlHelper)
        {
            var currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

        public static string DigisellerImage(this IHtmlHelper html, int productId, int width, int height,
            bool crop = true)
        {
            return $"//graph.digiseller.ru/img.ashx?id_d={productId}&w={width}&h={height}&crop={crop.ToString().ToLower()}";
        }

        public static string DigisellerImage(this IHtmlHelper html, int productId, int maxlength,
            bool crop = true)
        {
            return $"//graph.digiseller.ru/img.ashx?id_d={productId}&maxlength={maxlength}&crop={crop.ToString().ToLower()}";
        }

        public static string MaxStringLength(this IHtmlHelper html, string str, int maxLength)
        {
            if (maxLength <= 3)
            {
                throw new ArgumentException(nameof(maxLength));
            }

            if (string.IsNullOrEmpty(str) || str.Length <= maxLength)
                return str;

            return str.Substring(0, maxLength - 3) + "...";
        }

        public static string MaxStringLengthWithSnippetReplace(this IHtmlHelper html, string str, int maxLength)
        {
            if (maxLength <= 3)
            {
                throw new ArgumentException(nameof(maxLength));
            }

            if (string.IsNullOrEmpty(str))
                return string.Empty;

            str = str.Replace("[[!b!]]", "<b>");
            str = str.Replace("[[!/b!]]", "</b>");

            if (str.Length <= maxLength)
                return str;

            return maxLength == int.MaxValue ? str : str.Substring(0, maxLength - 3) + "...";
        }

        public static string Price(this IHtmlHelper html, Currency currency, decimal price)
        {
            switch (currency)
            {
                case Currency.USD:
                    return $"${price}";
                case Currency.RUR:
                    return $"{price}₽";
                case Currency.EUR:
                    return $"€{price}";
                case Currency.UAH:
                    return $"{price}₴";
                case Currency.mBTC:
                    return $"{price} mBTC";
                default:
                    throw new ArgumentOutOfRangeException(nameof(currency), currency, null);
            }
        }
    }
}
