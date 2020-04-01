using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConsoleApp
{
    interface ISelect
    {
        void SelectAllHotels();

        void SelectSpecificHotel(int id);
    }
}
