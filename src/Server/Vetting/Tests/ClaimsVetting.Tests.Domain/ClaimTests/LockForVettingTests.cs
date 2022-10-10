using ClaimsVetting.Domain.AggregateModels.ClaimAggregate;
using ClaimsVetting.Domain.SharedKernel;
using NSubstitute;
using FluentAssertions;

namespace ClaimsVetting.Tests.Domain.ClaimTests;

public class LockForVettingTests
{
    private ICurrentDateTime _currentDateTime;
    private ICurrentUser _currentUser;

    private Claim _claim = new();
    private IRepository _repository;

    private void Act() => _claim.LockForVetting(_currentUser, _currentDateTime);

    public LockForVettingTests()
    {
        _currentDateTime = Substitute.For<ICurrentDateTime>();
        _currentDateTime.UtcNow.Returns(DateTime.UtcNow);

        _currentUser = Substitute.For<ICurrentUser>();
        _currentUser.UserId.Returns(Guid.NewGuid().ToString());

        _repository = Substitute.For<IRepository>();
        _repository.GetClaim(_claim.Id).Returns(_claim);
    }

    [Fact]
    public void if_claims_already_vetted_throws_exception()
    {
        // Arrange
        _claim._status = VettingStatus.Accepted;

        // Act
        var act = Act;

        // Assert
        act.Should().Throw<ClaimAggregateException>();
    }
}