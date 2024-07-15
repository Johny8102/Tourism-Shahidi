using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Final_project_2.Models;
using EmailVerification.Services;
using EmailVerification.Models;
using Final_project_2.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Linq;
using System;
using System.Security.Cryptography;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using static System.Net.WebRequestMethods;
using Final_project_2.Services;




namespace Final_project_2.Controllers
{
    [Route("/Access/[action]")]
    
    public class AccessController : Controller
    {
        //private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailServices _emailServices;
        private readonly ITourismRepository<Person> _personRepo;
        private readonly IConfiguration _configuration;
        private readonly TourismDbcontext _context;
        private const string SecretKey = "thisismykeythisismykeythisismykeythisismykeythisismykeythisismykeythisismykeythisismykey";
        private readonly TokenServices _tokenServices;
        public AccessController(IEmailServices emailServices, ITourismRepository<Person> PersonRepo, IConfiguration configuration
             , TourismDbcontext context , TokenServices tokenServices )
        {
            _emailServices = emailServices;
            _personRepo = PersonRepo;
            _configuration = configuration;
            _context = context;
            _tokenServices = tokenServices;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            var userExists = _context.Person.Any(i => i.Email == model.Email);
            if (userExists)
            {
                var user = _context.Person.FirstOrDefault(i => i.Email == model.Email);
                if (user == null || user.Password != model.Password) return RedirectToAction("login");
                HttpContext.Session.SetString("JWToken", _tokenServices.GetAuthenticationToken(model.Email));
                //GetAuthenticationToken(model.Email);
                return RedirectToAction("index", "home");

            }

            return RedirectToAction("login");
        }

        
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWToken");

            return RedirectToAction("login");
        }


        [AllowAnonymous]
        public IActionResult register()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> register(Person person)
        {
            var userExist = _personRepo.GetAll().Any(o=>o.Email ==person.Email);

            //if (userExist) return RedirectToAction(nameof(Login));
            await _personRepo.Create(person);
            var user = _personRepo.GetAll().FirstOrDefault(o => o.Email == person.Email);
            if (user!=null)
            {
                var token = _tokenServices.GetAuthenticationToken(person.Email);
                
                //var token = await _userManager.GenerateEmailConfirmationTokenAsync(userIdentity);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Access", new { token, email = person.Email });
                var Message = new Message(new string[] { person.Email! }, "# Confirm your email #", $"Please confirm your account by clicking <a href=\"{"https://localhost:7047" + confirmationLink}\">here</a>." );
                _emailServices.SendEmail(Message);
                ///*"https://localhost:7047" +  confirmationLink!*
                return RedirectToAction("Index","Home");
            }

            return Unauthorized();

        }


        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var user = _personRepo.GetAll().FirstOrDefault(o => o.Email == email);
            var principal = _tokenServices.ValidateToken(token);
            if (principal == null)
                return BadRequest("Invalid token");

            //var emailadd = principal.FindFirst(ClaimTypes.Email)?.Value;
            //if (emailadd == null)
            //    return BadRequest("Invalid token");

            //if (user != null)
            //{
            //    string expectedToken = user.Email + token;
                
            //    if (expectedToken!=null)
            //    {
            return RedirectToAction("Index", "Home");
            //    }
            //}


            //var result = await _perosnRepository.

            return NotFound();

        }


        //public string GenerateEmailConfirmationToken(string email)
        //{
        //    string token;
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        byte[] tokenData = new byte[32];
        //        rng.GetBytes(tokenData);

        //        // Concatenate email with random bytes to make the token unique per email
        //        byte[] emailBytes = Encoding.UTF8.GetBytes(email);
        //        byte[] combinedBytes = new byte[tokenData.Length + emailBytes.Length];
        //        Array.Copy(tokenData, combinedBytes, tokenData.Length);
        //        Array.Copy(emailBytes, 0, combinedBytes, tokenData.Length, emailBytes.Length);

        //        token = Convert.ToBase64String(combinedBytes);
        //    }
        //    return token;
        //}

        //private void GetAuthenticationToken(string Email)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(SecretKey);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, Email)
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    var tokenString = tokenHandler.WriteToken(token);

        //    HttpContext.Session.SetString("JWToken", tokenString);

        //} 


    }
}
