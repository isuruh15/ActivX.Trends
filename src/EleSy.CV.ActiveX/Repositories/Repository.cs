using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EleSy.CV.ActiveX.Items;
using EleSy.CV.ActiveX.Items.Factories;
using EleSy.CV.ActiveX.Model;
using Opc.Da;

namespace EleSy.CV.ActiveX.Repositories
{
    class Repository
    {
        private Server _server;

        //public void Add(Composite composite, string compositetag)
        //{
        //    string tag = String.Format(@"SCEC.SCEC_Kuzbass.{0}.EmergencyResponsePlan", compositetag);
        //    try
        //    {
        //        var tags = new List<string>
        //        {
        //            "Period.Start",
        //            "Period.End",
        //            "NumberOfPosition.AtTheBegining",
        //            "NumberOfPosition.ForToday",
        //            "Involved",
        //            "Changes.AddedChanges",
        //            "Changes.AddedPosition",
        //            "Changes.ExtractedPosition"
        //        };

        //        var propertyTags = tags.Select(t => String.Format("{0}.{1}", tag, t)).ToList();

        //        Write(propertyTags[0], composite.PeriodStart.ToString("dd.MM.yyyy"));
        //        Write(propertyTags[1], composite.PeriodEnd.ToString("dd.MM.yyyy"));
        //        Write(propertyTags[2], composite.NumberOfPositionAtBegining.ToString(CultureInfo.InvariantCulture));
        //        Write(propertyTags[3], composite.NumberOfPositionForToday.ToString(CultureInfo.InvariantCulture));
        //        Write(propertyTags[4], composite.Involved.ToString(CultureInfo.InvariantCulture));
        //        Write(propertyTags[5], composite.AddedChanges.ToString(CultureInfo.InvariantCulture));
        //        Write(propertyTags[6], composite.AddedPosition.ToString(CultureInfo.InvariantCulture));
        //        Write(propertyTags[7], composite.ExtractedPosition.ToString(CultureInfo.InvariantCulture));
        //    }
        //    catch
        //    {
        //        throw new Exception();
        //    }
        //}

        public Composite Get(string tag)
        {
            var compositeItem = new CompositeFactory().Create(tag);
            return compositeItem;
        }

        public void Write(string tag, string value)
        {
            _server = OpcServerSingleton.Instance;
            if (_server == null)
            {
                return;
            }
            var items = new ItemValue[1];
            items[0] = new ItemValue
            {
                ClientHandle = Guid.NewGuid(),
                ItemName = tag,
                Value = value
            };
            try
            {
                _server.Write(items);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
