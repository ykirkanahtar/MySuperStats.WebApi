using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Requests
{
    public class Login
    {
        [Required(ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public string ClientApplicationCode { get; set; }

        [Required(ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        [DataType(DataType.Password)]
        public string ClientApplicationPassword { get; set; }

        [Required(ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "<field>{0}</field> <message>RequiredError</message>")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}