using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarinpclshared
{
    public class App
    {
        public static Page GetToDoPage()
        {
            return new ToDoPage();
        }
    }
}
