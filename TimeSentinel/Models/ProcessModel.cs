namespace TimeSentinel.Models
{
    public record ProcessRecord
    {
        public int ProcessId { get; init; } = 0;
        public bool IsActive { get; set; } = false;
        public required string ProcessName {  get; init; }
        public int ProcessTotalTime { get; set; }
    }
}
