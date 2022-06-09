using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Discway.Data.Dto
{
    public class User : IdentityUser
    {
        [PersonalData]
        [Display(Name = "First Name")]
        [Column("FirstName", TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        public string? FirstName { get; set; }

        [PersonalData]
        [Display(Name = "Last Name")]
        [Column("LastName", TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        public string? LastName { get; set; }

        [PersonalData]
        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        [PersonalData]
        [Display(Name = "About Me")]
        [Column("About", TypeName = "nvarchar(300)")]
        [MaxLength(300)]
        public string? About { get; set; }

        [PersonalData]
        [Display(Name = "PDGA Number")]
        [Column("PdgaNum", TypeName = "int")]
        [MaxLength(10)]
        public int? PdgaNum { get; set; }

        [PersonalData]
        [Display(Name = "UDisc User Name")]
        [Column("UDiscUserName", TypeName = "nvarchar(15)")]
        [MaxLength(15)]
        public string? UDiscUserName { get; set; }


        [Display(Name = "Global Rank")]
        [Column("Global Rank", TypeName = "nvarchar(15)")]
        [MaxLength(15)]
        public int? GlobalRank { get; set; }

        [Required]
        [Column("TagId", TypeName = "uniqueidentifier")]
        public Guid TagId { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
