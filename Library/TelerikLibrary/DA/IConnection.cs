using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikLibrary.DA
{
    public interface IConnection
    {
        SQLiteConnection Connect();
        void Disconnect(SQLiteConnection connection);
        void ExecuteQuery(string sqlQuery);
        DataTable LoadData(string sql);
    }
}
