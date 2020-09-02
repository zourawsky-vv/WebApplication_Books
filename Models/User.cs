﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Books.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
    }
}
