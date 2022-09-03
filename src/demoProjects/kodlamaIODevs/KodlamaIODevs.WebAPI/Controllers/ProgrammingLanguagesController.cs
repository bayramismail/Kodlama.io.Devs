using KodlamaIODevs.Application.Features.ProgrammingLanguages.Commands.Create;
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
            var createdBrandDto = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", createdBrandDto);
        }
    }
}
