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
        private string _idAlarm;
        private string _idSmartAgent;
        private string _smartAgentType;
        private string _vesselName;
        private string _imo;
        private string _mmsi;
        private string _flag;
        private string _stato;
        private string _lastTrack;
        //TO DO --> Missing detail properties
        private string _areaAcronym;
        private List<string> _tracks;
        private string _voi;

        public string IdAlarm
        {
            get
            {
                return _idAlarm;
            }

            set
            {
                if (_idAlarm != value)
                {
                    _idAlarm = value;
                    RaisePropertyChanged("IdAlarm");
                }
            }
        }

        public string IdSmartAgent
        {
            get
            {
                return _idSmartAgent;
            }

            set
            {
                if (_idSmartAgent != value)
                {
                    _idSmartAgent = value;
                    RaisePropertyChanged("IdSmartAgent");
                }
            }
        }

        public string SmartAgentType
        {
            get
            {
                return _smartAgentType;
            }

            set
            {
                if (_smartAgentType != value)
                {
                    _smartAgentType = value;
                    RaisePropertyChanged("SmartAgentType");
                }
            }
        }

        public string VesselName
        {
            get
            {
                return _vesselName;
            }

            set
            {
                if (_vesselName != value)
                {
                    _vesselName = value;
                    RaisePropertyChanged("VesselName");
                }
            }
        }

        public string IMO
        {
            get
            {
                return _imo;
            }

            set
            {
                if (_imo != value)
                {
                    _imo = value;
                    RaisePropertyChanged("IMO");
                }
            }
        }

        public string MMSI
        {
            get
            {
                return _mmsi;
            }

            set
            {
                if (_mmsi != value)
                {
                    _mmsi = value;
                    RaisePropertyChanged("MMSI");
                }
            }
        }

        public string Flag
        {
            get
            {
                return _flag;
            }

            set
            {
                if (_flag != value)
                {
                    _flag = value;
                    RaisePropertyChanged("Flag");
                }
            }
        }

        public string Stato
        {
            get
            {
                return _stato;
            }

            set
            {
                if (_stato != value)
                {
                    _stato = value;
                    RaisePropertyChanged("Stato");
                }
            }
        }

        public string LastTrack
        {
            get
            {
                return _lastTrack;
            }

            set
            {
                if (_lastTrack != value)
                {
                    _lastTrack = value;
                    RaisePropertyChanged("LastTrack");
                }
            }
        }

        //detail
        public string AreaAcronym
        {
            get
            {
                return _areaAcronym;
            }

            set
            {
                if (_areaAcronym != value)
                {
                    _areaAcronym = value;
                    RaisePropertyChanged("AreaAcronym");
                }
            }
        }

        public List<string> Tracks
        {
            get
            {
                return _tracks;
            }

            set
            {
                if (_tracks != value)
                {
                    _tracks = value;
                    RaisePropertyChanged("Tracks");
                }
            }
        }

        public string VOI
        {
            get
            {
                return _voi;
            }

            set
            {
                if (_voi != value)
                {
                    _voi = value;
                    RaisePropertyChanged("VOI");
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
