using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace TDPlugin.Tools
{
    interface IBDManager
    {
        bool check_connection();
        void OpenConnection();
        void CloseConnection();
        bool search_exist_file(string filename);
        bool search_exist_mark(string filename, string markname);

        void add_new_record_file(string filename);
        void add_new_record_mark(string filename, string markname);
        void add_new_record_comment(string filename, string markname, int val, string text);

        void edit_record_file(string filename, string Ename);
        void edit_record_mark(string filename, string markname, string Ename);
        void edit_record_comment(string filename, string markname, string text, int Eval, string Etext);

        void delete_record_file(string filename);
        void delete_record_mark(string filename, string markname);
        void delete_record_comment(string filename, string markname, string name);

        void recount_file_avg_value(string filename);
        void recount_mark_avg_value(string filename, string markname);
    }
}
