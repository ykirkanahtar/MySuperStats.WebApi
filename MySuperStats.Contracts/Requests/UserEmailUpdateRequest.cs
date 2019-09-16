using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Requests
{
    public class UserEmailUpdateRequest
    {
        [EmailAddress]
        public string NewEmail { get; set; }
    }
}