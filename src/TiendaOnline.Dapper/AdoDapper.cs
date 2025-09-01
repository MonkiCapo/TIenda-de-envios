using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        #endregion
        public void AltaBancoDigital(BancoDigital bancoDigital)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@unIdBancoDigital", direction: ParameterDirection.Output);
            parametros.Add("@unNombre", bancoDigital.Nombre);
            parametros.Add("@unTipo", bancoDigital.Tipo);
            try
            {
                _conexion.Execute("AltaBancoDigital", parametros);
                bancoDigital.ID_BancoDigital = parametros.Get<byte>("@unIdBancoDigital");
            }
            catch (MySqlException e)
            {
                if (e.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    throw new ConstraintException(bancoDigital.Nombre + " ya se encuentra en uso.");
                }
                throw;
            }

            IEnumerable<BancoDigital> ObtenerBancosDigitales()
            {
  
                string query = "SELECT * FROM BancoDigital"; 

                return _conexion.Query<BancoDigital>(query);
            }
        }
        public void AltaCliente(Cliente cliente)
        {

        }
        public void AltaBilletera(Billetera billetera)
        {

        }
        public void AltaProducto(Producto producto)
        {

        }
        public void AltaCarrito(Carrito carrito)
        {

        }
        public void AltaProductoCarrito(ProductoCarrito productoCarrito)
        {

        }

        #region Categoria

        public void AltaCategoria(Categoria categoria)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@unIdCategoria", direction: ParameterDirection.Output);
            parametros.Add("@unCategoria", categoria.Nombre);

            try
            {
                _conexion.Execute("AltaCategoria", parametros);

                categoria.ID_Categoria = parametros.Get<byte>("@unIdCategoria");
            }
            catch (MySqlException e)
            {
                if (e.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    throw new ConstraintException(categoria.Nombre + " ya se encuentra en uso.");
                }
                throw;
            }
        }
    }
    #endregion

    #region Cliente
    #endregion

    #region Billetera
    #endregion

    #region Carrito
    #endregion

    #region Comentario
    #endregion

    #region Envio
    #endregion

    #region Cliente
    #endregion

    #region Producto
    #endregion

    #region ProductoCarrito
    #endregion


    #region HistorialProducto
    #endregion

    }
