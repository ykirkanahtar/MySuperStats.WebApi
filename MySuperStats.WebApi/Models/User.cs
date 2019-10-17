using System;
using System.Collections.Generic;
using CustomFramework.WebApiUtils.Identity.Models;

namespace MySuperStats.WebApi.Models
{
    public class User : CustomUser
    {
        public string TempFirstName { get; set; } //Kullanıcı e-postasını onaylayıp, player verisi oluştuktan sonra buradaki veriler silinecek
        public string TempLastName { get; set; }
        public DateTime? TempBirthDate { get; set; }
        public virtual Player Player { get; set; }
        public virtual ICollection<MatchGroupUser> MatchGroupUsers { get; set; }

    }
}