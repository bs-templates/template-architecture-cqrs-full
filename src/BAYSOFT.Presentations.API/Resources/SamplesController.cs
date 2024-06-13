﻿using BAYSOFT.Core.Application.Default.Aggregates.Samples.Commands;
using BAYSOFT.Core.Application.Default.Aggregates.Samples.Queries;
using BAYSOFT.Presentations.API.Abstractions.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BAYSOFT.Presentations.API.Resources
{
	public class SamplesController : ResourceController
	{
		[HttpGet]
		public async Task<ActionResult<GetSamplesByFilterQueryResponse>> Get(GetSamplesByFilterQuery request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Send(request, cancellationToken);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GetSampleByIdQueryResponse>> Get(GetSampleByIdQuery request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Send(request, cancellationToken);
		}

		[HttpPost]
		public async Task<ActionResult<PostSampleCommandResponse>> Post(PostSampleCommand request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Send(request, cancellationToken);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<PutSampleCommandResponse>> Put(PutSampleCommand request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Send(request, cancellationToken);
		}

		[HttpPatch("{id}")]
		public async Task<ActionResult<PatchSampleCommandResponse>> Patch(PatchSampleCommand request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Send(request, cancellationToken);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<DeleteSampleCommandResponse>> Delete(DeleteSampleCommand request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Send(request, cancellationToken);
		}
	}
}