using Application.DTOs.Tasks;
using Application.Interfaces.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController: ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService ;
    }

    [HttpGet("getByActivity/{activityId}")]
    public async Task<IActionResult> GetAllByActivity(int activityId)
    {
        var tasks = await _taskService.GetAllByActivityAsync(activityId);
        return tasks is null ? NotFound($"No existe la actividad con id {activityId} por la que se desea filtrar") : Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TaskRequestDTO dto)
    {
        if (dto is null)
            return BadRequest("Los datos de la tarea son requeridos");

        var createdTask = await _taskService.CreateAsync(dto);
        return CreatedAtAction(nameof(Create), new { id = createdTask.Id }, createdTask);
    }
}