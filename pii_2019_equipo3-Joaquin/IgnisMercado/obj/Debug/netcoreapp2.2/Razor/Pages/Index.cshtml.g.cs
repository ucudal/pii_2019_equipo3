#pragma checksum "C:\Users\jalca\Desktop\Proyect2019\RazorPagesIgnis\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7fedf184008f6d1194c6a8edd3d416443a7ecef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorPagesIgnis.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(RazorPagesIgnis.Pages.Pages_Index), null)]
namespace RazorPagesIgnis.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\jalca\Desktop\Proyect2019\RazorPagesIgnis\Pages\_ViewImports.cshtml"
using RazorPagesIgnis;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7fedf184008f6d1194c6a8edd3d416443a7ecef", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8933c980988a216a4cc93f7387c9a49fb8ea0b34", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\jalca\Desktop\Proyect2019\RazorPagesIgnis\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";

#line default
#line hidden
            BeginContext(66, 1080, true);
            WriteLiteral(@"
<div class=""jumbotron"">
    <h1>Ignis Mercado</h1>
</div>
<div class=""row"">
    <div class=""col-md-4"">
        <h2>¿Qué es Ignis Mercado?</h2>
        <p>
            Es un programa universitario para incentivar el desarrollo del mercado audiovisual y
            la inserción al sector de estudiantes, egresados y docentes. 
        </p>
    </div>
    <div class=""col-md-4"">
        <h2>¿Qué es la Base de Técnicos Audiovisuales? </h2>
        <p>Es una base de datos con los contactos de interesados en sumarse a proyectos audiovisuales coordinados o apoyados por el Centro Ignis. Pueden ser oportunidades generadas tanto por el propio Centro como por otras unidades académicas de la Universidad Católica del Uruguay (UCU), particulares y organizaciones externas. </p>
    </div>
    <div class=""col-md-4"">
        <h2>¿Quienes pueden integrar la Base de Técnicos Audiovisuales?</h2>
        <p>Estudiantes y egresados de las licenciaturas en Comunicación, Ingeniería Audiovisual y Artes Visuales que deseen generar expe");
            WriteLiteral("riencias laborales profesionales. </p>\n    </div>\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
