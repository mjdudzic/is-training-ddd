using MediatR;

namespace ClaimsAutoProcessing.Api.Application.Commands;

public record SyncBatchCommand() : IRequest<int>;