﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Users.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public List<Role> Roles { get; set; }
    }
}
