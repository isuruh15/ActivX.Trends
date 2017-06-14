using Opc;
using Opc.Da;

namespace EleSy.CV.ActiveX.Model.OpcClients
{
    public class OpcDaClient : OpcDaClientBase
    {
        private bool flag = true;
        private OpcValueResult distanveEnd;
        private OpcValueResult dimension;
        private string doubleValue4 { get; set; }

        public override void GetValue(string tagName)
        {

        }

        public override void Subscribe(string tagName1, string tagName2, string tagName3, string tagName4)
        {

            var groupState = new SubscriptionState {Name = "Group", UpdateRate = 100, Active = true};
            var groupRead = (Subscription) (Server as Opc.Da.Server).CreateSubscription(groupState);
            groupRead.DataChanged += GroupReadOnDataChanged;
            var items = new Item[4];
            items[0] = new Item {ItemName = tagName1};
            items[1] = new Item {ItemName = tagName2};
            items[2] = new Item {ItemName = tagName3};
            items[3] = new Item {ItemName = tagName4};
            groupRead.AddItems(items);

        }

        //Изменение значение в сервере
        private void GroupReadOnDataChanged(object subscriptionHandle, object requestHandle, ItemValueResult[] values)
        {

            var value = new OpcValueResult();
            var distanveNow = new OpcValueResult();
            var doubleValue1 = System.Convert.ToDouble((values[0].Value));
            var doubleValue2 = System.Convert.ToDouble((values[1].Value));
            if (flag)
            {
                distanveEnd = new OpcValueResult();
                dimension = new OpcValueResult();
                var doubleValue3 = System.Convert.ToDouble((values[2].Value));

                distanveEnd.Value = doubleValue3;
                doubleValue4 = System.Convert.ToString((values[3].Value));

                flag = false;
            }

            dimension.Demenision = Convert.ToString(doubleValue4);
            value.Value = doubleValue1;
            distanveNow.Value = doubleValue2;

            value.TimesTamp = values[0].Timestamp;
            distanveNow.TimesTamp = values[1].Timestamp;

            value.Quality = values[0].Quality.GetHashCode();

            //Передаём значения на график 
            OnDataChanged(value, distanveNow, distanveEnd, dimension);
        }

        //Connect to server
        public override void Connect(string host, string serverName)
        {
            var url = new URL("opcda://" + host + "/" + serverName);
            Server = new Opc.Da.Server(new OpcCom.Factory(), url);
            Server.Connect();
        }

        public override void Disconnect()
        {
            Server.Disconnect();
        }
    }
}
