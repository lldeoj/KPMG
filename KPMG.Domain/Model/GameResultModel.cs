using System;
using System.Collections.Generic;
using System.Text;

namespace KPMG.Domain.Models
{
    public class GameResultModel
    {
        public int Id { get; set; }
        public long PlayerId { get; set; }
        public long GameId { get; set; }
        public long Win { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
