using MediatR;

namespace ClaimsAutoProcessing.Api.Application.Commands;

public record StartAutoVettingCommandV2(int BatchId) : IRequest;