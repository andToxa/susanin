using Domain.Common.Entities;
using Domain.Common.ValueObjects;
using Xunit;

namespace Domain.Common.Tests.Entities
{
    /// <summary>Тесты <see cref="IEntity{T}"/></summary>
    public class EntityTests
    {
        /// <summary>
        /// test
        /// </summary>
        [Fact]
        public void Test1()
        {
            var entityOne = new TestEntity(EntityId<TestEntity>.New());
            var entityTwo = new TestEntity(EntityId<TestEntity>.New());
            Assert.NotEqual(entityOne.Id, entityTwo.Id);
        }
    }
}