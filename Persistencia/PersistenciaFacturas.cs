using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaFacturas : IPersistenciaFactura
    {
        private static PersistenciaFacturas _instancia = null;

        private PersistenciaFacturas() { }

        public static PersistenciaFacturas GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaFacturas();
            return _instancia;
        }


        public void AgregarFactura(Factura F)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaFactura", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _cantidad = new SqlParameter("@cant", F.Cantidad);
            SqlParameter _codArt = new SqlParameter("@codA", F.ArticuloF.Codigo);            
            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            int oAfectados = -1;

            oComando.Parameters.Add(_cantidad);
            oComando.Parameters.Add(_codArt);            
            oComando.Parameters.Add(_Retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("El articulo no existe");
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public List<Factura> ListarFactura()
        {
            int _codigoF;
            DateTime _fecha;
            int _cantidad;
            int _codArt;
            Articulo _articuloF;
            List<Factura> _Lista = new List<Factura>();
            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("Exec ListarFacturas", _Conexion);
            SqlDataReader _Reader;

            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();
                while (_Reader.Read())
                {
                    _codigoF = (int)_Reader["CodFac"];
                    _fecha = Convert.ToDateTime(_Reader["FechaFac"]);
                    _cantidad = (int)_Reader["CantFac"];
                    _codArt = (int)_Reader["CodArt"];
                    _articuloF = FabricaPersistencia.getPersistenciaArticulo().BuscarArticulo(_codArt);
                    Factura f = new Factura(_codigoF, _fecha, _cantidad, _articuloF);
                    _Lista.Add(f);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Problemas con la base de datos:" + ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }
            return _Lista;
        }
    }
}
