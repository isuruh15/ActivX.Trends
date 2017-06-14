using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EleSy.CV.ActiveX.Model;
using Opc;
using Opc.Da;
using Server = Opc.Da.Server;

namespace EleSy.CV.ActiveX.Items.Factories
{
    class CompositeFactory
    {
         private readonly Server _server;

         public CompositeFactory()
        {
            _server = OpcServerSingleton.Instance;
        }

        public Composite Create(string compositetag)
        {
            Composite item = null;
            if (_server == null)
            {
                return null;
            }

            string tag = String.Format(String.Format(@"SCEC.SCEC_Kuzbass.{0}.EmergencyResponsePlan", compositetag));
            try
            {
                var tags = new List<string>
                {
                    "Period.Start",
                    "Period.End",
                    "NumberOfPosition.AtTheBegining",
                    "NumberOfPosition.ForToday",
                    "Involved",
                    "Changes.AddedChanges",
                    "Changes.AddedPosition",
                    "Changes.ExtractedPosition"
                };

                var propertyTags = tags.Select(t => String.Format("{0}.{1}", tag, t)).ToList();

                DateTime periodstart;
                DateTime.TryParse(Read(propertyTags[0]), out periodstart);
                DateTime periodend;
                DateTime.TryParse(Read(propertyTags[1]), out periodend);
                int atTheBegining;
                Int32.TryParse(Read(propertyTags[2]), out atTheBegining);
                int forToday;
                Int32.TryParse(Read(propertyTags[3]), out forToday);
                int involved;
                Int32.TryParse(Read(propertyTags[4]), out involved);
                int changesAddedChanges;
                Int32.TryParse(Read(propertyTags[5]), out changesAddedChanges);
                int changesAddedPosition;
                Int32.TryParse(Read(propertyTags[6]), out changesAddedPosition);
                int changesExtractedPosition;
                Int32.TryParse(Read(propertyTags[7]), out changesExtractedPosition);

                item = new Composite
                {
                    PeriodStart = periodstart,
                    PeriodEnd = periodend,
                    NumberOfPositionAtBegining = atTheBegining,
                    NumberOfPositionForToday = forToday,
                    ExtractedPosition = changesExtractedPosition,
                    AddedPosition = changesAddedPosition,
                    AddedChanges = changesAddedChanges,
                    Involved = involved,
                    MineTag = compositetag
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Невозможно считать события" + ex);
            }
            if (item == null) throw new Exception("Объект мероприятия не сформирован");
            return item;
        }

        private string Read(string tag)
        {
            var items = new Item[1];
            items[0] = new Item(new ItemIdentifier(tag));
            try
            {
                ItemValueResult[] values = _server.Read(items);
                string value = values[0].Value.ToString();
                return value;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show(@"Ошибка построения таблицы: Проверте правельность парметров конфигуратора.");
                throw;
            }
        }
    }
}
