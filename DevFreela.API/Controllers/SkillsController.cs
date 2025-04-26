using DevFreela.Application.Models;
using DevFreela.Application.Services;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _service;
        public SkillsController(ISkillService service)
        {
            _service = service;
        }

        // GET api/skills
        [HttpGet]
        public IActionResult GetAll(string search = "", int page = 0, int size = 3)
        {
            var model = _service.GetAll(search, page, size);
            return Ok(model);
        }

        // POST api/skills
        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model)
        {
            var result = _service.Insert(model);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
