using System.ComponentModel.DataAnnotations;
using back.domain.Interfaces;

namespace back.domain;

public class Province : IEntity
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public Guid? CountryId { get; set; }
    public Country? Country { get; set; }
}