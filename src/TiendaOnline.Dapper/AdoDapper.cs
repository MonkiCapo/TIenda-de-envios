using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using TiendaOnline.Core;

namespace TiendaOnline.Dapper
{
    public class AdoDapper : IAdo
    {
        private readonly IDbConnection _conexion;
        public AdoDapper(IDbConnection conexion) => this._conexion = conexion;
        public AdoDapper(string cadena) => _conexion = (new MySqlConnection(cadena));

        #region BancoDigital

            private static readonly string _query

        #endregion

    }
}