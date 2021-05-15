using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDPlugin.DBclasses
{
    class Filename
    {
        public int id;
        public string name;
        public int avg_val;

        public Filename(int id, string name, int avg_val = 0)
        {
            this.id = id;
            this.name = name;
            this.avg_val = avg_val;
        }
    }
}
