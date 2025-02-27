#pragma checksum "D:\Project\edu-mark\src\News.Web\Views\Admin\CreateNews.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "97bb0ab1a4b73853a8914920a560a5e73358965996ac7929733454a37f0fc97e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_CreateNews), @"mvc.1.0.view", @"/Views/Admin/CreateNews.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Project\edu-mark\src\News.Web\Views\_ViewImports.cshtml"
using News.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\edu-mark\src\News.Web\Views\_ViewImports.cshtml"
using News.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"97bb0ab1a4b73853a8914920a560a5e73358965996ac7929733454a37f0fc97e", @"/Views/Admin/CreateNews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"216d9bcf488b45d1bb39e449c0207d0a1d9d117715edff6eb27adc3c0792f8ef", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_CreateNews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<News.Core.Entities.Category>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/ckeditor/ckeditor.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateNews", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Project\edu-mark\src\News.Web\Views\Admin\CreateNews.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "97bb0ab1a4b73853a8914920a560a5e73358965996ac7929733454a37f0fc97e5172", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<h4 class=""fw-bold py-3 mb-4""><span class=""text-muted fw-light"">Bài viết /</span> Thêm mới</h4>

<p>
    Thêm mới bài viết
</p>

<!-- Icon container -->
<div class=""d-flex flex-wrap"" id=""icons-container"">
    <div class=""row"" style=""width: 100%;"">
        <div class=""col-md-12"">
            <div class=""card mb-12"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "97bb0ab1a4b73853a8914920a560a5e73358965996ac7929733454a37f0fc97e6594", async() => {
                WriteLiteral(@"
                    <div class=""card-body"">
                    <div>
                        <label for=""defaultFormControlInput"" class=""form-label"">Tiêu đề bài viết</label>
                        <input type=""text"" name=""Title"" class=""form-control"" id=""defaultFormControlInput"" placeholder=""Tiêu đề bài viết"" aria-describedby=""defaultFormControlHelp"">
                    </div>
                    <div>
                        <label for=""defaultFormControlInput"" class=""form-label"">Chọn danh mục</label>
                        <select id=""defaultSelect"" name=""CategoryId"" class=""form-select"">
");
#nullable restore
#line 28 "D:\Project\edu-mark\src\News.Web\Views\Admin\CreateNews.cshtml"
                             foreach(var category in Model)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "97bb0ab1a4b73853a8914920a560a5e73358965996ac7929733454a37f0fc97e7810", async() => {
#nullable restore
#line 30 "D:\Project\edu-mark\src\News.Web\Views\Admin\CreateNews.cshtml"
                                                    Write(category.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "D:\Project\edu-mark\src\News.Web\Views\Admin\CreateNews.cshtml"
                               WriteLiteral(category.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 31 "D:\Project\edu-mark\src\News.Web\Views\Admin\CreateNews.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </select>
                    </div>
                    <div class=""mb-3"">
                        <label for=""formFile"" class=""form-label"">Hình ảnh chính</label>
                        <input class=""form-control"" type=""file"" id=""thumbnail"" name=""File"" hidden>
                        <img style=""width:30%; height:auto;"" src=""https://www.eventbrite.com/engineering/wp-content/uploads/engineering/2018/08/Flexible-Reusable-React-File-Uploader.png"" class=""img-thumbnail"" id=""preview-image"">
                        <input class=""form-control"" type=""text"" id=""image"" name=""Image"" hidden>

                      </div>
                      <div class=""mb-3"">
                        <label for=""formFile"" class=""form-label"">Lấy URL hình ảnh</label>
                        <input class=""form-control"" type=""file"" id=""child-image"" name=""File"">
                      </div>
                    <div>
                        <label for=""defaultFormControlInput"" class=""form-label"">Nội dung");
                WriteLiteral(@"</label>
                        <textarea class=""form-control"" name=""Content"" rows=""10"" placeholder=""Nội dung bài viết"" aria-describedby=""defaultFormControlHelp""></textarea>
                    </div>
                    <div style=""margin-top: 10px; float:right; margin-bottom: 10px;"">
                        <button type=""submit"" class=""btn btn-primary"">Thêm mới bài viết</button>
                    </div>
                </div>
            
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
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
        
    </div>
</div>
<script>  
    config.width
            CKEDITOR.replace(""Content"");  
</script>
<script>
    $(document).ready(function(){
        $(""#preview-image"").click(function(){
            $('#thumbnail').trigger('click');
        });

        $(""#child-image"").change(function() {
            let url = '");
#nullable restore
#line 71 "D:\Project\edu-mark\src\News.Web\Views\Admin\CreateNews.cshtml"
                  Write(Url.Action("UploadFile","Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
            var formData = new FormData();
            var file = $(""#child-image"").prop(""files"")[0];
            formData.append(""file"",file);
            $.ajax({
                    url: url,
                    type: ""POST"",
                    cache: false,
                    processData: false,
                    contentType: false,
                    enctype: 'multipart/form-data',
                    data: formData,
                    success: function (data) {
                        navigator.clipboard.writeText(data.url);
                        toastMixin.fire({
                            title: 'Đã sao chép URL vào bộ nhớ tạm.',
                            icon: 'success'
                        });
                    }
                });
        });

        $(""#thumbnail"").change(function() {
            let url = '");
#nullable restore
#line 94 "D:\Project\edu-mark\src\News.Web\Views\Admin\CreateNews.cshtml"
                  Write(Url.Action("UploadFile","Admin"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';
            var formData = new FormData();
            var file = $(""#thumbnail"").prop(""files"")[0];
            formData.append(""file"",file);
            $.ajax({
                    url: url,
                    type: ""POST"",
                    cache: false,
                    processData: false,
                    contentType: false,
                    enctype: 'multipart/form-data',
                    data: formData,
                    success: function (data) {
                        $(""#preview-image"").attr('src',data.url);
                        $(""#image"").val(data.url);

                    }
                });
        });
    });
    
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<News.Core.Entities.Category>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
