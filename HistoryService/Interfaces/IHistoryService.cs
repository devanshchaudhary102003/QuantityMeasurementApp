using HistoryService.DTOs;
using HistoryService.Models;

namespace HistoryService.Interfaces
{
    public interface IHistoryService
    {
        void SaveHistory(SaveHistoryDTO dto);
        IEnumerable<QuantityMeasurementEntity> GetHistory(int userId);
        void DeleteHistory(int userId);
        IEnumerable<QuantityMeasurementEntity> GetHistoryByOperation(int userId, string operationType);
        IEnumerable<QuantityMeasurementEntity> GetHistoryByType(int userId, string measurementType);
        object GetStats(int userId);
    }
}
