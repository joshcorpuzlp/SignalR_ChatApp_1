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
    
    #line 1 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class CreateCode : LightNap.Scaffolding.Templates.BaseTemplate
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"
import { CommonModule } from ""@angular/common"";
import { Component, inject } from ""@angular/core"";
import { FormBuilder, ReactiveFormsModule, Validators } from ""@angular/forms"";
import { ActivatedRoute, Router, RouterLink } from ""@angular/router"";
import { ErrorListComponent } from ""@core"";
import { ButtonModule } from ""primeng/button"";
import { CalendarModule } from ""primeng/calendar"";
import { CardModule } from ""primeng/card"";
import { CheckboxModule } from ""primeng/checkbox"";
import { InputNumberModule } from ""primeng/inputnumber"";
import { InputTextModule } from ""primeng/inputtext"";
import { Create");
            
            #line 18 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.PascalName));
            
            #line default
            #line hidden
            this.Write("Request } from \"src/app/");
            
            #line 18 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.KebabNamePlural));
            
            #line default
            #line hidden
            this.Write("/models/request/create-");
            
            #line 18 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.KebabName));
            
            #line default
            #line hidden
            this.Write("-request\";\r\nimport { ");
            
            #line 19 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.PascalName));
            
            #line default
            #line hidden
            this.Write("Service } from \"src/app/");
            
            #line 19 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.KebabNamePlural));
            
            #line default
            #line hidden
            this.Write("/services/");
            
            #line 19 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.KebabName));
            
            #line default
            #line hidden
            this.Write(@".service"";

@Component({
  standalone: true,
  templateUrl: ""./create.component.html"",
  imports: [
    CommonModule,
    CardModule,
    ReactiveFormsModule,
    RouterLink,
    CalendarModule,
    ButtonModule,
    InputTextModule,
    InputNumberModule,
    CheckboxModule,
    ErrorListComponent,
  ],
})
export class CreateComponent {
  #");
            
            #line 38 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.CamelName));
            
            #line default
            #line hidden
            this.Write("Service = inject(");
            
            #line 38 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.PascalName));
            
            #line default
            #line hidden
            this.Write("Service);\r\n  #router = inject(Router);\r\n  #activeRoute = inject(ActivatedRoute);\r" +
                    "\n  #fb = inject(FormBuilder);\r\n\r\n  errors = new Array<string>();\r\n\r\n  form = thi" +
                    "s.#fb.group({\r\n\t// TODO: Update these fields to match the right parameters.\r\n");
            
            #line 47 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
  foreach (var property in Parameters.SetProperties) {
        switch (property.FrontEndType) {
            case "boolean": 
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 50 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.CamelName));
            
            #line default
            #line hidden
            this.Write(": this.#fb.control(false, [Validators.required]),\r\n");
            
            #line 51 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
              break;
            case "number": 
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 53 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.CamelName));
            
            #line default
            #line hidden
            this.Write(": this.#fb.control(0, [Validators.required]),\r\n");
            
            #line 54 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
              break;
            case "Date": 
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 56 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.CamelName));
            
            #line default
            #line hidden
            this.Write(": this.#fb.control(new Date(), [Validators.required]),\r\n");
            
            #line 57 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
              break;
            default:
                if (property.BackEndType == "Guid") { 
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 60 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.CamelName));
            
            #line default
            #line hidden
            this.Write(": this.#fb.control(\"a0641a12-dead-beef-f00d-f1acc1d171e5\", [Validators.required])" +
                    ",\r\n");
            
            #line 61 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
              }
                else if (property.BackEndType == "TimeSpan") { 
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 63 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.CamelName));
            
            #line default
            #line hidden
            this.Write(": this.#fb.control(\"01:00:00\", [Validators.required]),\r\n");
            
            #line 64 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
              }
                else { 
            
            #line default
            #line hidden
            this.Write("\t");
            
            #line 66 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(property.CamelName));
            
            #line default
            #line hidden
            this.Write(": this.#fb.control(\"string\", [Validators.required]),\r\n");
            
            #line 67 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
              }
            break;
        }
    }
            
            #line default
            #line hidden
            this.Write("  });\r\n\r\n  createClicked() {\r\n    this.errors = [];\r\n\r\n    const request = <Creat" +
                    "e");
            
            #line 76 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.PascalName));
            
            #line default
            #line hidden
            this.Write("Request>this.form.value;\r\n\r\n    this.#");
            
            #line 78 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.CamelName));
            
            #line default
            #line hidden
            this.Write("Service.create");
            
            #line 78 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.PascalName));
            
            #line default
            #line hidden
            this.Write("(request).subscribe(response => {\r\n      if (!response.result) {\r\n        this.er" +
                    "rors = response.errorMessages;\r\n        return;\r\n      }\r\n\r\n      this.#router.n" +
                    "avigate([response.result.");
            
            #line 84 "C:\Users\edkai\source\repos\SharpLogic\LightNap\src\Scaffolding\LightNap.Scaffolding\Templates\Front-End\Area\Components\Pages\Create\CreateCode.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Parameters.IdProperty.CamelName));
            
            #line default
            #line hidden
            this.Write("], { relativeTo: this.#activeRoute.parent });\r\n    });\r\n  }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
}
