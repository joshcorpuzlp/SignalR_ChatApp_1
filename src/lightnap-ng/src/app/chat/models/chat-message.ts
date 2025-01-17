export interface ChatMessage {
    id: number;
    chatMessage: string;
    sentByUserId: number;
    roomId: number;
    createDate: Date;
}