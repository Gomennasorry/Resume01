
using System.Text.Json;

namespace Resume01.Extensions
{
    public static class SESSIONID
    {
        public static string USER_JSON = "USER_JSON";
        public static string USER_INFO = "USER_INFO";
        public static string USER_LANG = "USER_LANG";
        public static string BEAR_TOKE = "BEAR_TOKE";
    }
    public static class SessionExtension
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
