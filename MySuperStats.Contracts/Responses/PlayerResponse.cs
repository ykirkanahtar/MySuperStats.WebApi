using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace MySuperStats.Contracts.Responses

{
    public class PlayerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<StatResponse> Stats { get; set; }
    }
}
