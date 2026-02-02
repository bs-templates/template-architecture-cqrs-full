using BAYSOFT.Abstractions.Core.Application;
using BAYSOFT.Abstractions.Crosscutting.Helpers;
using BAYSOFT.Core.Application.Default.Aggregates.Samples.Notifications;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Entities;
using BAYSOFT.Core.Domain.Default.Aggregates.Samples.Services;
using BAYSOFT.Core.Domain.Default.Interfaces.Infrastructures.Data;
using MediatR;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using ModelWrapper;
using ModelWrapper.Extensions.Post;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BAYSOFT.Core.Application.Default.Aggregates.Samples.Commands
{
	public class PostSampleCommand : ApplicationRequest<Sample, PostSampleCommandResponse>
    {
        public PostSampleCommand()
        {
            ConfigKeys(x => x.Id);

            // Configures supressed properties & response properties
            //ConfigSuppressedProperties(x => x);
            //ConfigSuppressedResponseProperties(x => x);       
        }
    }
    public class PostSampleCommandResponse : ApplicationResponse<Sample>
    {
        public PostSampleCommandResponse(Tuple<int, int, WrapRequest<Sample>, Dictionary<string, object>, Dictionary<string, object>, string, long?> tuple) : base(tuple)
        {
        }

        public PostSampleCommandResponse(WrapRequest<Sample> request, object data, string message = "Successful operation!", long? resultCount = null)
            : base(request, data, message, resultCount)
        {
        }
    }
    public class PostSampleCommandHandler : ApplicationRequestHandler<Sample, PostSampleCommand, PostSampleCommandResponse>
    {
        private ILoggerFactory Logger { get; set; }
        private IMediator Mediator { get; set; }
        private IStringLocalizer Localizer { get; set; }
        private IDefaultDbContextWriter Writer { get; set; }
        public PostSampleCommandHandler(
            ILoggerFactory logger,
            IMediator mediator,
            IStringLocalizer<Sample> localizer,
            IDefaultDbContextWriter writer
        )
        {
            Logger = logger;
            Mediator = mediator;
            Localizer = localizer;
            Writer = writer;
        }
        public override async Task<PostSampleCommandResponse> Handle(PostSampleCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.IsValid(Localizer, true);

                var data = request.Post();

                await Mediator.Send(new CreateSampleServiceRequest(data));

                await Writer.CommitAsync(cancellationToken);

                await Mediator.Publish(new PostSampleNotification(data));

                return new PostSampleCommandResponse(request, data, Localizer["Successful operation!"], 1);
            }
            catch (Exception exception)
            {
                Logger.CreateLogger<PostSampleCommandHandler>().Log(LogLevel.Error, exception, exception.Message);

                return new PostSampleCommandResponse(ExceptionResponseHelper.CreateTuple(Localizer, request, exception));
            }
        }
    }
}
