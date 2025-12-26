using FluentValidation;
using StudentManagementAPI.Models.DTOs;

namespace StudentManagementAPI.Validators
{
    public class StudentDTOValidator : AbstractValidator<StudentDTO>
    {
        public StudentDTOValidator()
        {
            RuleFor(s => s.FirstName)
                .NotEmpty().WithMessage("First name is required");

            RuleFor(s => s.LastName)
                .NotEmpty().WithMessage("Last name is required");

            RuleFor(s => s.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(s => s.Age)
                .GreaterThanOrEqualTo(16).WithMessage("Age must be >= 16")
                .LessThanOrEqualTo(120).WithMessage("Age must be <= 120");
        }
    }
}