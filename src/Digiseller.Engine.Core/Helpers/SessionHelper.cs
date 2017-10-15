using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Digiseller.Client.Core.Enums;
using Microsoft.AspNetCore.Http;

namespace Digiseller.Engine.Core.Helpers
{
    public static class SessionHelper
    {

        public const string KeyCurrency = "CURRENCY";
        public const string KeyCart = "CART";
        public const string KeyAuthorizeAdmin = "AUTHADMIN";

        public static void SetCurrency(this ISession session, Currency currency)
        {
            session.SetInt32(KeyCurrency, (int)currency);
        }

        public static Currency GetCurrency(this ISession session)
        {
            return (Currency)session.GetInt32(KeyCurrency);
        }

        public static string GetCartId(this ISession session)
        {
            return session.GetString(KeyCart);
        }

        public static void SetCartId(this ISession session, string cartUid)
        {
            session.SetString(KeyCart, cartUid);
        }

        public static void Authorize(this ISession session)
        {
            session.SetString(KeyAuthorizeAdmin, "True");
        }

        public static void Deauthorize(this ISession session)
        {
            session.SetString(KeyAuthorizeAdmin, "False");
        }

        public static bool IsAuthorized(this ISession session)
        {
            var value = session.GetString(KeyAuthorizeAdmin);
            return value == "True";
        }
    }
}
