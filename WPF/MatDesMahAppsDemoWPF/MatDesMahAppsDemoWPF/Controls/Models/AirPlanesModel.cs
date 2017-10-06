using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatDesMahAppsDemoWPF.Controls.Models
{
    class AirPlanesModel : INotifyPropertyChanged
    {
        private string _id;
        private string _model;
        private string _capFullName;
        private string _authorized;

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

        public string Model
        {
            get
            {
                return _model;
            }

            set
            {
                if (_model != value)
                {
                    _model = value;
                    RaisePropertyChanged("Model");
                }
            }
        }

        public string CapFullName
        {
            get
            {
                return _capFullName;
            }

            set
            {
                if (_capFullName != value)
                {
                    _capFullName = value;
                    RaisePropertyChanged("CapFullName");
                }
            }
        }

        public string Authorized
        {
            get
            {
                return _authorized;
            }

            set
            {
                if (_authorized != value)
                {
                    _authorized = value;
                    RaisePropertyChanged("Authorized");
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
