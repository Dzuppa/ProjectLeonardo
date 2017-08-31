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
using static Demo.BusinessLogic.Model;

namespace Demo.BusinessLogic
{
    class DBUtility
    {

        public static List<Book> GetBookList()
        {
            using (var db = new BooksContext())
            {
                return db.Books.ToList();
            }


        }
    }
}
