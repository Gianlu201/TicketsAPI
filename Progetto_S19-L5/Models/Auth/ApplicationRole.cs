using Microsoft.AspNetCore.Identity;

namespace Progetto_S19_L5.Models.Auth
{
    public class ApplicationRole : IdentityRole
    {
        // navigazione
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
