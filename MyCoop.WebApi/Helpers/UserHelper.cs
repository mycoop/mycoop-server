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
            if (HttpContext.Current.Items[GlobalKeys.UserId] != null)
            {
                return (int)HttpContext.Current.Items[GlobalKeys.UserId];
            }
            var cookie = HttpContext.Current.Request.Cookies[IdKey];
            if (cookie != null)
            {
                try
                {
                    var sId = SecurityHelper.Decrypt(cookie.Value);
                    int id = Convert.ToInt32(sId);
                    HttpContext.Current.Items[GlobalKeys.UserId] = id;
                    return id;
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