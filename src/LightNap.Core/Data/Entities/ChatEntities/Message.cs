namespace LightNap.Core.Data.Entities.ChatEntities {

    /// <summary>
    /// Represents a message for the Chat feature
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Message's Id.
        /// </summary>
        public int Id { get; set;}

        /// <summary>
        /// The Message data itself
        /// </summary>
        public string ChatMessage { get; set;} = string.Empty;

        /// <summary>
        /// The User Id of the sender
        /// </summary>
        public string SentByUserId { get; set;}

        /// <summary>
        /// The Room Id the message belongs to.
        /// </summary>
        public int RoomId { get; set;}  

        /// <summary>
        /// The date when the message was created.
        /// </summary>
        public DateTime CreateDate { get; set;}
    }
}


