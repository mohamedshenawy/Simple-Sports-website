#pragma checksum "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b2e929e8846001ff9d495fef017034a1b026ecee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "F:\gemini\work shop\Sports Website\Sports Website\Views\_ViewImports.cshtml"
using Sports_Website;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\gemini\work shop\Sports Website\Sports Website\Views\_ViewImports.cshtml"
using Sports_Website.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
using Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2e929e8846001ff9d495fef017034a1b026ecee", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aae7aeba04342a65c7479c76e8a7ed29599f8aaa", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Tournaments>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("profile-img"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<style>\r\n\r\n    .profile-img {\r\n        width: 100px;\r\n    }\r\n</style>\r\n\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome to Sports Website</h1>\r\n</div>\r\n\r\n<h1>Tournaments</h1>\r\n\r\n\r\n");
#nullable restore
#line 22 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
Write(Html.ActionLink("Add New Tournament", "Create", "Home", null, new { @class = "btn btn-primary m-3" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<table class=""table"">
    <thead>
        <tr>
            <th scope=""col"">NO</th>
            <th scope=""col"">Team Logo</th>
            <th scope=""col"">Tournament Name</th>
            <th scope=""col"">About tournament</th>
            <th scope=""col"">Vedio about tournament</th>
            <th scope=""col"">Operations</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 36 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
          int i = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
         foreach (var tournament in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 42 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 44 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
                   i++;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b2e929e8846001ff9d495fef017034a1b026ecee6090", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1033, "~/Files/images/", 1033, 15, true);
#nullable restore
#line 47 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 1048, tournament.LogoUrl, 1048, 19, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>");
#nullable restore
#line 50 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
               Write(tournament.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                <td>");
#nullable restore
#line 52 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
               Write(tournament.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                <td>\r\n                    <div class=\"profile-img\">\r\n                        ");
#nullable restore
#line 56 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
                   Write(tournament.vedioUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
               Write(Html.ActionLink("Edit", "Edit", "Home", routeValues: new { @tournamentID = tournament.ID }, new { @class = "btn btn-primary me-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 62 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
               Write(Html.ActionLink("Delete", "Delete", "Home", routeValues: new { @tournamentID = tournament.ID }, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 65 "F:\gemini\work shop\Sports Website\Sports Website\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </tbody>\r\n</table>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Tournaments>> Html { get; private set; }
    }
}
#pragma warning restore 1591
