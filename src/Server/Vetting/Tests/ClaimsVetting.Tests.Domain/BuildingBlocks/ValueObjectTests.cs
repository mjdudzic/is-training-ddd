using ClaimsVetting.Domain.SeedWork;
using FluentAssertions;

namespace ClaimsVetting.Tests.Domain.BuildingBlocks
{
    public class ValueObjectTests
    {
        [Fact]
        public void using_vo_base_class_equality_gives_valid_result()
        {
            var price1 = new PriceAsVo(100, "PLN");
            var price2 = new PriceAsVo(100, "PLN");
            var price3 = new PriceAsVo(101, "PLN");

            price1.Should().BeEquivalentTo(price2);
            price1.Should().NotBeEquivalentTo(price3);
        }

        [Fact]
        public void using_record_base_class_equality_gives_valid_result()
        {
            var price1 = new PriceAsRecord(100, "PLN");
            var price2 = new PriceAsRecord(100, "PLN");
            var price3 = new PriceAsRecord(101, "PLN");

            price1.Should().BeEquivalentTo(price2);
            price1.Should().NotBeEquivalentTo(price3);
        }
    }

    public class PriceAsVo : ValueObject
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public PriceAsVo(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        protected override IEnumerable<object?> GetAtomicValues()
        {
            yield return Amount;
            yield return Currency;
        }
    }

    public record PriceAsRecord(decimal Amount, string Currency);
}