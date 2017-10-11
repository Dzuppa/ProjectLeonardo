using NTT.Controls.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT.WebServiceConnector
{
    class WsCon
    {
        public bool connect2WebService()
        {
            //questo metodo potrà essere usato per inizializzare il servizio 
            //e per settare eventuali parametri quali url, username, password ecc.
            return true;
        }

        public ObservableCollection<AlarmsModel> GetAMListFromWebService()
        {
            ObservableCollection<AlarmsModel> aList = new ObservableCollection<AlarmsModel>();

            aList.Add(new AlarmsModel { Id = "0", Name = "Zero" });
            aList.Add(new AlarmsModel { Id = "1", Name = "Uno" });
            aList.Add(new AlarmsModel { Id = "2", Name = "Due" });
            aList.Add(new AlarmsModel { Id = "3", Name = "Tre" });

            return aList;
        }
        
    }
}
