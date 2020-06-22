namespace TCC.Web
{

    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Web;
    using TCC.Domain.Entities;

    public class SessionConfig
    {
        public static SubMenu SubMenu
        {
            get { return Get<SubMenu>("SubMenu"); }
            set { Set("SubMenu", value); }
        }

        public static IEnumerable<Claim> Claims
        {
            get { return Get<IEnumerable<Claim>>("Claims"); }
            set { Set("Claims", value); }
        }

        private static T Get<T>(string key)
        {
            object o = HttpContext.Current.Session[key];
            if (o is T)
            {
                return (T)o;
            }

            return default(T);
        }

        private static void Set<T>(string key, T item)
        {
            HttpContext.Current.Session[key] = item;
        }
    }
}