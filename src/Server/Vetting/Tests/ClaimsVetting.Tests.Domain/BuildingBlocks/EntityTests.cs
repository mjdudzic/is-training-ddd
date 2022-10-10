using ClaimsVetting.Domain.SeedWork;
using FluentAssertions;

namespace ClaimsVetting.Tests.Domain.BuildingBlocks
{
    public class EntityTests
    {
        [Fact]
        public void entities_with_different_id_are_not_equal()
        {
            var entity1 = new TestEntity(1, "test1");
            var entity2 = new TestEntity(2, "test1");

            entity1.Should().NotBeEquivalentTo(entity2);
        }

        [Fact]
        public void entities_with_the_same_id_are_equal()
        {
            var entity1 = new TestEntity(1, "test1");
            var entity2 = new TestEntity(1, "test2");

            entity1.Should().BeEquivalentTo(entity2);
        }

        [Fact]
        public void entities_with_ids_not_set_are_not_equal()
        {
            var entity1 = new TestEntity(default, "test1");
            var entity2 = new TestEntity(default, "test2");

            entity1.Should().NotBeEquivalentTo(entity2);
        }
    }

    public class TestEntity : Entity<int>
    {
        public string Name { get; }

        public TestEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}