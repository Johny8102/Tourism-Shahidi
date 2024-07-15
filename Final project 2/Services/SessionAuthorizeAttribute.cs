using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Final_project_2.Models;
using Final_project_2.Repository;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Final_project_2.Services
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }

    public class AdminAuthorizationAttriute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            var userRepository = (ITourismRepository<Person>)context.HttpContext.RequestServices.GetService(typeof(ITourismRepository<Person>));

            var token = context.HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
            if (jwtToken==null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            //var Email = context.HttpContext.User.Identity.Name;
            var Email = jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name")?.Value;

            if (string.IsNullOrEmpty(Email) )
            {
                context.Result = new UnauthorizedResult();  
                return;
            }
            var user = userRepository.GetAll().FirstOrDefault(i => i.Email == Email);                   /*Person.FirstOrDefault(i => i.Username == userName);*/
            if (user==null && !user.Is_Admin)
            {
                context.Result = new ForbidResult();
                return;
            }

            base.OnActionExecuting(context);

        }
    }



}
