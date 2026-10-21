namespace WebApplication3.Services;

using WebApplication3.DTOs;

public interface ITeacherService
{
    Task<IEnumerable<TeacherDto>> GetAllTeachersAsync();
    Task<TeacherDto?> GetTeacherByIdAsync(long id);
    Task<TeacherDto> CreateTeacherAsync(TeacherDto dto);
    Task<TeacherDto?> UpdateTeacherAsync(long id, TeacherDto dto);
    Task<bool> DeleteTeacherAsync(long id);
}