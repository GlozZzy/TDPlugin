using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDPlugin.DBclasses
{
    class Issue
    {
        public int id;
        public string name;
        public int id_file;
        public int severity;

        public Issue(int id, string name, int severity, int id_file)
        {
            this.id = id;
            this.name = name;
            this.id_file = id_file;
            this.severity = severity;
        }
    }
}
