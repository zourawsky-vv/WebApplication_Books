using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Books.Models
{
    public class User : IdentityUser
    {
        [Required, Display(Name = "Пользователь"), StringLength(256, MinimumLength = 3)]
        public string FirstName { get; set; }
    }
}
