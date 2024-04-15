using System.ComponentModel.DataAnnotations;

namespace apiTest.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public int age { get; set; }
        public string country { get; set; } = string.Empty;
    }
}
