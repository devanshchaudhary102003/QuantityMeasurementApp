using System;
using QuantityMeasurementApp.Model;

namespace QuantityMeasurementApp.Interface
{
    public interface IQuantityMeasurement
    {
        void Compare<U>(Quantity<U> q1, Quantity<U> q2) where U : Enum;
        void Conver<U>(Quantity<U> q, U targetUnit) where U : Enum;
        void Add<U>(Quantity<U> q1, Quantity<U> q2, U targetUnit) where U : Enum;
    }
}