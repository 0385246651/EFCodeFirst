using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;

namespace EFCodeFirst.HtmlHelpers
{
	public static class InputHelper
	{
		public static MvcHtmlString InputHelp(this HtmlHelper htmlHelper, string CssClassName, string Field, string Label)
		{
			var outerDiv = new TagBuilder("div");
			outerDiv.AddCssClass(CssClassName);

			var label = new TagBuilder("label");
			label.MergeAttribute("for", Field);
            label.SetInnerText(Label);

            var input = new TagBuilder("input");
            input.MergeAttribute("type", "text");
            input.MergeAttribute("name", Field);
            input.MergeAttribute("id", Field);
            input.AddCssClass("form-control");
			input.MergeAttribute("placeholder", Label);

            // Add the label and input to the outer div
            // Create a StringBuilder to combine the HTML
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(label.ToString(TagRenderMode.Normal));
            stringBuilder.Append(input.ToString(TagRenderMode.SelfClosing));
            outerDiv.InnerHtml = stringBuilder.ToString();

            return MvcHtmlString.Create(outerDiv.ToString(TagRenderMode.Normal));
        }
    }
}