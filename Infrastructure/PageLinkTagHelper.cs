using Assignment6.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment6.Infrastructure
{
    [HtmlTargetElement("td", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory UrlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory hp)
        {
            UrlHelperFactory = hp;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = UrlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder builder = new TagBuilder("td");
            TagBuilder btnGroup = new TagBuilder("div");
            btnGroup.AddCssClass("btn-group");
            
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { page = i });
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString());

                btnGroup.InnerHtml.AppendHtml(tag);
            }
            builder.InnerHtml.AppendHtml(btnGroup);

            output.Content.AppendHtml(builder.InnerHtml);
        }
    }
}
