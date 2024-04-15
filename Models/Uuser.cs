using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace apiTest.Models
{
    public class Uuser
    {
        /// <summary>
        ///     dummy data for only the test perpose;
        ///     this user is used for authentication;
        /// </summary>
        public static List<Uuser> users = new List<Uuser>() { 
            new Uuser() {
                Id = 1,
                name = "amr",
                password = "akuUi743190Am#$%",
                age = 33,
                email = "amr@apiTest.com",
                city = "Cairo",
                country = "Egypt",
                phone = "+201003224545",
            },
        };   	

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
