using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDPlugin.DBclasses
{
    class Mark
    {
        public int id;
        public string name;
        public int id_file;
        public int avg_val;

        public Mark(int id, string name, int id_file, int avg_val = 0)
        {
            this.id = id;
            this.name = name;
            this.id_file = id_file;
            this.avg_val = avg_val;
        }
    }
}
