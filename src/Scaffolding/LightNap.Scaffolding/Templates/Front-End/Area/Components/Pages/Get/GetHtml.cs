﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace LightNap.Scaffolding.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Get\GetHtml.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class GetHtml : LightNap.Scaffolding.Templates.BaseTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write("\r\n<p-card header=\"Get\">\r\n  <api-response [apiResponse]=\"");
            
            #line 8 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Get\GetHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.CamelName));
            
            #line default
            #line hidden
            this.Write("$\" errorMessage=\"Error loading\" loadingMessage=\"Loading...\">\r\n    <ng-template #s" +
                    "uccess let-");
            
            #line 9 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Get\GetHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.CamelName));
            
            #line default
            #line hidden
            this.Write(@">
      <div class=""flex gap-1 mb-1"">
        <p-button [routerLink]=""['..']"" icon=""pi pi-arrow-up"" label=""Up to all"" />
        <p-button [routerLink]=""['..', id(), 'edit']"" icon=""pi pi-pencil"" label=""Edit"" />
      </div>
      <div class=""w-30rem flex flex-column gap-4"">
        <div>
          <label class=""block text-900 font-medium mb-2"">");
            
            #line 16 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Get\GetHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.IdProperty.Name));
            
            #line default
            #line hidden
            this.Write("</label>\r\n          <div>{{ ");
            
            #line 17 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Get\GetHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.CamelName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 17 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Get\GetHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.IdProperty.CamelName));
            
            #line default
            #line hidden
            this.Write(" }}</div>\r\n        </div>\r\n");
            
            #line 19 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Get\GetHtml.tt"
 foreach (var property in Parameters.GetProperties) { 
            
            #line default
            #line hidden
            this.Write("        <div>\r\n          <label class=\"block text-900 font-medium mb-2\">");
            
            #line 21 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Get\GetHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.Name));
            
            #line default
            #line hidden
            this.Write("</label>\r\n          <div>{{ ");
            
            #line 22 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Get\GetHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.CamelName));
            
            #line default
            #line hidden
            this.Write(".");
            
            #line 22 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Get\GetHtml.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.CamelName));
            
            #line default
            #line hidden
            this.Write(" }}</div>\r\n        </div>\r\n");
            
            #line 24 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Get\GetHtml.tt"
 } 
            
            #line default
            #line hidden
            this.Write("      </div>\r\n    </ng-template>\r\n  </api-response>\r\n</p-card>");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}