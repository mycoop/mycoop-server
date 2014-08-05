using System;
using System.Globalization;
using System.Web;
using MyCoop.Helpers;

namespace MyCoop.WebApi.Helpers
{
    public static class UserHelper
    {
        private const string IdKey = "id";

        private const int DayCount = 365;

        public static void SaveId(int id)
        {
            var sId = SecurityHelper.Encrypt(id.ToString(CultureInfo.InvariantCulture));

            var cookie = new HttpCookie(IdKey)
            {
                HttpOnly = true,
                Value = sId,
                Expires = DateTime.Now.AddDays(DayCount)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);

        }

        public static int GetId()
        {
            var cookie = HttpContext.Current.Request.Cookies[IdKey];
            if (cookie != null)
            {
                try
                {
                    var sId = SecurityHelper.Decrypt(cookie.Value);
                    return Convert.ToInt32(sId);
                }
                catch
                {
                    RemoveId();
                }
                
            }
            return -1;
        }

        public static void RemoveId()
        {
            var cookie = HttpContext.Current.Request.Cookies[IdKey];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}