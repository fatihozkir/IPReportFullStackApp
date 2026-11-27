using SharedKernel.Core.Base;
using SharedKernel.Core.Base.Abilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IPReport.Core.Entities.IPForensicsReports
{
    /// <summary>
    /// Database entity for IPR$IPForensicsReports table entries
    /// </summary>
    [Table("IPR$IPForensicsReports")]
    public class IPForensicsReport : EntityBase<string>, IHasCreationDate
    {
        /// <summary>
        /// Stores the foreign key of the issued AppUser
        /// </summary>
        [Required]
        public required long AppUser_FK { get; set; }

        /// <summary>
        /// Brings the details of the the linked AppUser
        /// </summary>
        [ForeignKey(nameof(AppUser_FK))]
        public virtual AppUser? AppUser { get; set; }

        /// <summary>
        /// Stores the IPAddress information
        /// </summary>
        [Required]
        [MaxLength(45)]
        public required string IPAddress { get; set; }

        /// <summary>
        /// Stores the Abuse Confidence Score information
        /// </summary>
        [Required]
        [Range(0, 100)]
        public required byte AbuseConfidenceScore { get; set; }

        /// <summary>
        /// Stores the sum of how far back in time we go to fetch reports
        /// </summary>
        [Required]
        public required long TotalReports { get; set; }

        /// <summary>
        /// Stores the when was the last report generation date
        /// </summary>
        [Required]
        public required DateTime? LastReportedDate { get; set; }

        /// <summary>
        /// Stores the issued continent information
        /// </summary>
        [Required]
        [MaxLength(20)]
        public required string Continent { get; set; }

        /// <summary>
        /// Stores the issued country information
        /// </summary>
        [Required]
        [MaxLength(60)]
        public required string Country { get; set; }

        /// <summary>
        /// Stores the issued region information
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string Region { get; set; }

        /// <summary>
        /// Stores the issued city information
        /// </summary>
        [Required]
        [MaxLength(100)]
        public required string City { get; set; }

        /// <summary>
        /// Stores the Creation Date of the report. By default <b>DateTime.UtcNow</b>
        /// </summary>
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Stores the IsHosting information. By default <b>false</b>
        /// </summary>
        [Required]
        public bool IsHosting { get; set; } = false;

        /// <summary>
        /// Stores the IsMobile information. By default <b>false</b>
        /// </summary>
        [Required]
        public bool IsMobile { get; set; } = false;

        /// <summary>
        /// Stores the IsProxy information. By default <b>false</b>
        /// </summary>
        [Required]
        public bool IsProxy { get; set; } = false;

        /// <summary>
        /// Stores the IsTor information. By default <b>false</b>
        /// </summary>
        [Required]
        public bool IsTor { get; set; } = false;


    }
}
