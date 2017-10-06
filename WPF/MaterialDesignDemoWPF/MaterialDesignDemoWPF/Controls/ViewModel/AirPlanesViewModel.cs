using MaterialDesignDemoWPF.Controls.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignDemoWPF.Controls.ViewModel
{
    class AirPlanesViewModel
    {
        public AirPlanesViewModel()
        {
            LoadModel();
        }

        public ObservableCollection<AirPlanesModel> APData
        {
            get;
            set;
        }

        public void LoadModel()
        {
            ObservableCollection<AirPlanesModel> aPData = new ObservableCollection<AirPlanesModel>();

            aPData.Add(new AirPlanesModel { Id = "0", Model = "MiG-21", CapFullName="Mario Rossi", Authorized="true"  });
            aPData.Add(new AirPlanesModel { Id = "1", Model = "Waco 10", CapFullName="Francesco Bruni", Authorized="false"  });
            aPData.Add(new AirPlanesModel { Id = "2", Model = "Mitsubishi Zero", CapFullName="Giovanni De Angelis", Authorized="false"  });
            aPData.Add(new AirPlanesModel { Id = "3", Model = "Boeing 787", CapFullName = "Giorgio Treccani", Authorized = "true" });
            aPData.Add(new AirPlanesModel { Id = "4", Model = "Pilatus PC-12", CapFullName = "Federico Dominici", Authorized = "false" });
            aPData.Add(new AirPlanesModel { Id = "5", Model = "Bleriot XI", CapFullName = "Luigi Verdi", Authorized = "true" });

            APData = aPData;
        }
    }
}
