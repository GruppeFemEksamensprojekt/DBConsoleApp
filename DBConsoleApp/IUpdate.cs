using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConsoleApp
{
    interface IUpdate
    {
        void UpdateName(int id, string name);
        void UpdateAddress(int id, string address);
        void UpdateHotel(int id, string name, string address);
    }
}
