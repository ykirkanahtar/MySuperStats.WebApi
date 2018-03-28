using System;

namespace BasketballStats.WebApi.RequestModels

{
    public class PlayerRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
