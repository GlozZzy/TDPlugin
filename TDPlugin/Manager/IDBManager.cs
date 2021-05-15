using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using TDPlugin.DBclasses;

namespace TDPlugin.Tools
{
    interface IDBManager
    {
        bool check_connection();
        void OpenConnection();
        void CloseConnection();
        bool search_exist_file(string filename);
        bool search_exist_mark(string filename, string markname);

        void add_new_record_file(string filename);
        void add_new_record_mark(string filename, string markname);
        void add_new_record_comment(string filename, string markname, int val, string text);

        void edit_record_file(Filename filename, string Ename);
        void edit_record_mark(Mark markname, string Ename);
        void edit_record_comment(Comment comm, string Etext);

        void delete_record_file(Filename filename);
        void delete_record_mark(Mark markname);
        void delete_record_comment(Comment comm);

        void recount_file_avg_value(string filename);
        void recount_mark_avg_value(string filename, string markname);
    }
}
