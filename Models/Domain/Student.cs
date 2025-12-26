using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models.Domain;

public class Student
{
    public int StudentId { get;  set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    
    [Range(16, 120)]
    public int Age { get; set; }
    public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;
}