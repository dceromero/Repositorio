using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace AccesoDatosTSQL
{
    public class DataAccessMysql: IDataAccess
    {
        private string _cadena = string.Empty;
        private MySqlConnection ObjConection = null;
        private MySqlCommand ObjCommand = null;
        private MySqlDataAdapter ObjAdap = null;
        private DataTable ObjDT = null;

    
        public DataAccessMysql(string cadena_conexion)
        {
            _cadena = cadena_conexion;
            if (ObjConection == null)
            {
                ObjConection = new MySqlConnection(_cadena);
            }
        }

        public void OpenConection()
        {
                ObjConection.OpenAsync();
        }

        public void ClosedConection()
        {
            ObjConection.Close();
        }

        public void QuerySQL(String Consuta)
        {
            if (ObjCommand == null) {
                ObjCommand = new MySqlCommand();
            }
            ObjCommand.Connection = ObjConection;
            ObjCommand.CommandText = Consuta;
        }

        public int ExecQuery() {
            ObjCommand.CommandType = CommandType.Text;
            return ObjCommand.ExecuteNonQuery();
        }

        public DataTable ExecDataTable() {
            if (ObjAdap == null) {
                ObjAdap = new MySqlDataAdapter();
            }
            if (ObjDT == null) {
                ObjDT = new DataTable();
            }
            ObjAdap.SelectCommand = ObjCommand;            
            ObjAdap.Fill(ObjDT);
            return ObjDT;
        }

        public void Parameters(string NameParameter, object Control) => ObjCommand.Parameters.AddWithValue(NameParameter, Control);

        public void Dispose()
        {
            ObjConection.Close();
        }
    }
}
