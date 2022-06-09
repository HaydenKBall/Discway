using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discway.Data.Dto;

[Table("UserLeague")]
public class UserLeague
{
    [Key]
    [Column("Id", TypeName = "uniqueidentifier")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [Column("UserId", TypeName = "nvarchar(450)")] // Specified 450 because of Identity defaults
    public string UserId { get; set; } // The owner of the league 

    [Required]
    [Column("LeagueId", TypeName = "uniqueidentifier")]
    public Guid LeagueId { get; set; }

    [ForeignKey("LeagueId")]
    public League League { get; set; }
}