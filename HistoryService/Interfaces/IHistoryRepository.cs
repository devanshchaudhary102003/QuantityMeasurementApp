using HistoryService.Models;

namespace HistoryService.Interfaces
{
    public interface IHistoryRepository
    {
        void SaveToDatabase(QuantityMeasurementEntity quantity);
        IEnumerable<QuantityMeasurementEntity> GetMyDatabase(int userId);
        void DeleteHistory(int userId);
        IEnumerable<QuantityMeasurementEntity> GetHistoryByOperation(int userId, string operationType);
        IEnumerable<QuantityMeasurementEntity> GetHistoryByType(int userId, string measurementType);
        object GetStats(int userId);
    }
}
