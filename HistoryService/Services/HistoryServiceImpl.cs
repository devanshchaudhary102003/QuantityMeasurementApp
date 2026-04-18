using HistoryService.DTOs;
using HistoryService.Interfaces;
using HistoryService.Models;

namespace HistoryService.Services
{
    public class HistoryServiceImpl : IHistoryService
    {
        private readonly IHistoryRepository _repository;

        public HistoryServiceImpl(IHistoryRepository repository)
        {
            _repository = repository;
        }

        public void SaveHistory(SaveHistoryDTO dto)
        {
            // userId == 0 means guest — skip saving history
            if (dto.UserId == 0) return;

            _repository.SaveToDatabase(new QuantityMeasurementEntity
            {
                UserId = dto.UserId,
                Value1 = dto.Value1,
                Value2 = dto.Value2,
                Unit1 = dto.Unit1,
                Unit2 = dto.Unit2,
                Category = dto.Category,
                Operation = dto.Operation,
                Result = dto.Result,
                CreatedAt = DateTime.UtcNow
            });
        }

        public IEnumerable<QuantityMeasurementEntity> GetHistory(int userId)
        {
            return _repository.GetMyDatabase(userId);
        }

        public void DeleteHistory(int userId)
        {
            _repository.DeleteHistory(userId);
        }

        public IEnumerable<QuantityMeasurementEntity> GetHistoryByOperation(int userId, string operationType)
        {
            return _repository.GetHistoryByOperation(userId, operationType);
        }

        public IEnumerable<QuantityMeasurementEntity> GetHistoryByType(int userId, string measurementType)
        {
            return _repository.GetHistoryByType(userId, measurementType);
        }

        public object GetStats(int userId)
        {
            return _repository.GetStats(userId);
        }
    }
}
