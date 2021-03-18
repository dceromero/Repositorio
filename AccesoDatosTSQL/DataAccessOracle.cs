using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace AccesoDatosTSQL
{
   
    class DataAccessOracle : IDataAccess
    {

        private string _cadena = string.Empty;
        private OracleConnection ObjConection = null;
        private OracleCommand ObjCommand = null;
        private OracleDataAdapter ObjAdap = null;
        private DataTable ObjDT = null;


        public DataAccessOracle(string cadena_conexion)
        {
            _cadena = cadena_conexion;
            if (ObjConection == null)
            {
                ObjConection = new OracleConnection(_cadena);
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
                ObjAdap = new OracleDataAdapter();
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

        public void Parameters(string NameParameter, object Control) => ObjCommand.Parameters.Add(NameParameter, Control);

        public void QuerySQL(string Consuta)
        {
            if (ObjCommand == null)
            {
                ObjCommand = new OracleCommand();
            }
            ObjCommand.Connection = ObjConection;
            ObjCommand.CommandText = Consuta;
        }
    }
}
