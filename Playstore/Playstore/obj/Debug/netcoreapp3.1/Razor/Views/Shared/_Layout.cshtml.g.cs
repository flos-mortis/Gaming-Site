#pragma checksum "C:\Users\1\Documents\GitHub\Gaming-Site\Playstore\Playstore\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a41b77881405b9b373dee0e767ec91351b090799"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "C:\Users\1\Documents\GitHub\Gaming-Site\Playstore\Playstore\Views\_ViewImports.cshtml"
using Playstore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\1\Documents\GitHub\Gaming-Site\Playstore\Playstore\Views\_ViewImports.cshtml"
using Playstore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a41b77881405b9b373dee0e767ec91351b090799", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5be09fe268eeb21a166b9661e4d9de0599b04a9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("search-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a41b77881405b9b373dee0e767ec91351b0907994244", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <title>Playstore</title>
    <link rel=""stylesheet"" type=""text/css"" href=""css/site.css"">
    <link rel=""stylesheet"" type=""text/css"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.4.0/css/font-awesome.css"">
    <link rel=""stylesheet"" type=""text/css"" href=""https://fonts.googleapis.com/css?family=Montserrat:400,700"" />
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a41b77881405b9b373dee0e767ec91351b0907995678", async() => {
                WriteLiteral(@"
        <header>
            <div class=""container"">
                <div class=""row"">
                    <div class=""logo"">
                        <div class=""logo-image"">
                            <a href=""index.html"">
                                <img class=""logo-img"" src=""image/logo.png"">
                            </a>
                        </div>
                    </div>
                    <div class=""head-right"">
                        <div class=""head-login"">
                            <a href=""#""><button class=""register-switch"">
                                Sign Up
                            </button></a>
                        </div>
                        <!--ДОДЕЛАТЬ-->
                        <div class=""head-search"">
                            <button class=""btn btn-search"">
                                <i class=""fa fa-search""></i>
                            </button>
                            <div class=""search"">
                              ");
                WriteLiteral("  ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a41b77881405b9b373dee0e767ec91351b0907997024", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                            </div>
                        </div>
                        <!--ДОДЕЛАТЬ-->
                        <div class=""head-cart"">
                            <button class=""btn btn-cart"" type=""button"">
                                <i class=""fa fa-shopping-cart""></i>
                                <p><span class=""total-product"">0</span></p>
                            </button>
                        </div>
                        <div class=""language-switcher"">
                            <a href=""#"">
                                <img src=""image/en-flag.jpg"" class=""en-flag"">
                            </a>
                            <a href=""#"">
                                <img src=""image/ru-flag.jpg"" class=""ru-flag"">
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </header>
        <nav id=""t3-mainnav"" class=""wrap navbar navbar-default t3-mainnav"">
       ");
                WriteLiteral("     <div class=\"container\">\r\n                ");
#nullable restore
#line 58 "C:\Users\1\Documents\GitHub\Gaming-Site\Playstore\Playstore\Views\Shared\_Layout.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            </div>
        </nav>
        <footer>
            <div class=""container"">
                <div class=""rower"">
                    <div class=""footer-col footer-col-left"" style=""min-height: 322px;"">
                        <div class=""footer-col-inner"">
                            <div class=""col"">
                                <div class=""social-list"">
                                    <a title=""Twitter"" href=""#"" target=""_blank"">
                                        <i class=""fa fa-twitter""></i>
                                    </a>
                                    <a title=""YouTube"" href=""#"" target=""_blank"">
                                        <i class=""fa fa-youtube""></i>
                                    </a>
                                    <a title=""Vkontakte"" href=""#"" target=""_blank"">
                                        <i class=""fa fa-vk""></i>
                                    </a>
                                </div>
                     ");
                WriteLiteral(@"       </div>
                        </div>
                        <div class=""footer-col-inner"" id=""footer-links"">
                            <div class=""col"">
                                <div class=""col-module"">
                                    <h3 class=""module-title"">
                                        <span>Information</span>
                                    </h3>
                                    <ul class=""module-content"">
                                        <li><a href=""#"">About Us</a></li>
                                        <li><a href=""#"">Privacy Policy</a></li>
                                        <li><a href=""#"">Terms & Conditions</a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class=""col"">
                                <div class=""col-module"">
                                    <h3 class=""module-title"">
                                 ");
                WriteLiteral(@"       <span>My Account</span>
                                    </h3>
                                    <ul class=""module-content"">
                                        <li><a href=""#"">My Account</a></li>
                                        <li><a href=""#"">Order History</a></li>
                                        <li><a href=""#"">Shopping Cart</a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class=""footer-col footer-col-right"" style=""min-height: 322px;"">
                        <div class=""footer-col-inner footer-right"">
                            <h3 class=""module-title""><span>Contact Us</span></h3>
                            <div class=""module-content"">
                                <div class=""contact-us"">
                                    <h4>Warehouse & Offices</h4>
                                    <p>Guild");
                WriteLiteral(@"ford, Guildford, Surrey, GU1, United Kingdom</p>
                                    <h4>Retail Store</h4>
                                    <p>Saint Edburghs Road, Birmingham, West Midlands, B25 8YA, United Kingdom</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""copyright"">
            </div>
        </footer>
    ");
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
            WriteLiteral("\r\n</html>");
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
