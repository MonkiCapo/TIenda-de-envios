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
            
        }
        #endregion

        #region Billetera
        public void AltaBilletera(Billetera billetera)
        {

            var parametros = new DynamicParameters();
            parametros.Add("@unIDBilletera", direction: ParametersDirection.Output);
            parametros.Add("@unIDCliente", billetera.ID_Cliente);
            parametros.Add("@unID_BancoDigital", billetera.ID_BancoDigital);
            parametros.Add("Saldo", billetera.Saldo);
            try
            {
                _conexion.Execute("InsBilletera", parametros);
                bancoDigital.ID_BancoDigital = parametros.Get<byte>("@unIDBilletera");
            }
            catch (MySqlException e)
            {
                if (e.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    throw new ConstraintException("La billetera ya se encuentra instanciada. \n Duplica :" + billetera.ID_Billetera);
                }
                throw;
            }
        }
        #endregion

        #region Carrito
        public void AltaCarrito(Carrito carrito)
        {
            var parametros = new DynamicParameters();
            parametros.Add("unID_Carrito", carrito.ID_Carrito);
            parametros.Add("unID_Cliente", carrito.ID_Cliente);
            parametros.Add("unID_Billetera", carrito.ID_Billetera);
            try
            {
                _conexion.Execute("InsCarrito", parametros);
            }
            catch (MySqlConnection e)
            {
                if (e.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    throw new ConstraintException("El carrito ID" + carrito.ID_Carrito + "ya se encuentra instanciado");
                }
            }
        }
        #endregion

        #region Categoria

        public void AltaCategoria(Categoria categoria)
        {
            var parametros = new DynamicParameters();
            parametros.Add();
            var parametros = new DynamicParameters();
            parametros.Add("@unIdCategoria", direction: ParameterDirection.Output);
            parametros.Add("@unCategoria", categoria.Nombre);

            try
            {
                _conexion.Execute("InsCategoria", parametros);

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
        #endregion
        #region Comentario
        public void AltaComentario()
        {

        }
        #endregion

        #region Envio
        #endregion

        #region Cliente
        public void AltaCliente(Cliente cliente)
        {

        }
        #endregion

        #region Producto
        public void AltaProducto(Producto producto)
        {
            var parametros = new dynamicParameters();
            parametros.Add("@unID_Producto", direction: ParameterDirection.Output);
            parametros.Add("@unID_Categoria", producto.ID_Categoria);
            parametros.Add("@unNombre", producto.Nombre);
            parametros.Add("@unDescripcion", producto.Descripcion);
            parametros.Add("@unPrecio", producto.Precio);
            parametros.Add("@unStock", producto.Stock);
            parametros.Add("@Calificacion", producto.Calificacion);
            try
            {
                _conexion.Execute("InsProducto", parametros);
                producto.ID_Producto = parametros.Get<int>("@unID_Producto");
            }
            catch (MySqlException e)
            {
               if (e.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    throw new ConstraintException("Ya se encuentra el producto");
                }
                throw; 
            }
        }
        #endregion

        #region ProductoCarrito
        public void AltaProductoCarrito(ProductoCarrito productoCarrito)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@unID_Carrito", productoCarrito.ID_Carrito);
            parametros.Add("@unID_Producto", productoCarrito.ID_Producto);
            parametros.Add("@uncantidad", productoCarrito.cantidad);
            try
            {
                _conexion.Execute("InsProductoCarrito", parametros);

                categoria.ID_ProductoCarrito = parametros.Get<int>("@unID_ProductoCarrito");
            }
            catch (MySqlException e)
            {
                if (e.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    throw new ConstraintException("Ya se encuentra duplicado");
                }
                throw;
            }
        }
        #endregion


        #region HistorialProducto
        public void AltaHistorialProducto(HistorialProducto historialProducto)
        {
            var parametros = new dynamicParameters();
            parametros.Add("@unID_Cliente", historialProducto.ID_Cliente);
            parametros.Add("@un_Producto", historialProducto.ID_Producto);
            parametros.Add("@Cantidad", direction: parameterDirection.Output);
            try
            {
                _conexion.Execute("");
            }
            catch (MySqlException e)
            {
                
                if (e.ErrorCode == MySqlErrorCode.DuplicateKeyEntry)
                {
                    throw new ConstraintException("Ya se encuentra el producto en el historial");
                }
            }
        }
        #endregion
    }
}
