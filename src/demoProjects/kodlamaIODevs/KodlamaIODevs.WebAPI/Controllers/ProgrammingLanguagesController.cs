using KodlamaIODevs.Application.Features.ProgrammingLanguages.Commands.Create;
using KodlamaIODevs.Application.Features.ProgrammingLanguages.Commands.Delete;
using KodlamaIODevs.Application.Features.ProgrammingLanguages.Commands.Update;
using KodlamaIODevs.Application.Features.ProgrammingLanguages.Queries.GetById;
using KodlamaIODevs.Application.Features.ProgrammingLanguages.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaIODevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {
        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            var createProgrammingLanguageDto = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", createProgrammingLanguageDto);
        }
        [HttpPut("")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            var updateProgrammingLanguageDto = await Mediator.Send(updateProgrammingLanguageCommand);
            return Created("", updateProgrammingLanguageDto);
        }
        [HttpDelete("")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            var delteProgrammingLanguageDto = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Created("", delteProgrammingLanguageDto);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetList([FromQuery] GetProgrammingLanguageListQuery getProgrammingLanguageListQuery)
        {
            var result = await Mediator.Send(getProgrammingLanguageListQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBrandById([FromRoute] GetProgrammingLanguageByIdQuery getProgrammingLanguageByIdQuery)
        {
            var result = await Mediator.Send(getProgrammingLanguageByIdQuery);
            return Ok(result);
        }
    }
}
