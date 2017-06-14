using System;

namespace EleSy.CV.ActiveX.Model.OpcClients
{
    class DataChangedEventArgs : EventArgs
    {
        public OpcValueResult Value { get; set; }
        public OpcValueResult DistanceNow { get; set; }
        public OpcValueResult DistanceEnd { get; set; }
        public OpcValueResult Dimension { get; set; }

        public DataChangedEventArgs(OpcValueResult value, OpcValueResult distanceNow, OpcValueResult distanceEnd,OpcValueResult dimension)
        {
            Value = value;
            DistanceNow = distanceNow;
            DistanceEnd = distanceEnd;
            Dimension = dimension;
        }
    }
}
