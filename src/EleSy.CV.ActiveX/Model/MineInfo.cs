using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using EleSy.CV.ActiveX.Annotations;
using EleSy.CV.ActiveX.Forms;

namespace EleSy.CV.ActiveX.Model
{
    [Serializable]
    public class MineInfo : INotifyPropertyChanged
    {
        //private string _mineName = string.Empty;
        private string _mineTag = string.Empty;
        
        //[DisplayName(@"Название")]
        //public string MineName
        //{
        //    get { return _mineName; }
        //    set
        //    {
        //        _mineName = value;
        //        OnPropertyChanged("MineName");
        //    }
        //}

        [DisplayName(@"Теги")]
        public string MineTag
        {
            get { return _mineTag; }
            set
            {
                _mineTag = value;
                OnPropertyChanged("MineTag");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
