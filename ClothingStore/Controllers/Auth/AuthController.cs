using ClothingStore.Auth;
using ClothingStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ClothingStore.Controllers.Auth
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class AuthController : ControllerBase
    //{
    //    private readonly SignInManager<MyIdentityUser> _signInManager;


    //    public AuthController(SignInManager<MyIdentityUser> signInManager)
    //    {
    //        _signInManager = signInManager;
    //    }


    //    [HttpPost]

    //    public async Task<IActionResult> OnPostAsync()
    //    {
    //        IFormCollection nvc = Request.Form;
    //        string userEmail, userPassword;
    //        if (!string.IsNullOrEmpty(nvc["email"]))
    //        {
    //            userEmail = nvc["email"];
    //        }
    //        else
    //        {
    //            var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Email!!!" };
    //            throw new HttpResponseException(msg);
    //        }

    //        if (!string.IsNullOrEmpty(nvc["password"]))
    //        {
    //            userPassword = nvc["password"];
    //        }
    //        else
    //        {
    //            var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Password!!!" };
    //            throw new HttpResponseException(msg);
    //        }
    //        var ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

    //        if (ModelState.IsValid)
    //        {
    //            // This doesn't count login failures towards account lockout
    //            // To enable password failures to trigger account lockout, set lockoutOnFailure: true
    //            var result = await _signInManager.PasswordSignInAsync(userEmail, userPassword, true, lockoutOnFailure: false);
    //            if (result.Succeeded)
    //            {
    //                var claims = new List<Claim> { new Claim(ClaimTypes.Name, userEmail) };
    //                // создаем JWT-токен
    //                var jwt = new JwtSecurityToken(
    //                        issuer: AuthOptions.ISSUER,
    //                        audience: AuthOptions.AUDIENCE,
    //                        claims: claims,
    //                        expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
    //                        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

    //                return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
    //            }
    //            if (result.IsLockedOut)
    //            {
    //                var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "User Locked!!!" };
    //                throw new HttpResponseException(msg);
    //            }
    //            else
    //            {
    //                var msg = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "User not found!!!" };
    //                throw new HttpResponseException(msg);
    //            }
    //        }
    //        return BadRequest();
    //    }
    //}
}
