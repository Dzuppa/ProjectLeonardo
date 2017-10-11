using NTT.Controls.Models;
using NTT.WebServiceConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT.Controls.ViewModels
{
    class AlarmsListViewModel
    {
        public AlarmsListViewModel()
        {
            LoadModel();
        }

        public ObservableCollection<AlarmsModel> AlarmsList
        {
            get;
            set;
        }

        public void LoadModel()
        {
            WsCon wsCon = new WsCon();
            ObservableCollection<AlarmsModel> aList = new ObservableCollection<AlarmsModel>();

            if (wsCon.connect2WebService())
            {
                aList = wsCon.GetAMListFromWebService();
                AlarmsList = aList;
            }
            
        }
    }
}
