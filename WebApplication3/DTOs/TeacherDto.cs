namespace WebApplication3.DTOs;

using System.ComponentModel.DataAnnotations;

public class TeacherDto
{
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Subject { get; set; } = string.Empty;

    public DateTime HireDate { get; set; }
}