import { inject, Injectable } from "@angular/core";
import { API_URL_ROOT } from "@core";
import { ChatMessage } from "../models/chat-message";
import { HttpClient } from "@angular/common/http";
@Injectable({
  providedIn: "root",
})
export class MessageService {
    #http = inject(HttpClient);
    #apiUrlRoot = `${inject(API_URL_ROOT)}Message/`;

    /**
   * Gets a user by their ID.
   * @param {string} userId - The ID of the user to retrieve.
   * @returns {Observable<ChatMessage[]>} An observable containing the user data.
   */
    getMessageHistory(roomId: number) {
        // return this.#http.get<Message[]>(`${this.#apiUrlRoot}get-message-history/${roomId}`);
        return this.#http.get<ChatMessage[]>(`${this.#apiUrlRoot}get-message-history/${roomId}`);
    }

    createMessage(newMessage: ChatMessage) {
      
    }
}