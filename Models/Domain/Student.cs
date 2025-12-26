using System.ComponentModel.DataAnnotations;

namespace StudentManagementAPI.Models.Domain;

public class Student
{
    public int StudentId { get;  set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public DateTime CreatedAt { get; set; } =  DateTime.UtcNow;
}