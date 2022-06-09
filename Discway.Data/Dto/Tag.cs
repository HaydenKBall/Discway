using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Discway.Data.Dto;

[Table("Tag")]
public class Tag
{
    [Key]
    [Column("Id", TypeName = "uniqueidentifier")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [Column("QrCode", TypeName = "nvarchar(max)")]
    public string QrCode { get; set; }

    [Required]
    [Column("CreatedDate", TypeName = "datetime2")]
    public DateTime CreatedDate { get; set; }
}