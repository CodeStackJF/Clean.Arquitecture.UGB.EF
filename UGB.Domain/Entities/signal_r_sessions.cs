namespace UGB.Domain.Entities
{
    public class signal_r_sessions
    {
        public string username {get;set;}
        public bool connected {get;set;}
        public DateTime connection_date {get;set;}
        public string connection_id { get; set; }
    }
}