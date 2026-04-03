using QuantityMeasurementAppModelLayer.Entity;

namespace QuantityMeasurementAppRepositoryLayer.Interface
{
    public interface IQuantityMeasurementRepository
    {
        void Register(UserEntity user);
        UserEntity? GetUserbyEmail(string email);
        IEnumerable<QuantityMeasurementEntity> GetMyDatabase(int userId);
        void SaveToDatabase(QuantityMeasurementEntity quantity);
    }
}