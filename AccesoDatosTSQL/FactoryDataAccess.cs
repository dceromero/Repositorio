using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosTSQL
{
    public  class FactoryDataAccess
    {
        /// <summary>
        /// Tipo 1 : SQLSERVER
        /// Tipo 2 : MySQL
        /// Tipo 3 : Oracle
        /// Tipo 4 : SQLite
        /// </summary>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        public static IDataAccess CreatorDataAcces(int Tipo, string Cadena_Conexion)
        {
            switch (Tipo)
            {
                case 1:
                    return new DataAccessSQL(Cadena_Conexion);
                case 2:
                    return new DataAccessMysql(Cadena_Conexion);
                case 3:
                    return new DataAccessOracle(Cadena_Conexion);
                case 4:
                    return new DataAccessSQLite(Cadena_Conexion);
                default:
                    return null;
            }
        }
    }
}
