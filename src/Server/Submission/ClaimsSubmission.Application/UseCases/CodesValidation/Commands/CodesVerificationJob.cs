using ClaimsSubmission.Application.UseCases.Common;
using MediatR;

namespace ClaimsSubmission.Application.UseCases.CodesValidation.Commands;

public class CodesVerificationJob : JobBase<ValidateCodesCommand>
{
    public CodesVerificationJob(IMediator mediator) : base(mediator)
    {
    }
}