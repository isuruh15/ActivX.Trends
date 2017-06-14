using System;

namespace EleSy.CV.ActiveX.Model.OpcClients
{
    public class OpcValueResult
    {
        public const int GoodQuality = 192;
        public double Value { get; set; }

        public DateTime TimesTamp { get; set;  }

        public int Quality { get; set; }
        public string Demenision { get; set; }
    }
}
