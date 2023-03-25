using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using University_CRM.Application.Features.Collages.AddCollage;
using University_CRM.Application.Features.Collages.Queries.GetCollage;

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
    }
}
