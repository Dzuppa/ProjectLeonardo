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
        //private EventAggregator eventAggregator;
        //private WebSocketManager.WebSocketManager socketManager;

        public NotifyViewModel()
        {
            LoadModel();
            //this.eventAggregator = new EventAggregator();

            //this.eventAggregator.Subscribe(this);
            WebSocketManager.WebSocketManager.InitializeWebSocketManager(this);
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
