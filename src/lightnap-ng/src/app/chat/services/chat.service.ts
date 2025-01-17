import { Injectable, Signal } from "@angular/core";
import * as signalR from '@microsoft/signalr';
import { BehaviorSubject } from "rxjs";


@Injectable({
  providedIn: "root",
})
export class ChatService {
    public connection : signalR.HubConnection = new signalR.HubConnectionBuilder()
        .withUrl("https://localhost:7266/chat")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    public messages$ = new BehaviorSubject<any>([]);
    public connectedUsers$ = new BehaviorSubject<string[]>([]);
    public messages: any[] = [];
    public users: string[] = [];

    constructor() {
        this.start();
        this.connection.on("ReceiveMessage", (user: string, message: string, messageTime: string)=>{
            this.messages = [...this.messages, {user, message, messageTime} ];
            this.messages$.next(this.messages);
          });
        
        this.connection.on("ConnectedUser", (users: any)=>{
            this.connectedUsers$.next(users);
        });
    }

    //start connection
    public async start(){
        try {
            await this.connection.start();
            console.log("Connection is established!")
        } catch (error) {
        console.log(error);
        }
    }

    //Join Room
    public async joinRoom(user: string, room: string){
        if (this.connection.state !== 'Connected') {
            await this.start();
        }
        return await this.connection.invoke("JoinRoom", user, room)
    }


    // Send Messages
    public async sendMessage(message: string, roomId: number, user: string){
        return this.connection.invoke("SendMessage", message, roomId, user);
    }

    //leave
    public async leaveChat(){
        return this.connection.stop();
    }
}
