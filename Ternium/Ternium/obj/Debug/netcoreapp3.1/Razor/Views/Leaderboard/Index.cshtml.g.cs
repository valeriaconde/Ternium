#pragma checksum "/Users/tere/ITC/3Semestre/Colada/Increibles/Ternium/Ternium/Ternium/Views/Leaderboard/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "015aa5557cc3ed41f209959bcbf16e806335d831"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Leaderboard_Index), @"mvc.1.0.view", @"/Views/Leaderboard/Index.cshtml")]
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
#line 1 "/Users/tere/ITC/3Semestre/Colada/Increibles/Ternium/Ternium/Ternium/Views/_ViewImports.cshtml"
using Ternium;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/tere/ITC/3Semestre/Colada/Increibles/Ternium/Ternium/Ternium/Views/_ViewImports.cshtml"
using Ternium.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"015aa5557cc3ed41f209959bcbf16e806335d831", @"/Views/Leaderboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9b335f2da32cc8eac4ef933a6f80df968c65a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Leaderboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/tere/ITC/3Semestre/Colada/Increibles/Ternium/Ternium/Ternium/Views/Leaderboard/Index.cshtml"
  
    ViewData["Title"] = "";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 4 "/Users/tere/ITC/3Semestre/Colada/Increibles/Ternium/Ternium/Ternium/Views/Leaderboard/Index.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

<h1> Leaderboard </h1>

<br />

<table class=""table table-hover table-dark"">
    <thead class=""tableLetters"">
        <tr>
            <th scope=""col"">Lugar</th>
            <th scope=""col"">Inspector</th>
            <th scope=""col"">Puntos</th>
        </tr>
    </thead>
    <tbody class=""tableLetters"">
        <tr>
            <td scope=""row"">1</td>
            <td> Roberto </td>
            <td> 19536 </td>

        </tr>
        <tr>
            <td scope=""row"">2</td>
            <td> Daniela </td>
            <td> 14095 </td>
        </tr>
        <tr>
            <td scope=""row"">3</td>
            <td> Jesus </td>
            <td> 13900 </td>
        </tr>
        <tr>
            <td scope=""row"">4</td>
            <td> Miguel </td>
            <td> 10990 </td>
        </tr>
        <tr>
            <td scope=""row"">5</td>
            <td> Adrian </td>
            <td> 10103 </td>
        </tr>
    </tbody>
</table>

<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
