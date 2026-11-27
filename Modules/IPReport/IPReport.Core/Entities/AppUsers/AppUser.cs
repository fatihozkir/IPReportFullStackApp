using SharedKernel.Core.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPReport.Core.Entities
{
    /// <summary>
    ///  Database entity for IPR$AppUsers table entries
    /// </summary>
    [Table("IPR$AppUsers")]
    public class AppUser : EntityBase<long>
    {
        /// <summary>
        /// Stores the first name of the user
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string FirstName { get; set; }

        /// <summary>
        /// Stores the last name of the user
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string LastName { get; set; }

        /// <summary>
        /// Stores the email address of the user
        /// </summary>
        [Required]
        [EmailAddress]
        [MaxLength(254)]
        public required string Email { get; set; }

        /// <summary>
        /// Stores the hashed password of the user
        /// </summary>
        [Required]
        [MaxLength(500)]
        public required string PasswordHash { get; set; }

    }
}
