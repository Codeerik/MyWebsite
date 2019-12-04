using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ErikVanDelft.Models
{

    // Temporary test database for login functionality.
    public class AuthenticationContext : IdentityDbContext
    {
        public DbSet<WebsiteUser> WebsiteUser { get; set; }

        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {

        }
    }

    /// <summary>
    /// A basic authenticated user.
    /// </summary>
    public class WebsiteUser : IdentityUser
    {
        /// <summary>
        /// The display name for a user.
        /// </summary>
        public string UserHandle { get; set; }
    }

    /// <summary>
    /// The ViewModel for logging in.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// The username for logging in.
        /// </summary>
        [Required]
        [Display(Name = "Gebruikersnaam *")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "De gebruikersnaam moet minimaal 6 karakters bevatten")]
        public string UserName { get; set; }

        /// <summary>
        /// The password for logging in.
        /// </summary>
        [Required]
        [Display(Name = "Wachtwoord *")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Het wachtwoord moet minimaal 10 karakters bevatten")]
        public string Password { get; set; }
    }

}
