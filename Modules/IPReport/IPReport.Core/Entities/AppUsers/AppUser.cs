using SharedKernel.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPReport.Core.Entities
{
    [Table("IPR$AppUsers")]
    public class AppUser : EntityBase<long>
    {
        [Required]
        [MaxLength(100)]
        public required string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(254)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(500)]
        public required string PasswordHash { get; set; }

    }
}
