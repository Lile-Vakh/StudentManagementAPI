using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementAPI.Data;
using StudentManagementAPI.Models.Domain;
using StudentManagementAPI.Models.DTOs;

namespace StudentManagementAPI.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
   private readonly AppDbContext _context;
   private readonly IMapper _mapper;

   public StudentsController(AppDbContext context, IMapper mapper)
   {
      _context = context;
      _mapper = mapper;
   }
   
   [HttpGet]
   public async Task<IActionResult> GetStudents([FromQuery] string? search = null, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
   {
      if (pageNumber < 1) pageNumber = 1;
      if (pageSize < 1) pageSize = 10;
      
      var query = _context.Students.AsQueryable();
      if (!string.IsNullOrEmpty(search))
      {
         search = search.ToLower();
         query = query.Where(s => s.FirstName.ToLower().Contains(search) 
                                  || s.LastName.ToLower().Contains(search));
      }
      
      var students = await query
         .OrderBy(s => s.StudentId)
         .Skip((pageNumber - 1) * pageSize)
         .Take(pageSize)
         .ToListAsync();
      
      var dtoList = _mapper.Map<List<StudentDTO>>(students);
      return Ok(dtoList);
   }

   [HttpGet("{id}")]
   public async Task<IActionResult> GetStudent(int id)
   {
      var student = await _context.Students.FindAsync(id);
      if (student == null) return NotFound();

      var dto = _mapper.Map<StudentDTO>(student);
      return Ok(dto);
   }

   [HttpPost]
   public async Task<IActionResult> CreateStudent(StudentDTO dto)
   {
      if (dto.Age < 16)
         return BadRequest("Age must be >= 16");

      if (await _context.Students.AnyAsync(s => s.Email == dto.Email))
         return BadRequest("Email already exists");

      var student = _mapper.Map<Student>(dto);
      student.CreatedAt = DateTime.UtcNow;

      _context.Students.Add(student);
      await _context.SaveChangesAsync();

      var resultDto = _mapper.Map<StudentDTO>(student);

      return CreatedAtAction(nameof(GetStudent), new { id = student.StudentId }, resultDto);
   }

   [HttpPut("{id}")]
   public async Task<IActionResult> UpdateStudent(int id, StudentDTO dto)
   {
      if (dto.Age < 16)
         return BadRequest("Age must be >= 16");

      var student = await _context.Students.FindAsync(id);
      if (student == null) return NotFound();

      if (await _context.Students.AnyAsync(s => s.Email == dto.Email && s.StudentId != id))
         return BadRequest("Email must be unique");

      _mapper.Map(dto, student);

      await _context.SaveChangesAsync();
      return NoContent();
   }

   [HttpDelete("{id}")]
   public async Task<IActionResult> DeleteStudent(int id)
   {
      var student = await _context.Students.FindAsync(id);
      if (student == null) return NotFound();
      
      _context.Students.Remove(student);
      await _context.SaveChangesAsync();
      return NoContent();
   }
}