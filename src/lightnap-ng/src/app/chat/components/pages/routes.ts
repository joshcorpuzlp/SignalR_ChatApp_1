import { AppRoute } from "@routing";

export const Routes: AppRoute[] = [
  { 
    path: "", 
    data: { alias: "chat-window" }, 
    loadComponent: () => import("./chat-window/chat-window.component").then(m => m.ChatWindowComponent) 
  },
];