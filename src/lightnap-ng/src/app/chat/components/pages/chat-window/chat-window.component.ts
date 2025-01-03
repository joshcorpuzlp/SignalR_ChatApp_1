import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ApiResponseComponent, ConfirmPopupComponent, ErrorListComponent } from '@core/components';
import { RoutePipe } from '@routing';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { DropdownModule } from 'primeng/dropdown';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { TagModule } from 'primeng/tag';

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
export class ChatWindowComponent implements OnInit {
  
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

  messageInput: string = '';

  sendMessage() {
    if (this.messageInput.trim()) {
      this.TestMesssages.push({message: this.messageInput.trim(), isMyMessage: true});
      this.messageInput = '';
    }
  }

  constructor() {
      
  }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

}
