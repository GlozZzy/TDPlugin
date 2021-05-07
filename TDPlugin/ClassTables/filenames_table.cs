using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDPlugin.ClassTables
{
    class filenames_table
    {
        public string tab_title { get; }
        // Names of collums in table
        public string col_id { get; }
        public string col_name { get; }
        public string col_avg { get; }

        public filenames_table(string title, string id, string name, string avg_value)
        {
            tab_title = title;
            col_id = id;
            col_name = name;
            col_avg = avg_value;
        }
    }
}
