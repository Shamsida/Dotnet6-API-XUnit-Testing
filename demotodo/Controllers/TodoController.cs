using demotodo.Model;
using demotodo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demotodo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [Route("getAll")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _todoService.GetAllAsync();
            if (result.Count == 0)
            {
                return NoContent();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveAsync(Todo newTodo)
        {
            Todo result = await _todoService.SaveAsync(newTodo);
            if(result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
