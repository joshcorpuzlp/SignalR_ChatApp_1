export interface ChatMessage {
    id: number;
    chatMessage: string;
    sentByUserId: string;
    roomId: number;
    createDate: Date;
    isUserMessage?: boolean;
}