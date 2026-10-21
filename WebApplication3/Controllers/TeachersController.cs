namespace WebApplication3.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebApplication3.DTOs;
using WebApplication3.Services;

[ApiController]
[Route("api/[controller]")]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeachersController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeacherDto>>> GetAll()
    {
        return Ok(await _teacherService.GetAllTeachersAsync());
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<TeacherDto>> GetById(long id)
    {
        var teacher = await _teacherService.GetTeacherByIdAsync(id);
        return teacher != null ? Ok(teacher) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<TeacherDto>> Create([FromBody] TeacherDto dto)
    {
        var created = await _teacherService.CreateTeacherAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<TeacherDto>> Update(long id, [FromBody] TeacherDto dto)
    {
        var updated = await _teacherService.UpdateTeacherAsync(id, dto);
        return updated != null ? Ok(updated) : NotFound();
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete(long id)
    {
        return await _teacherService.DeleteTeacherAsync(id) ? NoContent() : NotFound();
    }
}