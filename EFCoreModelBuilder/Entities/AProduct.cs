using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreModelBuilder.Entities;

[Index("Name", IsUnique = true)]
public class AProduct
{
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = "";

    [MaxLength(200)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }
}
