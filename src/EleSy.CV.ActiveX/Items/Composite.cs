using System;
using EleSy.CV.ActiveX.Model;

namespace EleSy.CV.ActiveX.Items
{
    class Composite
    {
        public DateTime PeriodStart
        {
            get;
            set;
        }

        public DateTime PeriodEnd
        {
            get;
            set;
        }
        
        public int NumberOfPositionAtBegining
        {
            get;
            set;
        }

        public int NumberOfPositionForToday
        {
            get;
            set;
        }

        public int ExtractedPosition
        {
            get;
            set;
        }

        public int AddedPosition
        {
            get;
            set;
        }

        public int AddedChanges
        {
            get;
            set;
        }

        public int Involved
        {
            get;
            set;
        }

        public string MineTag { get; set; }
        public string MineName { get; set; }
            
    }
}
