using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ErikVanDelft.Models;


namespace ErikVanDelft.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<WebsiteUser> _signInManager;         // Manages log-ins for WebsiteUsers.  
        // <summary>
        /// Responsible for user log-in, log-out and registration pages.
        /// </summary>
        /// <param name="signInManager">Manages log-ins for users.</param>
        /// <param name="userManager">Manages registered users.</param>
        public AccountController(SignInManager<WebsiteUser> signInManager)
        {
            _signInManager = signInManager;

        }
        // conditional redirect in case of user logging in
        /// <summary>
        /// Authenticates log-in attempts.
        /// </summary>
        /// <param name="model">The ViewModel containing the username and password to log-in with.</param>
        /// <returns>A message providing feedback to the user.</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to log in.
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);

                if (result.Succeeded)
                {
                    // Return success.
                    return Json(new { success = true, message = "&#10004; Inlog succesvol", action = Url.Action("Index", "Home") });

                }
                // Return failure.
                return Json(new { success = false, message = "&#10006; Inloggen mislukt" });
            }
            // Return failure.
            return Json(new { success = false, message = "&#10006; Inloggen mislukt" });
        }

    }
}