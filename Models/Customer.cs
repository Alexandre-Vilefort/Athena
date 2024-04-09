using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Athena.Models;

[Table("customer")]
public class Customer : BaseEntity
{
    [Column("id")]
    public int Id { get; set; }

    [Column("email")]
    [Required(ErrorMessage = "email is required")]
    [MaxLength(100)]
    public required string Email { get; set; }

    [Column("name")]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Column("is_auth")]
    public bool IsAuth { get; set; }
}