using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EleSy.CV.ActiveX.Model
{
    [Serializable]
    internal class Serializer
    {
        #region Сериализация и десериализация списка объектов
        
        public string SerializeObject<T>(T serializableObjects)
        {
            XmlSerializer serializer = new XmlSerializer(serializableObjects.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, serializableObjects);
                return textWriter.ToString();
            }
        }


        public T DeserializeObject<T>(String xmlObject)
        {
            T deserializeObject = default(T);

            XmlSerializer serializer = new XmlSerializer(typeof (T));
            try
            {
                using (TextReader textReader = new StreamReader(xmlObject))
                {
                    return (T)serializer.Deserialize(textReader);
                }
            }
            catch (Exception)
            {
                return deserializeObject;
            }
        }

        #endregion
    }
}