using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discway.Data.Dto;

[Table("League")]
public class League
{
    [Key]
    [Column("Id", TypeName = "uniqueidentifier")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [Column("UserId", TypeName = "nvarchar(450)")] // Specified 450 because of Identity defaults
    public string AdminId { get; set; } // The owner of the league 

    [Required]
    [Column("Course", TypeName = "nvarchar(300)")]
    [MaxLength(300)]
    public string Course { get; set; }

    [Required]
    [Column("TotalPlayers", TypeName = "int")]
    public int TotalPlayers { get; set; }
}