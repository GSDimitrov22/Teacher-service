namespace WebApplication3.Repositories;

using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

public class TeacherRepository : ITeacherRepository
{
    private readonly AppDbContext _context;

    public TeacherRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Teacher>> GetAllAsync() => await _context.Teachers.ToListAsync();

    public async Task<Teacher?> GetByIdAsync(long id) => await _context.Teachers.FindAsync(id);

    public async Task<Teacher> AddAsync(Teacher teacher)
    {
        await _context.Teachers.AddAsync(teacher);
        await _context.SaveChangesAsync();
        return teacher;
    }

    public async Task UpdateAsync(Teacher teacher)
    {
        _context.Teachers.Update(teacher);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Teacher teacher)
    {
        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();
    }
}