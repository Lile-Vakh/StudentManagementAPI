using AutoMapper;
using StudentManagementAPI.Models.Domain;
using StudentManagementAPI.Models.DTOs;

namespace StudentManagementAPI.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<StudentDTO, Student>();
        CreateMap<Student, StudentDTO>();
    }
}