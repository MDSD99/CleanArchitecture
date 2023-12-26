using CleanArchitecture.App.Features.RoleFeatures.Commands;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation.Controllers
{
    public sealed class RoleController : ApiController
    {
        public RoleController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]

        public async Task<IActionResult> Create(CreoateRoleCommand request, CancellationToken cancellationToken)
        {
            MessageResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }








    }
}
