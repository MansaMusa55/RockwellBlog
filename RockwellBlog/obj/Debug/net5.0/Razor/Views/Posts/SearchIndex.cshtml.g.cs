#pragma checksum "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a8da464bcdf1807c4f8b1a850e8f23689fe03f0c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Posts_SearchIndex), @"mvc.1.0.view", @"/Views/Posts/SearchIndex.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\_ViewImports.cshtml"
using RockwellBlog;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\_ViewImports.cshtml"
using RockwellBlog.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
using RockwellBlog.Services;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8da464bcdf1807c4f8b1a850e8f23689fe03f0c", @"/Views/Posts/SearchIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3a8a8cb10ed0fed99a6c8d47ec53481df8e95699", @"/Views/_ViewImports.cshtml")]
    public class Views_Posts_SearchIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<Post>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-dark btn-block btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
  
    ViewData["Title"] = "Search Results Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Main Content-->\r\n<div class=\"row\">\r\n    <div class=\"col-lg-8 col-md-10 mx-auto\">\r\n");
#nullable restore
#line 16 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
         foreach (var post in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""post-preview"">
                <div class=""row"">
                    <div class=""col"">
                        <div class=""row"">
                            <div class=""col"">
                                <img class=""img-fluid""");
            BeginWriteAttribute("src", " src=\"", 629, "\"", 694, 1);
#nullable restore
#line 23 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
WriteAttributeValue("", 635, _fileService.DecodeImage(post.ImageData, post.ContentType), 635, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            </div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a8da464bcdf1807c4f8b1a850e8f23689fe03f0c6149", async() => {
                WriteLiteral("Read Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-slug", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
                                                                                                  WriteLiteral(post.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slug", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"col\">\r\n                        <a href=\"post.html\">\r\n                            <h2 class=\"post-title\">");
#nullable restore
#line 34 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
                                              Write(post.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                            <h3 class=\"post-subtitle\">");
#nullable restore
#line 35 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
                                                 Write(post.Abstract);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        </a>\r\n                        <p class=\"post-meta\">\r\n                            Posted by Samuel Musa on ");
#nullable restore
#line 38 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
                                                Write(post.Created.ToString("MMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <hr />\r\n");
#nullable restore
#line 44 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <!-- Pager-->\r\n        <div class=\"clearfix\"><a class=\"btn btn-primary float-right\" href=\"#!\">Older Posts →</a></div>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col h3\">\r\n        Page ");
#nullable restore
#line 53 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
         Write(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" of ");
#nullable restore
#line 53 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
                                                                        Write(Model.PageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col\">\r\n        ");
#nullable restore
#line 59 "C:\Users\Nancy Ibeling\source\repos\RockwellBlog\RockwellBlog\Views\Posts\SearchIndex.cshtml"
   Write(Html.PagedListPager(Model, page => Url.Action("SearchIndex", new { page = page, searchString = ViewData["SearchString"]}),
            new PagedListRenderOptions
            {
                LiElementClasses = new string[] { "page-item" },
                PageClasses = new string[] { "page-link" }

            }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IBlogFileService _fileService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<Post>> Html { get; private set; }
    }
}
#pragma warning restore 1591
