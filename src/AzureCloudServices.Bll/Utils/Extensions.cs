using System.Text;

namespace AzureCloudServices.Bll.Utils
{
    public static class Extensions
    {
        public static string ToJson(this object entry)
            => Encoding.UTF8.GetString(Utf8Json.JsonSerializer.Serialize(entry));
    }
}