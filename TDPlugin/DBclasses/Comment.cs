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
        public int id_issue;
        public string author;
        public int status;

        public Comment(int id, int id_mark, string text, string author, int status)
        {
            this.id = id;
            this.text = text;
            this.id_issue = id_mark;
            this.author = author;
            this.status = status;
        }
    }
}
