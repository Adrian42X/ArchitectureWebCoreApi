using System.ComponentModel.DataAnnotations;

namespace ArchitectureWebCoreApi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="UserName Required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage ="Password Required")]
        public string Password { get; set; }
    }
}
