#pragma checksum "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "067906b12084f3a9da0b1cd453cebeefb71bfc66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AddsPanel), @"mvc.1.0.view", @"/Views/Shared/_AddsPanel.cshtml")]
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
#line 1 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\_ViewImports.cshtml"
using FINAL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\_ViewImports.cshtml"
using FINAL.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\_ViewImports.cshtml"
using FINAL.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"067906b12084f3a9da0b1cd453cebeefb71bfc66", @"/Views/Shared/_AddsPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ce70e539199f7c42679e3a9250e0583310adbda", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AddsPanel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AddsPanelViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("property"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Ətraflı"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "add", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
 foreach (Addvertisiment item in Model.AddList)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div");
            BeginWriteAttribute("class", " class=\"", 89, "\"", 195, 4);
            WriteAttributeValue("", 97, "col-md-", 97, 7, true);
#nullable restore
#line 5 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
WriteAttributeValue("", 104, Model.type==ViewType.small?"4":"3", 104, 37, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 141, "element-item", 142, 13, true);
#nullable restore
#line 5 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
WriteAttributeValue(" ", 154, @item.AddTypeID < 3 ? "rent" : "sale", 155, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"contain-item\">\r\n            <div class=\"item-image\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "067906b12084f3a9da0b1cd453cebeefb71bfc665777", async() => {
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "067906b12084f3a9da0b1cd453cebeefb71bfc665993", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 397, "~/img/property/", 397, 15, true);
#nullable restore
#line 8 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
AddHtmlAttributeValue("", 412, item.AddTypeID<3?"rent":"sale", 412, 33, false);

#line default
#line hidden
#nullable disable
                AddHtmlAttributeValue("", 445, "/", 445, 1, true);
#nullable restore
#line 8 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
AddHtmlAttributeValue("", 446, item.Property.MainPhoto, 446, 24, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 8 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                                                              WriteLiteral(item.AddvertisimentID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n            <div class=\"item-property\">\r\n                <div class=\"date\">\r\n                    <i class=\"far fa-calendar-alt\"></i><span class=\"added-date\">");
#nullable restore
#line 12 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                                                           Write(item.CreatedAt.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div>\r\n                <div class=\"property-name\">\r\n");
#nullable restore
#line 15 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                     if (@item.Property.DistrictId != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>");
#nullable restore
#line 17 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                         Write(item.Property.City.CityName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" şəh/");
#nullable restore
#line 17 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                                          Write(item.Property.District.DistrictName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ray.</span>\r\n");
#nullable restore
#line 18 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>");
#nullable restore
#line 21 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                         Write(item.Property.City.CityName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" şəhəri</span>\r\n");
#nullable restore
#line 22 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                <div class=\"property-price\">\r\n\r\n");
#nullable restore
#line 26 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                     if (item.AddTypeID == 1) //Günlük kirayə
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"present-price\">");
#nullable restore
#line 28 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                               Write(item.PropPrice.ToString("0.0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₼/gün</span>\r\n");
#nullable restore
#line 29 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                    }
                    else if (item.AddTypeID == 2) //Aylıq kirayə
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"present-price\">");
#nullable restore
#line 32 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                               Write(item.PropPrice.ToString("0.0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₼/ay</span>\r\n");
#nullable restore
#line 33 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span class=\"present-price\">");
#nullable restore
#line 36 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                               Write(item.PropPrice.ToString("0.0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₼</span>");
#nullable restore
#line 36 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                                                                            // Satılır
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"additional-properties\">\r\n\r\n\r\n");
#nullable restore
#line 43 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                     if (item.Property.FloorId > 0 && item.Property.FloorSum > 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"add-prop-item\">\r\n                            <i class=\"fas fa-home\"></i>\r\n                            <span class=\"num\">");
#nullable restore
#line 47 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                         Write(item.Property.FloorId);

#line default
#line hidden
#nullable disable
            WriteLiteral("/");
#nullable restore
#line 47 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                                                Write(item.Property.FloorSum);

#line default
#line hidden
#nullable disable
            WriteLiteral(" mərtəbə</span>\r\n                        </div>\r\n");
#nullable restore
#line 49 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"

                    }
                    else if (item.Property.FloorSum > 0 && item.Property.FloorId == null) //həyət evi
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"add-prop-item\">\r\n                            <i class=\"fas fa-home\"></i>\r\n                            <span class=\"num\">");
#nullable restore
#line 55 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                         Write(item.Property.FloorSum);

#line default
#line hidden
#nullable disable
            WriteLiteral(" mərtəbə</span>\r\n                        </div>\r\n");
#nullable restore
#line 57 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 59 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                     if (item.Property.FlatId > 0 && item.Property.PropertySortId < 3)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"add-prop-item\">\r\n                            <i class=\"far fa-square\"></i>\r\n                            <span class=\"num\">");
#nullable restore
#line 63 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                         Write(item.Property.FloorId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" otaq</span>\r\n                        </div>\r\n");
#nullable restore
#line 65 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 67 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                     if (item.Property.PropertySort.PropertySortId > 3 && item.Property.PropertySort.PropertySortId < 6) //Ofis, Qaraj
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"add-prop-item\">\r\n                            <i class=\"far fa-square\"></i>\r\n                            <span class=\"num\">");
#nullable restore
#line 71 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                         Write(item.Property.BuildingVolume.Value.ToString("0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" kv/m</span>\r\n                        </div>\r\n");
#nullable restore
#line 73 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 75 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                     if (item.Property.PropertySort.PropertySortId > 5) //Torpaq
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"add-prop-item\">\r\n                            <i class=\"far fa-square\"></i>\r\n                            <span class=\"num\">");
#nullable restore
#line 79 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                         Write(item.Property.LandVolume.Value.ToString("0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" sot</span>\r\n                        </div>\r\n");
#nullable restore
#line 81 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"add-sort\">\r\n");
#nullable restore
#line 85 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                     if (item.AddTypeID < 3) //Kirayələr
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h3 class=\"name\">Kirayə</h3>\r\n");
#nullable restore
#line 88 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                    }
                    else //Satış
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h3 class=\"name\">Satış</h3>\r\n");
#nullable restore
#line 92 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                <div class=\"prop-sort\">\r\n                    <h3 class=\"name\">");
#nullable restore
#line 95 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                Write(item.Property.PropertySort.PropertySortName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                </div>\r\n                <div class=\"hover-overlay\">\r\n                    <ul>\r\n                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "067906b12084f3a9da0b1cd453cebeefb71bfc6621138", async() => {
                WriteLiteral("Ətraflı");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 99 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
                                                                                          WriteLiteral(item.AddvertisimentID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 105 "C:\Users\SAMED\source\repos\FINAL\FINAL\Views\Shared\_AddsPanel.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AddsPanelViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
