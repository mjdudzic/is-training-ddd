using ClaimsVetting.Domain.AggregateModels.ClaimAggregate;
using ClaimsVetting.Domain.SharedKernel;
using NSubstitute;
using FluentAssertions;

namespace ClaimsVetting.Tests.Domain.ClaimTests;

public class VettingStatusTests
{
    private Claim _claim = new();

    [Fact]
    public void vetting_status_as_enum()
    {
        // Arrange
        _claim._status = VettingStatus.Accepted;

        // Act
        _claim._status = (VettingStatus)10;

        // Assert
        _claim._status.ToString().Should().Be("10");
    }

    [Fact]
    public void vetting_status_as_enumeration_class()
    {
        // Arrange
        _claim._vettingResult = VettingResult.Accepted;

        // Act
        _claim._vettingResult = (VettingResult)10;

        // Assert
        _claim._vettingResult.ToString().Should().Be("10");
    }
}