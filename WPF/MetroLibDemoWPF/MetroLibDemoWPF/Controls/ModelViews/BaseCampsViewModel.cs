using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroLibDemoWPF.Controls.ModelViews
{
    class BaseCampsViewModel
    {
        public BaseCampsViewModel()
        {
            LoadModel();
        }

        public List<string> Items
        {
            get;
            set;
        }

        public void LoadModel()
        {
            List<string> items = new List<string>();

            items.Add("Rome");
            items.Add("Milan");
            items.Add("Berlin");
            items.Add("New York");
            items.Add("Tokyo");
            items.Add("Hamburg");
            items.Add("Pordenone");
            items.Add("Paris");
            items.Add("Moscow");
            items.Add("Hamburg");
            items.Add("Pordenone");
            items.Add("Paris");
            items.Add("Moscow");

            Items = items;
        }
    }
}
