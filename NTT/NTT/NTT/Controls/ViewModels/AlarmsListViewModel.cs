using NTT.AlarmsGridWS;
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
            this.AlarmsList = new ObservableCollection<AlarmsModel>();
            //LoadModel();
        }

        public ObservableCollection<AlarmsModel> AlarmsList
        {
            get;
            set;
        }

        public AlarmsListViewModel GetData()
        {
            AlarmsListViewModel agvm = new AlarmsListViewModel();
            List<alarmSmartAgent> alarmList = WsCon.GetAMListFromWebService();
            agvm = GetViewModelFromDTO(alarmList);
            return agvm;

        }

        private AlarmsListViewModel GetViewModelFromDTO(List<alarmSmartAgent> list)
        {
            AlarmsListViewModel agvm = new AlarmsListViewModel();
            //transform res to agvm
            foreach (alarmSmartAgent alarm in list)
            {
                AlarmsModel model = new AlarmsModel();
                model.IdAlarm = alarm.identifier.id + "-" + alarm.identifier.version;
                model.IdSmartAgent = alarm.smartAgent.identifier.id + "-" + alarm.smartAgent.identifier.version;
                //model.SmartAgentType = alarm.smartAgent.smartAgentType.code + " - " + alarm.smartAgent.smartAgentType.acronym;
                model.VesselName = alarm.systemTrack.staticData.identificationData.name;
                model.IMO = alarm.systemTrack.staticData.identificationData.imo.ToString();
                model.MMSI = alarm.systemTrack.staticData.identificationData.mmsi.ToString();
                model.Flag = alarm.systemTrack.staticData.identificationData.countryCode.code;
                model.LastTrack = alarm.detectionDate.ToShortDateString();

                agvm.AlarmsList.Add(model);
            }
            return agvm;
        }

        public AlarmsListViewModel Change()
        {
            AlarmsListViewModel vm = new AlarmsListViewModel();

            ObservableCollection<AlarmsModel> list = new ObservableCollection<AlarmsModel>();

            

            vm.AlarmsList = list;

            return vm;
        }
    }
}
