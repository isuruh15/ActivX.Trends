using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using EleSy.CV.ActiveX.Annotations;

namespace EleSy.CV.ActiveX.Model
{
    public class ServerInfo
    {
         private string _serverHost = string.Empty;
        private string _serverProxy = string.Empty;
        
        //[DisplayName(@"Название шахты")]
        public string ServerHost
        {
            get { return _serverHost; }
            set
            {
                _serverHost = value;
                OnPropertyChanged(@"ServerHost");
            }
        }

        //[DisplayName(@"Теги шахт")]
        public string ServerProxy
        {
            get { return _serverProxy; }
            set
            {
                _serverProxy = value;
                OnPropertyChanged(@"ServerProxy");
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
