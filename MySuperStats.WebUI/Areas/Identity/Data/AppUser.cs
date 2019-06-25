using System;
using Microsoft.AspNetCore.Identity;

namespace MySuperStats.WebUI.Areas.Identity.Data
{
    public class AppUser : IdentityUser<int>
    {
        [PersonalData]
        public string FirstName { get; set; }

        [PersonalData]
        public string Surname { get; set; }

        [PersonalData]
        public DateTime BirthDate { get; set; }
    }
}