using MediatR;
using Microsoft.AspNetCore.Mvc;
using University_CRM.Application.Features.Collages.AddCollage;

namespace University_CRM.API.Controllers
{
    
    public class CollageController : BaseController
    {
       [HttpPost]
       public async Task<IActionResult> AddCollage(AddCollageCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }
    }
}
