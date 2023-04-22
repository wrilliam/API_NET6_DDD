using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_MESSAGE")]
    public class Message : Notification
    {
        [Column("MSN_ID")]
        public int Id { get; set; }

        [Column("MSN_TITLE")]
        [MaxLength(255)]
        public string Title { get; set; }

        [Column("MSN_ACTIVE")]
        public bool Active { get; set; }

        [Column("MSN_DATE_REGISTERED")]
        public DateTime DateRegistered { get; set; }

        [Column("MSN_DATE_UPDATED")]
        public DateTime DateUpdated { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 1)]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
