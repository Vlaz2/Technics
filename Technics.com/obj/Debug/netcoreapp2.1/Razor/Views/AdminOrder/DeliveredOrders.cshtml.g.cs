#pragma checksum "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6d96ec7a832e5b2882a3f756454af11dad85daea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminOrder_DeliveredOrders), @"mvc.1.0.view", @"/Views/AdminOrder/DeliveredOrders.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AdminOrder/DeliveredOrders.cshtml", typeof(AspNetCore.Views_AdminOrder_DeliveredOrders))]
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
#line 1 "D:\Programs\Technics\NewTechincs\Technics.com\Views\_ViewImports.cshtml"
using Technics.ViewModels;

#line default
#line hidden
#line 1 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml"
using Technics.com.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d96ec7a832e5b2882a3f756454af11dad85daea", @"/Views/AdminOrder/DeliveredOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fe53cd937a30208974b5ebcf9ce1d44e4a1855b", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminOrder_DeliveredOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 154, true);
            WriteLiteral("\r\n<div class=\"container\" style=\"margin-top:80px\">\r\n    <h1 class=\"h3 mb-3 font-weight-normal\" style=\"margin-left:35%\">Список доставленных заказов</h1>\r\n\r\n");
            EndContext();
#line 7 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml"
     foreach (var el in Model)
    {

#line default
#line hidden
            BeginContext(241, 105, true);
            WriteLiteral("        <div class=\"alert body alert-warning mt-3\">\r\n            <b style=\"margin-left:45%\">Номер заказа:");
            EndContext();
            BeginContext(347, 5, false);
#line 10 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml"
                                               Write(el.Id);

#line default
#line hidden
            EndContext();
            BeginContext(352, 28, true);
            WriteLiteral("</b>\r\n            <br />\r\n\r\n");
            EndContext();
#line 13 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml"
              
                foreach (var item in el.ProductsOrders.Select(x => x.Product))
                {
                    var prodOrd = item.ProductsOrders.FirstOrDefault(x => x.OrderId == el.Id);
                    var count = prodOrd.Count;

                    var price = item.Price * count;


#line default
#line hidden
            BeginContext(696, 33, true);
            WriteLiteral("                    <b>Товар:</b>");
            EndContext();
            BeginContext(730, 9, false);
#line 21 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml"
                            Write(item.Name);

#line default
#line hidden
            EndContext();
            BeginContext(739, 46, true);
            WriteLiteral("<br />\r\n                    <b>Количество:</b>");
            EndContext();
            BeginContext(786, 5, false);
#line 22 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml"
                                 Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(791, 36, true);
            WriteLiteral("<br />\r\n                    <br />\r\n");
            EndContext();
#line 24 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml"

                }
            

#line default
#line hidden
            BeginContext(863, 33, true);
            WriteLiteral("\r\n            <b>Дата заказа:</b>");
            EndContext();
            BeginContext(897, 12, false);
#line 28 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml"
                          Write(el.OrderTime);

#line default
#line hidden
            EndContext();
            BeginContext(909, 45, true);
            WriteLiteral("<br />\r\n            <b>Общая цена заказа:</b>");
            EndContext();
            BeginContext(955, 8, false);
#line 29 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml"
                                Write(el.Price);

#line default
#line hidden
            EndContext();
            BeginContext(963, 38, true);
            WriteLiteral("<br />\r\n            <b>Покупатель:</b>");
            EndContext();
            BeginContext(1002, 12, false);
#line 30 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml"
                         Write(el.User.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1014, 35, true);
            WriteLiteral("<br />\r\n            <b>Телефон:</b>");
            EndContext();
            BeginContext(1050, 13, false);
#line 31 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml"
                      Write(el.User.Phone);

#line default
#line hidden
            EndContext();
            BeginContext(1063, 24, true);
            WriteLiteral("<br />\r\n        </div>\r\n");
            EndContext();
#line 33 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\DeliveredOrders.cshtml"
    }

#line default
#line hidden
            BeginContext(1094, 8, true);
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Order>> Html { get; private set; }
    }
}
#pragma warning restore 1591
