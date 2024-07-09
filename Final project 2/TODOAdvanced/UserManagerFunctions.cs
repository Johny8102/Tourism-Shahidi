using System;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace Final_project_2.TODOAdvanced
{
    public class UserManagerFunctions
    {

    }

    public class UserManager
    {
        private Dictionary<string, User> _tokenUserMapping = new Dictionary<string, User>();
        private Dictionary<string, DateTime> _tokenExpiration = new Dictionary<string, DateTime>();
        private const int TokenExpirationMinutes = 30;

        public async Task<bool> ConfirmEmailAsync(User user, string token)
        {
            // Check if the token is present in the mapping
            if (!_tokenUserMapping.TryGetValue(token, out var targetUser))
            {
                return false; // Token not found
            }

            // Ensure token is not expired
            if (_tokenExpiration.TryGetValue(token, out var expirationTime) && expirationTime < DateTime.Now)
            {
                // Token expired
                _tokenUserMapping.Remove(token);
                _tokenExpiration.Remove(token);
                return false;
            }

            // Verify if the token matches the user's email
            if (targetUser.Email == user.Email)
            {
                // Set the user's EmailConfirmed flag
                targetUser.EmailConfirmed = true;
                return true;
            }
            return false;
        }

        public string GenerateEmailConfirmationToken(User user)
        {
            // Generate a random token
            string token = Guid.NewGuid().ToString().Replace("-", "");
            _tokenUserMapping[token] = user;
            _tokenExpiration[token] = DateTime.Now.AddMinutes(TokenExpirationMinutes);
            return token;
        }
    }

    public class User
    {
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
    }

    public class EmailConfirmationService
    {
        private readonly UserManager _userManager;

        public EmailConfirmationService(UserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> ConfirmUserEmail(User user, string token)
        {
            return await _userManager.ConfirmEmailAsync(user, token);
        }
    }

    class Program
    {
        static async Task Main()
        {
            var userManager = new UserManager();
            var emailConfirmationService = new EmailConfirmationService(userManager);

            User user = new User { Email = "example@example.com", EmailConfirmed = false };

            string token = userManager.GenerateEmailConfirmationToken(user); // Generate token

            bool isEmailConfirmed = await emailConfirmationService.ConfirmUserEmail(user, token);

            if (isEmailConfirmed)
            {
                Console.WriteLine($"Email for {user.Email} has been confirmed successfully.");
            }
            else
            {
                Console.WriteLine($"Email confirmation failed for {user.Email}.");
            }
        }
    }
}
