using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Progetto_S19_L5.Models.Auth
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public new required string UserId { get; set; }

        public new required string RoleId { get; set; }

        // navigazione
        [ForeignKey(nameof(UserId))]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey(nameof(RoleId))]
        public ApplicationRole ApplicationRole { get; set; }
    }
}
