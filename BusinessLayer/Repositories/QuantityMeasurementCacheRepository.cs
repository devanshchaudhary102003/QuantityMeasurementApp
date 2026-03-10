using BusinessLayer.Interfaces;
using ModelLayer.Models;

namespace BusinessLayer.Repositories
{
    /// <summary>
    /// Simple in-memory repository for UC15.
    /// </summary>
    public sealed class QuantityMeasurementCacheRepository : IQuantityMeasurementRepository
    {
        private static readonly Lazy<QuantityMeasurementCacheRepository> _instance =
            new(() => new QuantityMeasurementCacheRepository());

        private readonly List<QuantityMeasurementEntity> _entities;
        private readonly object _lock;

        private QuantityMeasurementCacheRepository()
        {
            _entities = new List<QuantityMeasurementEntity>();
            _lock = new object();
        }

        public static QuantityMeasurementCacheRepository Instance => _instance.Value;

        public void Save(QuantityMeasurementEntity entity)
        {
            lock (_lock)
            {
                _entities.Add(entity);
            }
        }

        public IReadOnlyList<QuantityMeasurementEntity> GetAll()
        {
            lock (_lock)
            {
                return _entities.ToList().AsReadOnly();
            }
        }
    }
}