using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElKap.Pages.Extensions
{
	public static class EditorHtml
	{
		public static IHtmlContent Editor<TModel, TResult>(
			this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)
        {
			var s = htmlStrings(html, expression);
			return new HtmlContentBuilder(s);
        }

		private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
			var l = new List<object>();
			l.Add(new HtmlString("<div class=\"row\">"));
				l.Add(new HtmlString("<dd class=\"col-sm-2\">"));
					l.Add(h.LabelFor(e, null, new { @class = "control-label" }));
				l.Add(new HtmlString("</dd>"));
				l.Add(new HtmlString("<dd class=\"col-sm-10\">"));
					l.Add(h.EditorFor(e, null, new { htmlAtrributes = new { @class = "form-control" }}));
					l.Add(h.ValidationMessageFor(e, null, new { @class = "text-danger" }));
				l.Add(new HtmlString("</dd>"));
			l.Add(new HtmlString("</div>"));
			return l;
		}
	}
}

