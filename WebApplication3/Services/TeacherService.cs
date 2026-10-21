namespace WebApplication3.Services;

using WebApplication3.DTOs;
using WebApplication3.Models;
using WebApplication3.Repositories;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;

    public TeacherService(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TeacherDto>> GetAllTeachersAsync()
    {
        var teachers = await _repository.GetAllAsync();
        return teachers.Select(t => new TeacherDto
        {
            Id = t.Id, FirstName = t.FirstName, LastName = t.LastName,
            Email = t.Email, Subject = t.Subject, HireDate = t.HireDate
        });
    }

    public async Task<TeacherDto?> GetTeacherByIdAsync(long id)
    {
        var teacher = await _repository.GetByIdAsync(id);
        if (teacher == null) return null;

        return new TeacherDto
        {
            Id = teacher.Id, FirstName = teacher.FirstName, LastName = teacher.LastName,
            Email = teacher.Email, Subject = teacher.Subject, HireDate = teacher.HireDate
        };
    }

    public async Task<TeacherDto> CreateTeacherAsync(TeacherDto dto)
    {
        var teacher = new Teacher
        {
            FirstName = dto.FirstName, LastName = dto.LastName,
            Email = dto.Email, Subject = dto.Subject, HireDate = dto.HireDate
        };

        var created = await _repository.AddAsync(teacher);

        dto.Id = created.Id;
        return dto;
    }

    public async Task<TeacherDto?> UpdateTeacherAsync(long id, TeacherDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null) return null;

        existing.FirstName = dto.FirstName;
        existing.LastName = dto.LastName;
        existing.Email = dto.Email;
        existing.Subject = dto.Subject;
        existing.HireDate = dto.HireDate;

        await _repository.UpdateAsync(existing);
        
        dto.Id = id;
        return dto;
    }

    public async Task<bool> DeleteTeacherAsync(long id)
    {
        var teacher = await _repository.GetByIdAsync(id);
        if (teacher == null) return false;

        await _repository.DeleteAsync(teacher);
        return true;
    }
}