using System.ComponentModel.DataAnnotations;

namespace ArchitectureWebCoreApi.Models
{
    public class NewUserModel
    {
        [Required(ErrorMessage = "UserName Required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Mail Required")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "FirstName Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName Required")]
        public string LastName { get; set; }

    }
}
