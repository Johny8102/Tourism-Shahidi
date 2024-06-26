using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Final_project_2.Models;




namespace Final_project_2.Controllers
{
    public class AccessController : Controller
    {
        public IActionResult Login()
        {
            ClaimsPrincipal claimsPrincipal = HttpContext.User;
            if(claimsPrincipal.Identity.IsAuthenticated )
            {
                return RedirectToAction("Index", "home");
            }


            return View();
        }



        [HttpPost]
        public IActionResult Login(VMLogin data)
        {
            //todo
            if(data.Email == "aa@gmail.com" && data.Password =="123" ) {
                List<Claim> claims = new List<Claim>() { new Claim(ClaimTypes.NameIdentifier , data.Email),
                    new Claim("AA " , "vv")
                
                };
                
                ClaimsIdentity identity = new ClaimsIdentity(claims , 
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = data.KeepedLogedin,
                };  

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme , new ClaimsPrincipal(identity), properties);


                return RedirectToAction("Index" , "Home");




            }


            ViewData["ValidateMessage"] = "NotFound";

            return View();
        }
    }
}
