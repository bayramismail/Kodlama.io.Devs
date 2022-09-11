using KodlamaIODevs.Application.Features.ProgrammingLanguageTechnologies.Commands.Create;
using KodlamaIODevs.Application.Features.ProgrammingLanguageTechnologies.Commands.Delete;
using KodlamaIODevs.Application.Features.ProgrammingLanguageTechnologies.Commands.Update;
using KodlamaIODevs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KodlamaIODevs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageTechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProgrammingLanguageTechnologyCommand createProgrammingLanguageTechnologyCommand)
        {
            var result = await Mediator.Send(createProgrammingLanguageTechnologyCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateProgrammingLanguageTechnologyCommand updateProgrammingLanguageTechnologyCommand)
        {
            var result = await Mediator.Send(updateProgrammingLanguageTechnologyCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProgrammingLanguageTechnologyCommand deleteProgrammingLanguageTechnologyCommand)
        {
            var result = await Mediator.Send(deleteProgrammingLanguageTechnologyCommand);
            return Created("", result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetProgrammingLanguageTechnologyListQuery getProgrammingLanguageTechnologyListQuery)
        {
            var result = await Mediator.Send(getProgrammingLanguageTechnologyListQuery);
            return Created("", result);
        }
    }
}
