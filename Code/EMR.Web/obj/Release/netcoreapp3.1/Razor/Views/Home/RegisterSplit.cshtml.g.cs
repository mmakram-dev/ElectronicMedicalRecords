#pragma checksum "D:\LU\Grad proj\Code\EMR.Web\Views\Home\RegisterSplit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec0cf394ca99e4a7254f3790f4707a7d0739e76c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_RegisterSplit), @"mvc.1.0.view", @"/Views/Home/RegisterSplit.cshtml")]
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
#line 1 "D:\LU\Grad proj\Code\EMR.Web\Views\_ViewImports.cshtml"
using EMR;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\LU\Grad proj\Code\EMR.Web\Views\_ViewImports.cshtml"
using EMR.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec0cf394ca99e4a7254f3790f4707a7d0739e76c", @"/Views/Home/RegisterSplit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eaa6857bc2a69178027837461ebf9bd3547267c2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_RegisterSplit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EMR.Models.RegisterRequestModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\LU\Grad proj\Code\EMR.Web\Views\Home\RegisterSplit.cshtml"
  
    ViewData["Title"] = "Register";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row justify-content-center"">
    <div class=""col-md-6"">
        <div class=""card"">
            <header class=""card-header"">
                <h4 class=""card-title mt-2"">Register</h4>
            </header>
            <article class=""card-body"">
                <a");
            BeginWriteAttribute("href", " href=\"", 402, "\"", 447, 1);
#nullable restore
#line 14 "D:\LU\Grad proj\Code\EMR.Web\Views\Home\RegisterSplit.cshtml"
WriteAttributeValue("", 409, Url.Action("RegisterPatient", "Home"), 409, 38, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><div id=\"pickup\" class=\"take_meals_opt\">I am a Patient</div></a>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 533, "\"", 577, 1);
#nullable restore
#line 15 "D:\LU\Grad proj\Code\EMR.Web\Views\Home\RegisterSplit.cshtml"
WriteAttributeValue("", 540, Url.Action("RegisterDoctor", "Home"), 540, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><div id=\"delivery\" class=\"take_meals_opt float-right\">I am a Doctor</div></a>\r\n\r\n            </article>\n        </div>\n    </div>\n</div>\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EMR.Models.RegisterRequestModel> Html { get; private set; }
    }
}
#pragma warning restore 1591