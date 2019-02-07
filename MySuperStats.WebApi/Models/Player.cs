using CustomFramework.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MySuperStats.WebApi.Models
{
    public class Player : BaseModel<int>
    {
        private DateTime _birthDate;
        public string Name { get; set; }
        public string Surname { get; set; }
      
        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = value.Date;
        }

        public virtual ICollection<Stat> Stats { get; set; }
    }
}
