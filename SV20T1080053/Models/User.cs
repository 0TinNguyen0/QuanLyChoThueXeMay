using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SV20T1080053.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
