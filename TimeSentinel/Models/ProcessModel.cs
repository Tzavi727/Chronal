using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
