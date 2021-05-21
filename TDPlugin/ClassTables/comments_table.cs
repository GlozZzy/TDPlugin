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
        public string col_text { get; }
        public string col_foreign { get; }
        public string col_author { get; }
        public string col_status { get; }

        public comments_table(string title, string id, string text, string foreign, string author, string status)
        {
            tab_title = title;
            col_id = id;
            col_text = text;
            col_foreign = foreign;
            col_author = author;
            col_status = status;
        }
    }
}
