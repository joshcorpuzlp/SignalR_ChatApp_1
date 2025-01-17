import { Component } from "@angular/core";
import { RouterModule } from "@angular/router";
import { RoutePipe } from "@routing";
import { IdentityCardComponent } from "@identity/components/controls/identity-card/identity-card.component";

@Component({
  standalone: true,
  templateUrl: "./reset-instructions-sent.component.html",
  imports: [RouterModule, RoutePipe, IdentityCardComponent],
})
export class ResetInstructionsSentComponent {}
