namespace HistoryService.DTOs
{
    public class SaveHistoryDTO
    {
        public int UserId { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public string Unit1 { get; set; } = string.Empty;
        public string Unit2 { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public double Result { get; set; }
    }

    public class HistoryResponseDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
        public string Unit1 { get; set; } = string.Empty;
        public string Unit2 { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public double Result { get; set; }
    }
}
