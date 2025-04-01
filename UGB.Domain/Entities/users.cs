namespace UGB.Domain.Entities
{
    public partial class users
    {
        public int id { get; set; }
        public string username { get; set; }
        public bool active { get; set; }
        public string salt { get; set; }
        public string password { get; set; }
    }
}