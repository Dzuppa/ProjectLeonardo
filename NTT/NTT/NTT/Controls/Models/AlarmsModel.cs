using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT.Controls.Models
{
    class AlarmsModel : INotifyPropertyChanged
    {
        private string _id;
        private string _name;
        private string _dettaglio;

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public string dettaglio
        {
            get
            {
                return _dettaglio;
            }

            set
            {
                if (_dettaglio != value)
                {
                    _dettaglio = value;
                    RaisePropertyChanged("dettaglio");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
