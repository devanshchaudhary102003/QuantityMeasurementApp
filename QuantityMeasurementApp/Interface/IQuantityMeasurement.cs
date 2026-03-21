namespace QuantityMeasurementApp.Interface
{
    interface IQuantityMeasurement
    {
        void Feet();
        void Inches();
        void CompareLength();
        void ConvertLength();
        void AddLength();
        void AddLengthWithTargetUnit();
        void CompareWeight();
        void ConvertWeight();
        void AddWeight();
        void AddWeightWithTargetUnit();
    }
}