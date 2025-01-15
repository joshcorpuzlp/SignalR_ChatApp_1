import { Room } from "@admin/models/response/room";
import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { API_URL_ROOT } from "@core";

@Injectable({
  providedIn: "root",
})
export class RoomService
 {
  #http = inject(HttpClient);
  #apiUrlRoot = `${inject(API_URL_ROOT)}Room/`;

  getRooms() {
    return this.#http.get<Room[]>(`${this.#apiUrlRoot}get-rooms`)
  }

  createRoom(name: string) {
    return this.#http.post<Room>(`${this.#apiUrlRoot}create-room/${name}`, null);
  }

}
