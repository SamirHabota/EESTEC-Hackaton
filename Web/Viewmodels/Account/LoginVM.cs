using System.ComponentModel.DataAnnotations;

namespace Web.Viewmodels.Account
{
    public class LoginVM
    {
        [Required]
        public string Username {get; set;}
        [Required]
        public string Password {get; set;}
        public bool RememberMe {get; set;}
        public string Error {get; set;}
    }
}