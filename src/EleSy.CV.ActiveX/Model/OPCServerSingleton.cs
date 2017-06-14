using System;
using Opc;
using Factory = OpcCom.Factory;
using Server = Opc.Da.Server;

namespace EleSy.CV.ActiveX.Model
{
    public class OpcServerSingleton
    {
        public static Server Instance;

        protected OpcServerSingleton()
        {
        }
        public static void GetInstance(string host, string opcserver)
        {
            Instance = null;
            if (!String.IsNullOrEmpty(host) || !String.IsNullOrEmpty(opcserver))
            {
                Instance = new Server(new Factory(), new URL(String.Format(@"opcda://{0}/{1}", host, opcserver)));
            }
            else
            {
                throw new Exception("Отсутствуют настройки подключения к удаленному серверу");
            }
        }
    }
}
