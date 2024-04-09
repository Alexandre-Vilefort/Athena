using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Athena.Models;

public abstract class BaseEntity
 {
    [Column("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Column("udpated_at")]
    public DateTime? UpdatedAt { get; set; }
 }