using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Web.Search.Helpers
{
    public static class HtmlHelpers
    {
        private static string VersionId { get; } = Guid.NewGuid().ToString("D");

        public static string RootUrl(this IHtmlHelper htmlHelper)
        {
            var request = htmlHelper.ViewContext.HttpContext.Request;

            var host = request.Host.ToUriComponent();
            var pathBase = request.PathBase.ToUriComponent();

            return $"{request.Scheme}://{host}{pathBase}";
        }

        public static IHtmlContent Style(this IHtmlHelper html, string filePath)
        {
            return new HtmlString($"<link href=\"{html.RootUrl()}/{filePath}?version={VersionId}\" rel=\"stylesheet\">");
        }

        public static IHtmlContent Script(this IHtmlHelper html, string filePath)
        {
            return new HtmlString($"<script src=\"{html.RootUrl()}/{filePath}?version={VersionId}\"></script>");
        }
    }
}
