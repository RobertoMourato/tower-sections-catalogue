namespace server_side.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime RegisteredDate { get; set; } = DateTime.Now;

    }
}