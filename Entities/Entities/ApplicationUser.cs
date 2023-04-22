using Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
        #region Attributes

        [Column("USR_CPF")]
        public string CPF { get; set; }

        [Column("USR_RANK")]
        public UserCategory? Rank { get; set; }

        #endregion
    }
}
