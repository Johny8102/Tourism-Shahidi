namespace Final_project_2.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool KeepedLogedin { get; set; } = true;
    }
}
