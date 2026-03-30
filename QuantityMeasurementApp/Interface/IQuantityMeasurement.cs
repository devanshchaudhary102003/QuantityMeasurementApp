using QuantityMeasurementApp.Model;
namespace QuantityMeasurementApp.Interface
{
    public interface IQuantityMeasurement
{
    void Compare<U>(Quantity<U> quantityOne, Quantity<U> quantityTwo) where U : Enum;
    void Conver<U>(Quantity<U> q, U targetUnit) where U : Enum;
    void Add<U>(Quantity<U> quantityOne, Quantity<U> quantityTwo, U targetUnit) where U : Enum;

    void Subtract<U>(Quantity<U> quantityOne, Quantity<U> quantityTwo, U targetUnit) where U : Enum;
    void Divide<U>(Quantity<U> quantityOne, Quantity<U> quantityTwo) where U : Enum;
}
}