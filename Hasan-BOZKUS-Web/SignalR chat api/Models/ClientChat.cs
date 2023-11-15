namespace SignalR_chat_api.Models
{
    public class ClientChat
    {
        public int connectionId { get; set; }
        public string user { get; set; }
        public string message { get; set; }
    }
}
