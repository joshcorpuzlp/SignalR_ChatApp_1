/**
 * Known route aliases for the app. Add more here and then associate them with routes set up for a given
 * page using the AppRoute.data.alias property.
 */
export type RouteAlias =
    // Public
    | 'landing'
    | 'about'
    | 'terms-and-conditions'
    | 'privacy-policy'
    | 'access-denied'
    | 'error'
    | 'not-found'

    // User
    | 'user-home'

    // Chat
    | 'chat-window'

    // Admin
    | 'admin-home'
    | 'admin-users'
    | 'admin-user'
    | 'admin-roles'
    | 'admin-role'

    // Profile
    | 'profile'
    | 'devices'

    // Identity
    | 'login'
    | 'reset-password'
    | 'reset-instructions-sent'
    | 'change-password'
    | 'verify-code'
    | 'register';
