using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace AccesoDatosTSQL
{
    public class DataAccessSQL : IDataAccess
    {
        private string _cadena = string.Empty;
        private SqlConnection ObjConection = null;
        private SqlCommand ObjCommand = null;
        private SqlDataAdapter ObjAdap = null;
        private DataTable ObjDT = null;

   

        public DataAccessSQL(string cadena_conexion)
        {
            _cadena = cadena_conexion;
            if (ObjConection == null)
            {
                ObjConection = new SqlConnection(_cadena);
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
                ObjAdap = new SqlDataAdapter();
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
                ObjCommand = new SqlCommand();
            }
            ObjCommand.Connection = ObjConection;
            ObjCommand.CommandText = Consuta;
        }
    }
}
