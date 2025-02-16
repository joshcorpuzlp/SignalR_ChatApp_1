import { Room } from '@admin/models/response/room';
import { RoomService } from '@admin/services/room.service';
import { CommonModule } from '@angular/common';
import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ToastService } from '@core';
import { ApiResponseComponent, ConfirmPopupComponent, ErrorListComponent } from '@core/components';
import { IdentityService } from '@identity';
import { ProfileService } from '@profile/services/profile.service';
import { RoutePipe } from '@routing';
import { UserService } from '@user/services/user.service';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';
import { BehaviorSubject, map, Observable, Subject, switchMap, takeUntil } from 'rxjs';
import { ChatMessage } from 'src/app/chat/models/chat-message';
import { ChatService } from 'src/app/chat/services/chat.service';
import { MessageService as ChatMessageService } from 'src/app/chat/services/message.service';

interface SampleMessage {
  message: string,
  isMyMessage: boolean
}

@Component({
  selector: 'app-chat-window',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    CardModule,
    ApiResponseComponent,
    TableModule,
    ButtonModule,
    RouterModule,
    RoutePipe,
    DropdownModule,
    ErrorListComponent,
    InputTextModule,
    ConfirmPopupComponent,
    TagModule,
  ],
  templateUrl: './chat-window.component.html',
  styleUrl: './chat-window.component.scss'
})
export class ChatWindowComponent implements OnInit, OnDestroy {
  #roomService = inject(RoomService);
  #chatService = inject(ChatService);
  #chatMessageService = inject(ChatMessageService);
  #toast = inject(ToastService);
  #identityService = inject(IdentityService);
  
  private destroy$ = new Subject<void>();
  private loadData$ = new Subject<void>();

  messageInput: string = '';
  roomName: string = '';
  selectedRoom: Room;
  hasSelectedRoom: boolean = false;

  rooms: Room[];
  currentUserId: string;

  errors = new Array<string>();

  public chatMessages: ChatMessage[] = [];

  createRoom() {
    if (this.roomName.trim()) {
      this.#roomService.createRoom(this.roomName)
      .pipe(
        takeUntil(this.destroy$)
      )
      .subscribe({
        next: () => {
          this.roomName = '';
          this.loadData$.next();
        },
        error: response => {
          this.errors = response.errorMessages;
          this.#toast.error(response.errorMessages);
        }
      })
    }
  }

  leaveRoom() {
    this.#chatService.leaveRoom(this.selectedRoom.id, this.#identityService.userId);
    this.selectedRoom = null;
  }

  sendMessage() {
    if (this.messageInput.trim()) {
      this.#chatService.sendMessage(this.messageInput, this.selectedRoom.id, this.#identityService.userId);
      this.messageInput = '';
    }
  }

  async joinRoom(roomId) {
    this.selectedRoom = this.rooms.find(x => x.id == roomId);
    await this.#chatService.joinRoom(this.#identityService.userId ,this.selectedRoom.name)
    this.#chatMessageService.getMessageHistory(roomId).pipe(
      takeUntil(this.destroy$),
      map(response => 
        response.map(res => ({
          ...res,
          isUserMessage: res.sentByUserId == this.currentUserId
        })))
    ).subscribe(updatedRecords => {
      this.chatMessages = [...updatedRecords]
    })
  }

  constructor() {
      
  }

  ngOnInit(): void {
    this.currentUserId = this.#identityService.userId;
    console.log(this.currentUserId)
    this.loadData$.pipe(
      takeUntil(this.destroy$),
      switchMap(() => this.#roomService.getRooms()))
      .subscribe(data => {
        this.rooms = data;
      });
    
    this.#chatService.messages$
      .pipe(takeUntil(this.destroy$))
      .subscribe((data: any[]) => {
        var dataLength = data.length;
        var currentData = data[dataLength - 1];
        if (currentData.user == "System") {
          this.#toast.info(currentData.message);
        }
        else {
          this.chatMessages = [...this.chatMessages, {
            id: 0,
            chatMessage: currentData.message,
            createDate: currentData.messageTime,
            roomId: this.selectedRoom.id,
            sentByUserId: currentData.user,
            isUserMessage: this.currentUserId == currentData.user
          }]
        }
      })
    this.loadData$.next();
  }

  ngOnDestroy(): void {
    this.#chatService.leaveChat();
    this.destroy$.next();
  }
}
