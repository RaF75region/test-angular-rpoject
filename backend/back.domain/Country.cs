using System.ComponentModel.DataAnnotations;
using back.domain.Interfaces;

namespace back.domain;

public record Country
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public IEnumerable<Province>? Provincies { get; set; }
};