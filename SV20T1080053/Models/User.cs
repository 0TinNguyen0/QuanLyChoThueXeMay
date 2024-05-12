using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SV20T1080053.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
