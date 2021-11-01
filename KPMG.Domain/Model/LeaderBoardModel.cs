using System;
using System.Collections.Generic;
using System.Text;

namespace KPMG.Domain.Models
{
    public class LeaderBoardModel
    {
        public long PlayerId { get; set; }
        public long Balance { get; set; }
        public string LastUpdateDate { get; set; }

    }
}
