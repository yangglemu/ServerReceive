using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerReceive
{
    class Shop
    {
        public string name;
        public string pname;
        public Shop(string name, string pname)
        {
            this.name = name;
            this.pname = pname;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
