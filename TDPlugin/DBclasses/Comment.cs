using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDPlugin.DBclasses
{
    class Comment
    {
        public int id;
        public string text;
        public int id_mark;
        public int val;

        public Comment(int id, int id_mark, string text, int val)
        {
            this.id = id;
            this.text = text;
            this.id_mark = id_mark;
            this.val = val;
        }
    }
}
