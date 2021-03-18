using System;
using System.Data;

namespace AccesoDatosTSQL
{
    public interface IDataAccess : IDisposable
    {


        void OpenConection();

        void ClosedConection();

        void QuerySQL(String Consuta);

        int ExecQuery();

        DataTable ExecDataTable();

        void Parameters(string NameParameter, object Control);
    }
}
