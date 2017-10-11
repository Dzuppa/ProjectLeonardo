using NTT.Controls.Models;
using NTT.WebServiceConnector;
using NTT.WebSocketManager;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT.Controls.ViewModels
{
    class NotifyViewModel : IListen<object>
    {
        public NotifyViewModel(EventAggregator eventAggregator)
        {
            LoadModel();
            eventAggregator.Subscribe(this);
        }

        public NotifyModel Alarm
        {
            get;
            set;
        }

        public void Handle(object obj)
        {
            Alarm.Number = Convert.ToInt32(obj.ToString());
        }

        public void LoadModel()
        {
            NotifyModel alarm = new NotifyModel();

            alarm.Number = 4;

            Alarm = alarm;
        }


    }
}
