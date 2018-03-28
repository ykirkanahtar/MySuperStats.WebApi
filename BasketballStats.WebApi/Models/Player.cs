using System;
using System.Collections.Generic;
using BasketballStats.WebApi.Data;
using Newtonsoft.Json;

namespace BasketballStats.WebApi.Models
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

        [JsonIgnore]
        public IList<Stat> Stats { get; set; }
    }
}
