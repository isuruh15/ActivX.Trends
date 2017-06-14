using System;

namespace EleSy.CV.ActiveX.Model.OpcClients
{
    public abstract class OpcDaClientBase : OpcClientBase
    {
        public event EventHandler DataChanged;

        protected virtual void OnDataChanged(OpcValueResult value, OpcValueResult distanceNow, OpcValueResult distanceEnd, OpcValueResult dimension)
        {
            var handler = DataChanged;
            if (handler != null)
                handler(this, new DataChangedEventArgs(value, distanceNow, distanceEnd, dimension));
        }

        public abstract void GetValue(string tagName);

        public abstract void Subscribe(string tagName1, string tagName2, string tagName3, string tagName4);

    }
}
