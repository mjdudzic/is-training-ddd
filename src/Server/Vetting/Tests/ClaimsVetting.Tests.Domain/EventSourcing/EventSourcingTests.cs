using ClaimsVetting.Domain.AggregateModels.ClaimAggregate;
using ClaimsVetting.Domain.SharedKernel;
using FluentAssertions;
using NSubstitute;

namespace ClaimsVetting.Tests.Domain.EventSourcing;

public class EventSourcingTests
{
    private ICurrentDateTime _currentDateTime;
    private ICurrentUser _currentUser;

    private Claim _claim;
    private IRepository _repository;

    public EventSourcingTests()
    {
        _currentDateTime = Substitute.For<ICurrentDateTime>();
        _currentDateTime.UtcNow.Returns(DateTime.UtcNow);

        _currentUser = Substitute.For<ICurrentUser>();
        _currentUser.UserId.Returns("someone");

        _repository = new Repository();
    }

    [Fact]
    public async Task test()
    {
        // Arrange
        _claim = await _repository.GetClaim(new ClaimId(Guid.NewGuid()));
        _claim.LockForVetting(_currentUser, _currentDateTime);
        _claim.Accept(_currentUser, _currentDateTime);
        _repository.Save(_claim);

        // Act
        var claim = await _repository.GetClaim(_claim.Id);


        // Assert
        claim._lockedBy.Should().NotBeNullOrWhiteSpace();
        claim._status.Should().Be(VettingStatus.Accepted);
    }
}