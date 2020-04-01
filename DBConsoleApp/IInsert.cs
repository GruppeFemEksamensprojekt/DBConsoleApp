using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConsoleApp
{
    interface IInsert
    {
        void Insert(int hotelNo, string name, string address);
    }
}
