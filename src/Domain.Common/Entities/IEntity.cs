using Domain.Common.ValueObjects;

namespace Domain.Common.Entities
{
    /// <summary>Доменная сущность</summary>
    /// <typeparam name="T">Тип сущности</typeparam>
    public interface IEntity<T>
    {
        /// <summary>Идентификатор сущности</summary>
        public EntityId<T> Id { get; }
    }
}