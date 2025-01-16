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
import { BehaviorSubject, Subject, switchMap, takeUntil } from 'rxjs';
import { ChatService } from 'src/app/chat/services/chat.service';

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
  #toast = inject(ToastService);
  #identityService = inject(IdentityService);
  
  private destroy$ = new Subject<void>();
  private loadData$ = new Subject<void>();

  messageInput: string = '';
  roomName: string = '';
  selectedRoom: Room;
  hasSelectedRoom: boolean = false;

  rooms: Room[];

  errors = new Array<string>();

  
  public TestMesssages: SampleMessage[] = [
    { message: "Hi there!", isMyMessage: false },
    { message: "How are you?", isMyMessage: false },
    { message: "What's up?", isMyMessage: true },
    { message: "See you soon.", isMyMessage: true },
    { message: "Let's chat!", isMyMessage: false },
    { message: "Good morning!", isMyMessage: false },
    { message: "Good night.", isMyMessage: true },
    { message: "Take care.", isMyMessage: false },
    { message: "Thanks a lot!", isMyMessage: true },
    { message: "Sounds good!", isMyMessage: true }
  ];

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
    this.#chatService.leaveChat();
    this.selectedRoom = null;
  }

  sendMessage() {
    if (this.messageInput.trim()) {
      this.TestMesssages.push({message: this.messageInput.trim(), isMyMessage: true});
      this.messageInput = '';
    }
  }

  joinRoom($event, roomId) {
    this.selectedRoom = this.rooms.find(x => x.id == roomId);
    this.#chatService.joinRoom(this.#identityService.userId ,this.selectedRoom.name);
  }

  constructor() {
      
  }

  ngOnInit(): void {
    this.loadData$.pipe(
      takeUntil(this.destroy$),
      switchMap(() => this.#roomService.getRooms()))
      .subscribe(data => {
        this.rooms = data;
      });
      
    this.loadData$.next();
  }

  ngOnDestroy(): void {
    this.destroy$.next();
  }

}
