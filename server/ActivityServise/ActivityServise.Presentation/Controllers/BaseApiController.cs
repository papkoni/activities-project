using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace ActivityServise.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
    private IMediator? _mediator;

    protected IMediator Mediator =>
        _mediator ??= HttpContext.RequestServices.GetService<IMediator>()
                      ?? throw new InvalidOperationException("IMediator service is unavailable");

}