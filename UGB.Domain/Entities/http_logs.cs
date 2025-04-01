namespace UGB.Domain.Entities
{
    public class http_logs
    {
        public int id {get;set;}
        public int statusCode {get;set;}
        public string url {get;set;}
        public string request {get;set;}
        public string response {get;set;}
        public DateTime date {get;set;}
        public string username {get;set;}
        public string method {get;set;}
    }
}