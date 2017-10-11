using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT.Controls.Models
{
    class NotifyModel : INotifyPropertyChanged
    {
        private int _number;

        public int Number
        {
            get
            {
                return _number;
            }

            set
            {
                if (_number != value)
                {
                    _number = value;
                    RaisePropertyChanged("Number");
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
