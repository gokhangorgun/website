using System.ComponentModel.DataAnnotations;

namespace cinisatissitesi.Models
{
    public class AdminUser
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}