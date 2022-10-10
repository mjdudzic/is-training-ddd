using MediatR;

namespace ClaimsAutoProcessing.Api.Application.Commands;

public record StartAutoVettingCommand(int BatchId) : IRequest;