using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_BusinessObjects
{
    public class User : IdentityUser
    {
        public string? Name { get; set; }
        public string? Picture { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; } = true;

    }
}
