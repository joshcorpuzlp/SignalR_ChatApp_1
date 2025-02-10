import { LocationStrategy, PathLocationStrategy } from "@angular/common";
import { provideHttpClient, withInterceptors } from "@angular/common/http";
import { APP_INITIALIZER, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { provideAnimations } from "@angular/platform-browser/animations";
import { RouterModule } from "@angular/router";
import { API_URL_ROOT, SIGNALR_API_URL_ROOT } from "@core";
import { apiResponseInterceptor } from "@core/interceptors/api-response-interceptor";
import { tokenInterceptor } from "@core/interceptors/token-interceptor";
import { InitializationService } from "@core/services/initialization.service";
import { RouteConfig, Routes } from "@routing/routes";
import { ConfirmationService, MessageService } from "primeng/api";
import { BlockUIModule } from "primeng/blockui";
import { ToastModule } from "primeng/toast";
import { environment } from "src/environments/environment";
import { AppComponent } from "./app.component";

export function initializeApp(initializationService: InitializationService) {
  return () => initializationService.initialize();
}

@NgModule({
  declarations: [AppComponent],
  imports: [RouterModule.forRoot(Routes, RouteConfig), BrowserModule, ToastModule, BlockUIModule],
  providers: [
    InitializationService,
    {
      provide: APP_INITIALIZER,
      useFactory: initializeApp,
      deps: [InitializationService],
      multi: true,
    },
    provideAnimations(),
    { provide: API_URL_ROOT, useValue: environment.apiUrlRoot },
    { provide: SIGNALR_API_URL_ROOT, useValue: environment.signalRApiUrlRoot },
    { provide: LocationStrategy, useClass: PathLocationStrategy },
    provideHttpClient(withInterceptors([tokenInterceptor, apiResponseInterceptor])),
    MessageService,
    ConfirmationService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
