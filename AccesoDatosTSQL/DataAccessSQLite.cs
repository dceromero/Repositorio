using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace AccesoDatosTSQL
{
    class DataAccessSQLite : IDataAccess
    {

        private string _cadena = string.Empty;
        private SQLiteConnection ObjConection = null;
        private SQLiteCommand ObjCommand = null;
        private SQLiteDataAdapter ObjAdap = null;
        private DataTable ObjDT = null;

      
        public DataAccessSQLite(string cadena_conexion)
        {
            _cadena = cadena_conexion;
            if (ObjConection == null)
            {
                ObjConection = new SQLiteConnection(_cadena);
            }
        }

        public void ClosedConection()
        {
            ObjConection.Close();
        }

        public void Dispose()
        {
            ObjConection.Close();
        }

        public DataTable ExecDataTable()
        {
            if (ObjAdap == null)
            {
                ObjAdap = new SQLiteDataAdapter();
            }
            if (ObjDT == null)
            {
                ObjDT = new DataTable();
            }
            ObjAdap.SelectCommand = ObjCommand;
            ObjAdap.Fill(ObjDT);
            return ObjDT;
        }

        public int ExecQuery()
        {
            ObjCommand.CommandType = CommandType.Text;
            return ObjCommand.ExecuteNonQuery();
        }

        public void OpenConection()
        {
            ObjConection.Open();
        }

        public void Parameters(string NameParameter, object Control)
        {
            ObjCommand.Parameters.AddWithValue(NameParameter, Control);
        }

        public void QuerySQL(string Consuta)
        {
            if (ObjCommand == null)
            {
                ObjCommand = new SQLiteCommand();
            }
            ObjCommand.Connection = ObjConection;
            ObjCommand.CommandText = Consuta;
        }
    }
}
