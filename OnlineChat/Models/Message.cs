namespace OnlineChat.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime? SendTime { get; set; }

        public User Sender { get; set; }//who send

        public User? AddresseeUser { get; set; }//who recieve
        public Group? AddresseeGroup { get; set; }
        public bool DeletedForMyself { get; set; } = false;
        public Message? ReplyTo { get; set; } = null;
    }
}
