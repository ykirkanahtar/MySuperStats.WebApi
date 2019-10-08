using System;

namespace MySuperStats.Contracts.Requests
{
    public class UpdatePlayerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }    
}