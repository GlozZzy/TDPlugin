using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDPlugin.ClassTables
{
    class issues_table
    {
        public string tab_title { get; }

        // Names of collums in table
        public string col_id { get; }
        public string col_name { get; }
        public string col_severity { get; }
        public string col_foreign { get; }
        public string col_linefrom { get; }
        public string col_lineto { get; }

        public issues_table(string title, string id, string name, string severity, string foreign, string linefrom, string lineto)
        {
            tab_title = title;
            col_id = id;
            col_name = name;
            col_foreign = foreign;
            col_severity = severity;
            col_linefrom = linefrom;
            col_lineto = lineto;
        }
    }
}
