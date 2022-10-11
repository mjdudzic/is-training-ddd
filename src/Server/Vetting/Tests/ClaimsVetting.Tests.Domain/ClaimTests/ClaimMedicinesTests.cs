using ClaimsVetting.Domain.AggregateModels.ClaimAggregate;
using ClaimsVetting.Domain.SharedKernel;
using NSubstitute;
using FluentAssertions;

namespace ClaimsVetting.Tests.Domain.ClaimTests;

public class ClaimMedicinesTests
{
    private Claim _claim = new();

    [Fact]
    public void altering_entity_readonly_collection()
    {
        // Arrange
        _claim._medicines = new List<Medicine>
        {
            new Medicine
            {
                Code = "code",
                TotalPrice = new Price(10, "PLN")
            }
        };

        // Act
        //_claim.Medicines = new List<Medicine>();
        _claim.Medicines.Add(new Medicine());

        // Assert
        _claim.Medicines.Count.Should().Be(2);
    }
}