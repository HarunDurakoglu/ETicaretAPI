using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Domain.Entities
{
    public class User : IdentityUser<string>
    {
        public string NameSurname { get; set; }
    }
}
