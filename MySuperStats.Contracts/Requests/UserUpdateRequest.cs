using System;

namespace MySuperStats.Contracts.Requests
{
    public class UserUpdateRequest
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}