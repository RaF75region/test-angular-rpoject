using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using back.domain.Interfaces;

namespace back.domain;

public record User
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }
    [Required]
    public bool isAgree { get; set; } = false;
    [Required]
    public Guid CountryId { get; set; }
    [JsonIgnore]
    public Country? Country { get; set; }
    [Required]
    public Guid ProvinceId { get; set; }
    [JsonIgnore]
    public Province? Province { get; set; }
};