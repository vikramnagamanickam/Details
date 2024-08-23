using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccessLayer.Entity
{
    class CricketDetails
    {
        public long CricketersID { get; set; }

        public long CricketerName { get; set; }

        public long Totalinnings { get; set; }

        public long TotalScore { get; set; }

        public DateTime DateOfBirth { get; set; }

        public long NumberOfFifties { get; set; }

        public long NumberOfHundreds { get; set; }

        public long HighestScore { get; set; }
    }
}
