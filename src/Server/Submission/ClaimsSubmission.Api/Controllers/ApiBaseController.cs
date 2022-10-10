﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsSubmission.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public abstract class ApiBaseController : ControllerBase
	{
		private IMediator _mediator;

		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
	}
}
