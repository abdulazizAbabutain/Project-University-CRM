using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using University_CRM.Application.Common.Models.CollageModels;
using University_CRM.Application.Features.Collages.Command.AddCollage;
using University_CRM.Application.Features.Collages.Command.PartialCollageUpdate;
using University_CRM.Application.Features.Collages.Queries.GetCollage;
using University_CRM.Application.Features.Collages.Queries.GetCollageList;

namespace University_CRM.API.Controllers
{

    public class CollageController : BaseController
    {
       [HttpPost]
       public async Task<IActionResult> AddCollage(AddCollageCommand command)
        {
            var collage = await Mediator.Send(command);
            return CreatedAtAction(nameof(GetCollage),new { id = collage.Id } ,collage);
        }
        [HttpGet("{id}", Name = nameof(GetCollage))]
        public async Task<IActionResult> GetCollage(int id)
        {
            var result = await Mediator.Send(new GetCollageQuery { Id = id});
            if(result is null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet(Name = nameof(GetCollageList))]
        public async Task<IActionResult> GetCollageList([FromQuery] GetCollageListQuery query)
        {
            var result = await Mediator.Send(query);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(result.metaData));
            return Ok(result.collages);
        }
        [HttpPatch("{id}", Name = nameof(PartialCollageUpdate))]
        public async Task<IActionResult> PartialCollageUpdate([FromRoute] int id,[FromBody] JsonPatchDocument<ParialCollageUpdateDto> patch)
        {
            await Mediator.Send(new PartialCollageUpdateCommand { Id= id, PatchDoc = patch});
            return Ok();
        }
    }
}
