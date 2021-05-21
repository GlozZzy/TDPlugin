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
        bool search_exist_mark(string filename, string issuename);
        Comment search_exist_author_comment(Issues issue, string author, int status);

        void add_new_record_file(string filename);
        void add_new_record_mark(string filename, string issuename, int severity);
        void add_new_record_comment(string filename, string issuename, string text, string author, int status);

        void edit_record_file(Filename filename, string Ename);
        void edit_record_mark(Issues issuename, string Ename, int Eseverity);
        void edit_record_comment(Comment comm, string Etext, string Eauthor, int Estatus);

        void delete_record_file(Filename filename);
        void delete_record_mark(Issues issuename);
        void delete_record_comment(Comment comm);

        Filename get_file(int i);
        Issues get_mark(Filename filename, int i);
        Comment get_comment(Issues issuename, int i);
    }
}
