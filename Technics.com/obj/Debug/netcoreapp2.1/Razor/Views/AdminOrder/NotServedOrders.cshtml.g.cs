#pragma checksum "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07a3de4ad52e1dda272a1225ec390eac921ee145"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminOrder_NotServedOrders), @"mvc.1.0.view", @"/Views/AdminOrder/NotServedOrders.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AdminOrder/NotServedOrders.cshtml", typeof(AspNetCore.Views_AdminOrder_NotServedOrders))]
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
#line 1 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
using Technics.com.Models;

#line default
#line hidden
#line 2 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
using Technics.com.Enums;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"07a3de4ad52e1dda272a1225ec390eac921ee145", @"/Views/AdminOrder/NotServedOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fe53cd937a30208974b5ebcf9ce1d44e4a1855b", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminOrder_NotServedOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Order>>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(75, 92, true);
            WriteLiteral("\r\n<script type=\"text/javascript\" src=\"https://code.jquery.com/jquery-3.5.0.js\"></script>\r\n\r\n");
            EndContext();
            BeginContext(167, 5079, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "585a07388d0f43fb90559a9657a185b6", async() => {
                BeginContext(173, 165, true);
                WriteLiteral("\r\n    <div class=\"container\" style=\"margin-top:80px\">\r\n        <h1 class=\"h3 mb-3 font-weight-normal\" style=\"margin-left:30%\">Список несортированных заказов</h1>\r\n\r\n");
                EndContext();
#line 11 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
         foreach (var el in Model)
        {

#line default
#line hidden
                BeginContext(385, 113, true);
                WriteLiteral("            <div class=\"alert body alert-warning mt-3\">\r\n                <b style=\"margin-left:45%\">Номер заказа:");
                EndContext();
                BeginContext(499, 5, false);
#line 14 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                                   Write(el.Id);

#line default
#line hidden
                EndContext();
                BeginContext(504, 82, true);
                WriteLiteral("</b>\r\n                <a class=\"nav-link\" style=\"margin-left:-2%;margin-top:-35px\"");
                EndContext();
                BeginWriteAttribute("href", " href=\'", 586, "\'", 856, 1);
#line 15 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
WriteAttributeValue("", 593, Url.Action("DeleteOrderById",
                                                                                                "AdminOrder",
                                                                                                new { orderId = el.Id }), 593, 263, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(857, 182, true);
                WriteLiteral(">\r\n                    <img src=\"https://img.icons8.com/windows/32/000000/delete-sign.png\" />\r\n                </a>\r\n                <div style=\"margin-left:82%\">Подтверждено</div>\r\n");
                EndContext();
#line 21 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                  
                    if (el.ConfirmOrder == true)
                    {

#line default
#line hidden
                BeginContext(1132, 131, true);
                WriteLiteral("                        <a class=\"nav-link firstRenderCheckedConfirm\" style=\"margin-left:93%;margin-top:-35px;\" data-custom-value=\"");
                EndContext();
                BeginContext(1264, 5, false);
#line 24 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                                                                                                              Write(el.Id);

#line default
#line hidden
                EndContext();
                BeginContext(1269, 132, true);
                WriteLiteral("\">\r\n                            <img src=\"https://img.icons8.com/windows/32/000000/checked-2.png\" />\r\n                        </a>\r\n");
                EndContext();
#line 27 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                    }
                    else
                    {

#line default
#line hidden
                BeginContext(1473, 133, true);
                WriteLiteral("                        <a class=\"nav-link firstRenderUncheckedConfirm\" style=\"margin-left:93%;margin-top:-35px;\" data-custom-value=\"");
                EndContext();
                BeginContext(1607, 5, false);
#line 30 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                                                                                                                Write(el.Id);

#line default
#line hidden
                EndContext();
                BeginContext(1612, 141, true);
                WriteLiteral("\">\r\n                            <img src=\"https://img.icons8.com/windows/32/000000/unchecked-checkbox.png\" />\r\n                        </a>\r\n");
                EndContext();
#line 33 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                    }



#line default
#line hidden
                BeginContext(1780, 108, true);
                WriteLiteral("                    <a class=\"nav-link checkedConfirm\" style=\"margin-left:93%;margin-top:-35px;display:none\"");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 1888, "\"", 1914, 2);
                WriteAttributeValue("", 1893, "checkedConfirm+", 1893, 15, true);
#line 36 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
WriteAttributeValue("", 1908, el.Id, 1908, 6, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1915, 20, true);
                WriteLiteral(" data-custom-value=\"");
                EndContext();
                BeginContext(1936, 5, false);
#line 36 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                                                                                                                                      Write(el.Id);

#line default
#line hidden
                EndContext();
                BeginContext(1941, 124, true);
                WriteLiteral("\">\r\n                        <img src=\"https://img.icons8.com/windows/32/000000/checked-2.png\" />\r\n                    </a>\r\n");
                EndContext();
                BeginContext(2067, 110, true);
                WriteLiteral("                    <a class=\"nav-link uncheckedConfirm\" style=\"margin-left:93%;margin-top:-35px;display:none\"");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 2177, "\"", 2205, 2);
                WriteAttributeValue("", 2182, "uncheckedConfirm+", 2182, 17, true);
#line 40 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
WriteAttributeValue("", 2199, el.Id, 2199, 6, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2206, 20, true);
                WriteLiteral(" data-custom-value=\"");
                EndContext();
                BeginContext(2227, 5, false);
#line 40 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                                                                                                                                          Write(el.Id);

#line default
#line hidden
                EndContext();
                BeginContext(2232, 133, true);
                WriteLiteral("\">\r\n                        <img src=\"https://img.icons8.com/windows/32/000000/unchecked-checkbox.png\" />\r\n                    </a>\r\n");
                EndContext();
#line 43 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"


                    if (el.PaymentMethod == Technics.com.PaymentMethod.NowToABankCard)
                    {

#line default
#line hidden
                BeginContext(2480, 84, true);
                WriteLiteral("                        <div style=\"margin-left:82%;margin-top:5px\">Оплачено</div>\r\n");
                EndContext();
#line 48 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"

                        if (el.Paid == false)
                        {

#line default
#line hidden
                BeginContext(2640, 153, true);
                WriteLiteral("                            <a class=\"nav-link firstRenderUncheckedPaid\" style=\"margin-left:93%;margin-top:-35px;margin-bottom:-80px\" data-custom-value=\"");
                EndContext();
                BeginContext(2794, 5, false);
#line 51 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                                                                                                                                    Write(el.Id);

#line default
#line hidden
                EndContext();
                BeginContext(2799, 158, true);
                WriteLiteral("\">\r\n                                <img style=\"\" src=\"https://img.icons8.com/windows/32/000000/unchecked-checkbox.png\" />\r\n                            </a>\r\n");
                EndContext();
#line 54 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                        }
                        else
                        {

#line default
#line hidden
                BeginContext(3041, 151, true);
                WriteLiteral("                            <a class=\"nav-link firstRenderCheckedPaid\" style=\"margin-left:93%;margin-top:-35px;margin-bottom:-80px\" data-custom-value=\"");
                EndContext();
                BeginContext(3193, 5, false);
#line 57 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                                                                                                                                  Write(el.Id);

#line default
#line hidden
                EndContext();
                BeginContext(3198, 149, true);
                WriteLiteral("\">\r\n                                <img style=\"\" src=\"https://img.icons8.com/windows/32/000000/checked-2.png\" />\r\n                            </a>\r\n");
                EndContext();
#line 60 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                        }


#line default
#line hidden
                BeginContext(3376, 129, true);
                WriteLiteral("                        <a class=\"nav-link checkedPaid\" style=\"margin-left:93%;margin-top:-35px;margin-bottom:-80px;display:none\"");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 3505, "\"", 3528, 2);
                WriteAttributeValue("", 3510, "checkedPaid+", 3510, 12, true);
#line 62 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
WriteAttributeValue("", 3522, el.Id, 3522, 6, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3529, 20, true);
                WriteLiteral(" data-custom-value=\"");
                EndContext();
                BeginContext(3550, 5, false);
#line 62 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                                                                                                                                                        Write(el.Id);

#line default
#line hidden
                EndContext();
                BeginContext(3555, 132, true);
                WriteLiteral("\">\r\n                            <img src=\"https://img.icons8.com/windows/32/000000/checked-2.png\" />\r\n                        </a>\r\n");
                EndContext();
                BeginContext(3689, 131, true);
                WriteLiteral("                        <a class=\"nav-link uncheckedPaid\" style=\"margin-left:93%;margin-top:-35px;margin-bottom:-80px;display:none\"");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 3820, "\"", 3845, 2);
                WriteAttributeValue("", 3825, "uncheckedPaid+", 3825, 14, true);
#line 66 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
WriteAttributeValue("", 3839, el.Id, 3839, 6, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3846, 20, true);
                WriteLiteral(" data-custom-value=\"");
                EndContext();
                BeginContext(3867, 5, false);
#line 66 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                                                                                                                                                            Write(el.Id);

#line default
#line hidden
                EndContext();
                BeginContext(3872, 141, true);
                WriteLiteral("\">\r\n                            <img src=\"https://img.icons8.com/windows/32/000000/unchecked-checkbox.png\" />\r\n                        </a>\r\n");
                EndContext();
#line 69 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                    }
                    else
                    {

#line default
#line hidden
                BeginContext(4085, 117, true);
                WriteLiteral("                        <div style=\"margin-left:82%;margin-top:5px;margin-bottom:-75px;\">Оплата при получении</div>\r\n");
                EndContext();
#line 73 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                    }
                

#line default
#line hidden
                BeginContext(4244, 28, true);
                WriteLiteral("\r\n                <br />\r\n\r\n");
                EndContext();
#line 78 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                  
                    foreach (var item in el.ProductsOrders.Select(x => x.Product))
                    {
                        var prodOrd = item.ProductsOrders.FirstOrDefault(x => x.OrderId == el.Id);
                        var count = prodOrd.Count;

                        var price = item.Price * count;


#line default
#line hidden
                BeginContext(4612, 37, true);
                WriteLiteral("                        <b>Товар:</b>");
                EndContext();
                BeginContext(4650, 9, false);
#line 86 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                Write(item.Name);

#line default
#line hidden
                EndContext();
                BeginContext(4659, 44, true);
                WriteLiteral("<br />\r\n                        <b>Цена:</b>");
                EndContext();
                BeginContext(4704, 19, false);
#line 87 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                               Write(price.ToString("c"));

#line default
#line hidden
                EndContext();
#line 87 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                                        ;

#line default
#line hidden
                BeginContext(4724, 50, true);
                WriteLiteral("<br />\r\n                        <b>Количество:</b>");
                EndContext();
                BeginContext(4775, 5, false);
#line 88 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                     Write(count);

#line default
#line hidden
                EndContext();
                BeginContext(4780, 40, true);
                WriteLiteral("<br />\r\n                        <br />\r\n");
                EndContext();
#line 90 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"

                    }
                

#line default
#line hidden
                BeginContext(4864, 32, true);
                WriteLiteral("\r\n                <b>Индекс:</b>");
                EndContext();
                BeginContext(4897, 11, false);
#line 94 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                         Write(el.PostCode);

#line default
#line hidden
                EndContext();
                BeginContext(4908, 46, true);
                WriteLiteral("<br />\r\n                <b>Город доставки:</b>");
                EndContext();
                BeginContext(4955, 9, false);
#line 95 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                 Write(el.ToTown);

#line default
#line hidden
                EndContext();
                BeginContext(4964, 43, true);
                WriteLiteral("<br />\r\n                <b>Дата заказа:</b>");
                EndContext();
                BeginContext(5008, 12, false);
#line 96 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                              Write(el.OrderTime);

#line default
#line hidden
                EndContext();
                BeginContext(5020, 49, true);
                WriteLiteral("<br />\r\n                <b>Общая цена заказа:</b>");
                EndContext();
                BeginContext(5070, 8, false);
#line 97 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                                    Write(el.Price);

#line default
#line hidden
                EndContext();
                BeginContext(5078, 42, true);
                WriteLiteral("<br />\r\n                <b>Покупатель:</b>");
                EndContext();
                BeginContext(5121, 12, false);
#line 98 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                             Write(el.User.Name);

#line default
#line hidden
                EndContext();
                BeginContext(5133, 39, true);
                WriteLiteral("<br />\r\n                <b>Телефон:</b>");
                EndContext();
                BeginContext(5173, 13, false);
#line 99 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                          Write(el.User.Phone);

#line default
#line hidden
                EndContext();
                BeginContext(5186, 28, true);
                WriteLiteral("<br />\r\n            </div>\r\n");
                EndContext();
#line 101 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
        }

#line default
#line hidden
                BeginContext(5225, 14, true);
                WriteLiteral("\r\n    </div>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5246, 326, true);
            WriteLiteral(@"

<script>
    $(document).ready(function () {
        $("".firstRenderCheckedConfirm"").click(function () {
            var id = $(this).data(""custom-value"");
            var button = $(this);
            $.ajax({
                type: 'get',
                url: '/AdminOrder/UpdateOrder',
                data: 'by=");
            EndContext();
            BeginContext(5573, 19, false);
#line 114 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                     Write(ChangeOrder.CONFIRM);

#line default
#line hidden
            EndContext();
            BeginContext(5592, 520, true);
            WriteLiteral(@"&orderId=' + id,
                success: function () {
                    button.hide();

                    document.getElementById(""uncheckedConfirm+"" + id).style.display = ""block"";
                }
            });
        });

        $("".firstRenderUncheckedConfirm"").click(function () {
            var id = $(this).data(""custom-value"");
            var button = $(this);
            $.ajax({
                type: 'get',
                url: '/AdminOrder/UpdateOrder',
                data: 'by=");
            EndContext();
            BeginContext(6113, 19, false);
#line 129 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                     Write(ChangeOrder.CONFIRM);

#line default
#line hidden
            EndContext();
            BeginContext(6132, 468, true);
            WriteLiteral(@"&orderId=' + id,
                success: function () {
                    button.hide();
                    document.getElementById(""checkedConfirm+"" + id).style.display = ""block"";
                }
            });
        });

        $("".checkedConfirm"").click(function () {
            var id = $(this).data(""custom-value"");
            $.ajax({
                type: 'get',
                url: '/AdminOrder/UpdateOrder',
                data: 'by=");
            EndContext();
            BeginContext(6601, 19, false);
#line 142 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                     Write(ChangeOrder.CONFIRM);

#line default
#line hidden
            EndContext();
            BeginContext(6620, 529, true);
            WriteLiteral(@"&orderId=' + id,
                success: function () {
                    document.getElementById(""checkedConfirm+"" + id).style.display = ""none"";
                    document.getElementById(""uncheckedConfirm+"" + id).style.display = ""block"";
                }
            });
        });

        $("".uncheckedConfirm"").click(function () {
            var id = $(this).data(""custom-value"");
            $.ajax({
                type: 'get',
                url: '/AdminOrder/UpdateOrder',
                data: 'by=");
            EndContext();
            BeginContext(7150, 19, false);
#line 155 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                     Write(ChangeOrder.CONFIRM);

#line default
#line hidden
            EndContext();
            BeginContext(7169, 570, true);
            WriteLiteral(@"&orderId=' + id,
                success: function () {
                    document.getElementById(""uncheckedConfirm+"" + id).style.display = ""none"";
                    document.getElementById(""checkedConfirm+"" + id).style.display = ""block"";
                }
            });
        });

        $("".firstRenderCheckedPaid"").click(function () {
            var id = $(this).data(""custom-value"");
            var button = $(this);
            $.ajax({
                type: 'get',
                url: '/AdminOrder/UpdateOrder',
                data: 'by=");
            EndContext();
            BeginContext(7740, 16, false);
#line 169 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                     Write(ChangeOrder.PAID);

#line default
#line hidden
            EndContext();
            BeginContext(7756, 512, true);
            WriteLiteral(@"&orderId=' + id,
                success: function () {
                    button.hide();
                    document.getElementById(""uncheckedPaid+"" + id).style.display = ""block"";
                }
            });
        });

        $("".firstRenderUncheckedPaid"").click(function () {
            var id = $(this).data(""custom-value"");
            var button = $(this);
            $.ajax({
                type: 'get',
                url: '/AdminOrder/UpdateOrder',
                data: 'by=");
            EndContext();
            BeginContext(8269, 16, false);
#line 183 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                     Write(ChangeOrder.PAID);

#line default
#line hidden
            EndContext();
            BeginContext(8285, 462, true);
            WriteLiteral(@"&orderId=' + id,
                success: function () {
                    button.hide();
                    document.getElementById(""checkedPaid+"" + id).style.display = ""block"";
                }
            });
        });

        $("".checkedPaid"").click(function () {
            var id = $(this).data(""custom-value"");
            $.ajax({
                type: 'get',
                url: '/AdminOrder/UpdateOrder',
                data: 'by=");
            EndContext();
            BeginContext(8748, 16, false);
#line 196 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                     Write(ChangeOrder.PAID);

#line default
#line hidden
            EndContext();
            BeginContext(8764, 520, true);
            WriteLiteral(@"&orderId=' + id,
                success: function () {
                    document.getElementById(""checkedPaid+"" + id).style.display = ""none"";
                    document.getElementById(""uncheckedPaid+"" + id).style.display = ""block"";
                }
            });
        });

        $("".uncheckedPaid"").click(function () {
            var id = $(this).data(""custom-value"");
            $.ajax({
                type: 'get',
                url: '/AdminOrder/UpdateOrder',
                data: 'by=");
            EndContext();
            BeginContext(9285, 16, false);
#line 209 "D:\Programs\Technics\NewTechincs\Technics.com\Views\AdminOrder\NotServedOrders.cshtml"
                     Write(ChangeOrder.PAID);

#line default
#line hidden
            EndContext();
            BeginContext(9301, 310, true);
            WriteLiteral(@"&orderId=' + id,
                success: function () {
                    document.getElementById(""uncheckedPaid+"" + id).style.display = ""none"";
                    document.getElementById(""checkedPaid+"" + id).style.display = ""block"";
                }
            });
        });
    });
</script>
");
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
