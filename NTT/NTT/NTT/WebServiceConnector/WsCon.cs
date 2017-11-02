using NTT.AlarmsGridWS;
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

        public static List<alarmSmartAgent> GetAMListFromWebService()
        {
            using (ActiveAlarmsGridWebServiceClient AlarmsGridClient = new ActiveAlarmsGridWebServiceClient())
            {
                GridFilterPagingLoadConfigType config = new GridFilterPagingLoadConfigType();

                config.sortingfield = "id";
                config.sortdirection = SortDirType.ASC;
                config.itemsperpage = 1;
                config.zerobasedpageoffset = 0;

                GridPagingResponseType res = AlarmsGridClient.getPagingData(null, config, null);

                return res.resultlist.OfType<alarmSmartAgent>().ToList();
            }
        }
        
    }
}
