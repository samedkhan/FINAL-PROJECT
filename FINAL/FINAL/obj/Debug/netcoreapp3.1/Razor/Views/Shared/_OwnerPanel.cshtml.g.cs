#pragma checksum "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b0ffce256c52e22bff04eab6721f02da7b0d60c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__OwnerPanel), @"mvc.1.0.view", @"/Views/Shared/_OwnerPanel.cshtml")]
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
#line 1 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\_ViewImports.cshtml"
using FINAL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\_ViewImports.cshtml"
using FINAL.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\_ViewImports.cshtml"
using FINAL.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b0ffce256c52e22bff04eab6721f02da7b0d60c6", @"/Views/Shared/_OwnerPanel.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ce70e539199f7c42679e3a9250e0583310adbda", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__OwnerPanel : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OwnerPanelViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/logo/user.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/logo/agency.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "agency", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"partner-panel\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"contain\">\r\n                <div class=\"general\">\r\n                    <div class=\"photo\">\r\n");
#nullable restore
#line 9 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                         if (Model.Owner.Logo != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b0ffce256c52e22bff04eab6721f02da7b0d60c65235", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 351, "~/img/users/", 351, 12, true);
#nullable restore
#line 11 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
AddHtmlAttributeValue("", 363, Model.Owner.Logo, 363, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 11 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
AddHtmlAttributeValue("", 387, Model.Owner.Name, 387, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 12 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                        }
                        else if (Model.Owner.Logo == null && Model.Owner.UserTypeID == 1)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b0ffce256c52e22bff04eab6721f02da7b0d60c67527", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 15 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
AddHtmlAttributeValue("", 617, Model.Owner.Name, 617, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 16 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "b0ffce256c52e22bff04eab6721f02da7b0d60c69310", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 19 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
AddHtmlAttributeValue("", 788, Model.Owner.Name, 788, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 20 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <div class=\"name\">\r\n");
#nullable restore
#line 23 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                         if (Model.Owner.UserTypeID == 1) //Agency
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h2 class=\"name\">");
#nullable restore
#line 25 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                                        Write(Model.Owner.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                            <span>Agentlik</span>\r\n");
#nullable restore
#line 27 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <h2 class=\"name\">");
#nullable restore
#line 30 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                                        Write(Model.Owner.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 30 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                                                          Write(Model.Owner.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n");
#nullable restore
#line 31 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                             if (Model.Owner.UserTypeID == 2)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>Ev sahibi</span>\r\n");
#nullable restore
#line 34 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span>Vasitəçi</span>\r\n");
#nullable restore
#line 38 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                             
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n");
#nullable restore
#line 41 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                     if (Model.Owner.UserTypeID == 1)//Agency
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0ffce256c52e22bff04eab6721f02da7b0d60c613999", async() => {
                WriteLiteral("\r\n                            <div class=\"partner-adds\">\r\n                                <span>");
#nullable restore
#line 45 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                                 Write(Model.OwnerActiveAdds);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ELAN</span>\r\n                            </div>\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                                                                         WriteLiteral(Model.Owner.UserId);

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
            WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n");
#nullable restore
#line 50 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                 if (Model.Owner.AboutCompany != null)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"about\">\r\n                        <h2>Haqqında</h2>\r\n                        <p>");
#nullable restore
#line 54 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                      Write(Model.Owner.AboutCompany);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n");
#nullable restore
#line 56 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <div class=\"contact\">\r\n                    <h2>Əlaqə</h2>\r\n                    <ul>\r\n");
#nullable restore
#line 61 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                         if (Model.Owner.Adress != null)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <li>
                                <div class=""header-text"">
                                    <i class=""fas fa-map-marker-alt""></i> Ünvan
                                </div>
                                <div class=""info-text"">
                                    <span>");
#nullable restore
#line 68 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                                     Write(Model.Owner.Adress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                </div>\r\n                            </li>\r\n");
#nullable restore
#line 71 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <li>
                            <div class=""header-text"">
                                <i class=""fas fa-phone-alt""></i> Telefon
                            </div>
                            <div class=""info-text"">
                                <span>");
#nullable restore
#line 78 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                                 Write(Model.Owner.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>
                        </li>
                        <li>
                            <div class=""header-text"">
                                <i class=""far fa-envelope""></i> E-mail
                            </div>
                            <div class=""info-text"">
                                <span>");
#nullable restore
#line 86 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                                 Write(Model.Owner.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                            </div>
                        </li>
                        <li>
                            <div class=""header-text"">
                                <i class=""far fa-calendar-alt"" aria-hidden=""true""></i> Qeydiyyat tarixi
                            </div>
                            <div class=""info-text"">
                                <span>");
#nullable restore
#line 94 "C:\Users\SAMED\Desktop\FINAL\FINAL\FINAL\Views\Shared\_OwnerPanel.cshtml"
                                 Write(Model.Owner.CreatedAt.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                        </li>\r\n\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OwnerPanelViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
