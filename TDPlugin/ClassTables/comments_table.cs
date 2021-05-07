using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDPlugin.ClassTables
{
    class comments_table
    {
        public string tab_title { get; }

        // Names of collums in table
        public string col_id { get; }
        public string col_val { get; }
        public string col_text { get; }
        public string col_foreign { get; }

        public comments_table(string title, string id, string text, string val, string foreign)
        {
            tab_title = title;
            col_id = id;
            col_val = val;
            col_text = text;
            col_foreign = foreign;
        }
    }
}
