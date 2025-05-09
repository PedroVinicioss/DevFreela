﻿using DevFreela.Application.Commands.InsertSkills;
using DevFreela.Application.Queries.GetAllSkills;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/skills
        [HttpGet]
        public async Task<IActionResult> GetAll(string search = "", int page = 0, int size = 3)
        {
            var result = await _mediator.Send(new GetAllSkillsQuery(search, page, size));
            return Ok(result);
        }

        // POST api/skills
        [HttpPost]
        public async Task<IActionResult> Post(InsertSkillsCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }
    }
}
