using System.Collections;
using Opc;

namespace EleSy.CV.ActiveX.Model.OpcClients
{
    /// <summary>
    /// Базовый класс для OPC-клиентов
    /// </summary>
    public abstract class OpcClientBase
    {
        /// <summary>
        /// Объект сервера
        /// </summary>
        protected Server Server;

        /// <summary>
        /// Соединение с сервером
        /// </summary>
        /// <param name="host">Хост</param>
        /// <param name="serverName">Наименование OPC-сервера</param>
        public abstract void Connect(string host, string serverName);

        /// <summary>
        /// Отключение от сервера
        /// </summary>
        public abstract void Disconnect();

        /// <summary>
        /// Освобождение ресурсов
        /// </summary>
        public void Dispose()
        {
        }

        public void SubscribeTags(IList tagNames)
        {
        }

        public void BrowseTags()
        {
        }



    }




}