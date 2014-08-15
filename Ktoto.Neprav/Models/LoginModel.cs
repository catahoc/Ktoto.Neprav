namespace Ktoto.Neprav.Models
{
    public class LoginModel
    {
        public string User { get; set; } 
        public string Password { get; set; }
        public string BackUrl { get; set; }
    }

    public class LogoutModel
    {
        public string BackUrl { get; set; }
    }
}