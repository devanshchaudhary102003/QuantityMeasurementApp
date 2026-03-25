using QuantityMeasurementAppModelLayer.Models;

namespace QuantityMeasurementAppRepositoryLayer.Interface
{
    public interface IQuantityMeasurementRepository
    {
        void Register(UserEntity user);
        UserEntity? GetUserbyName(string name);
        IEnumerable<QuantityMeasurementEntity> GetMyDatabase(int userId);
        void SaveToDatabase(QuantityMeasurementEntity quantity);
    }
}