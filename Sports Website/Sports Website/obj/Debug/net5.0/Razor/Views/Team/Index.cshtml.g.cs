#pragma checksum "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95d6b2e69b9ebc9f0c8ef8e8af2d2c2a2943254c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Team_Index), @"mvc.1.0.view", @"/Views/Team/Index.cshtml")]
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
#line 1 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\_ViewImports.cshtml"
using Sports_Website;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\_ViewImports.cshtml"
using Sports_Website.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
using Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95d6b2e69b9ebc9f0c8ef8e8af2d2c2a2943254c", @"/Views/Team/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aae7aeba04342a65c7479c76e8a7ed29599f8aaa", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Team_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Teams>>
    #nullable disable
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
            WriteLiteral("\r\n");
#nullable restore
#line 2 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <style>\r\n\r\n        .profile-img {\r\n            width: 100px;\r\n        }\r\n    </style>\r\n\r\n<h1>Teams</h1>\r\n\r\n\r\n");
#nullable restore
#line 17 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
Write(Html.ActionLink("Add New Team" , "Create" , "Team" , null  , new{ @class="btn btn-primary m-3"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            
<table class=""table"">
    <thead>
        <tr>
            <th scope=""col"">NO</th>
            <th scope=""col"">Team Logo</th>
            <th scope=""col"">Team Name</th>
            <th scope=""col"">About Team</th>
            <th scope=""col"">Website Url</th>
            <th scope=""col"">Foundation Date</th>
            <th scope=""col"">Operations</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 32 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
          int i = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
         foreach (var team in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 38 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n");
#nullable restore
#line 40 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
               i++;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <td>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "95d6b2e69b9ebc9f0c8ef8e8af2d2c2a2943254c6087", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 940, "~/Files/images/", 940, 15, true);
#nullable restore
#line 43 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
AddHtmlAttributeValue("", 955, team.LogoUrl, 955, 13, false);

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
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>");
#nullable restore
#line 46 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
           Write(team.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n            <td>");
#nullable restore
#line 48 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
           Write(team.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n            <td>\r\n                <a target=\"_blank\"");
            BeginWriteAttribute("href", " href=\"", 1135, "\"", 1158, 1);
#nullable restore
#line 51 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
WriteAttributeValue("", 1142, team.WebsiteUrl, 1142, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">click here</a>\r\n            </td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 55 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
           Write(team.FoundationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 59 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", "Team", routeValues: new { @teamID = team.ID }, new { @class = "btn btn-primary me-2" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 60 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", "Team", routeValues: new { @teamID = team.ID }, new { @class = "btn btn-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 63 "F:\tech tech\SimpleSports\Sports Website\Sports Website\Views\Team\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </tbody>\r\n</table>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Teams>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
