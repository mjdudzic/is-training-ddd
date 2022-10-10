using MediatR;

namespace ClaimsAutoProcessing.Application;

public record StartAutoVettingCommand(int BatchId) : IRequest;