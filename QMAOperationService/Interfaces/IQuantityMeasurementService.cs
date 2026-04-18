using QMAOperationService.DTOs;

namespace QMAOperationService.Interfaces
{
    public interface IQuantityMeasurementService
    {
        Task<bool> Compare(QuantityDTO first, QuantityDTO second, int userId);
        Task<QuantityDTO> Add(QuantityDTO first, QuantityDTO second, int userId);
        Task<QuantityDTO> Subtract(QuantityDTO first, QuantityDTO second, int userId);
        Task<double> Divide(QuantityDTO first, QuantityDTO second, int userId);
        Task<QuantityDTO> Convert(QuantityDTO source, string targetUnit, int userId);
    }
}
