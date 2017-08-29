using Demo.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Demo.Controls
{
    public class MyControl : Control
    {
        protected T GetTemplateChild<T>(string name) where T : DependencyObject
        {
            var child = GetTemplateChild(name) as T;
            if (child == null)
            {
                throw new NullReferenceException(name);
            }

            return child;
        }

    }
}
