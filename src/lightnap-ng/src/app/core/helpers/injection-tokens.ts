import { InjectionToken } from "@angular/core";

/**
 * Injection token for the root URL of the API.
 *
 * This token can be used to inject the root URL of the API into Angular services or components.
 *
 * @example
 * ```typescript
 * constructor(@Inject(API_URL_ROOT) private apiUrlRoot: string) {}
 * ```
 */
export const API_URL_ROOT = new InjectionToken<string>('API_URL_ROOT');


/**
 * Injection token for the signalR URL of the API.
 *
 * This token can be used to inject the signalR URL of the API into Angular services or components.
 *
 * @example
 * ```typescript
 * constructor(@Inject(SIGNALR_API_URL_ROOT) private signalrApiUrlRoot: string) {}
 * ```
 */
export const SIGNALR_API_URL_ROOT = new InjectionToken<string>('SIGNALR_API_URL_ROOT');
