using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace Web.HtmlHelpers
{
    public static class MVCHelpers
    {
        /// <summary>
        /// mvc will encode automatically as we are sending straight string
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string JsonEncode(this HtmlHelper htmlHelper, object obj)
        {
            var encodingSettings = new JsonSerializerSettings()
            {
                //DateFormatHandling = DateFormatHandling.IsoDateFormat,
                //DateParseHandling = DateParseHandling.DateTimeOffset,
                //DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };
            return JsonConvert.SerializeObject(obj, Formatting.None, encodingSettings);
        }
    }
}
