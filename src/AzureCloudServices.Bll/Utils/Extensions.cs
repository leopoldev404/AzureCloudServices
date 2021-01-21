using System.Text;

namespace AzureCloudServices.Bll.Utils
{
    public static class Extensions
    {
        public static string GetJson<T>(this T entry)
            => Encoding.UTF8.GetString(Utf8Json.JsonSerializer.Serialize(entry));
        public static T GetDeserializedObject<T>(this string entry)
            => Utf8Json.JsonSerializer.Deserialize<T>(entry);
    }
}