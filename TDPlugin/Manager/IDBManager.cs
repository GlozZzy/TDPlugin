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
        bool search_exist_issue(string filename, string issuename);
        Comment search_exist_author_comment(Issue issue, string author, int status);

        void add_new_record_file(string filename);
        void add_new_record_issue(string filename, string issuename, int severity, int linefrom, int lineto);
        void add_new_record_comment(string filename, string issuename, string text, string author, int status);

        void edit_record_file(Filename filename, string Ename);
        void edit_record_issue(Issue issue, string Ename, int Eseverity, int Elinefrom, int Elineto);
        void edit_record_comment(Comment comm, string Etext, string Eauthor, int Estatus);

        void delete_record_file(Filename filename);
        void delete_record_issue(Issue issuename);
        void delete_record_comment(Comment comm);

        Filename get_file(int i);
        Issue get_issue(Filename filename, int i);
        Comment get_comment(Issue issuename, int i);
    }
}
