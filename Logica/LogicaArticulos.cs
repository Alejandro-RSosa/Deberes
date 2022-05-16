using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaArticulos : ILogicaArticulo
    {
        //SINGLETON
        //1) Atributo privado
        private static LogicaArticulos _instancia = null;

        //2) Constructor privado y vacio
        private LogicaArticulos() { }

        //3) Mecanismo publico para obtener objeto
        public static LogicaArticulos GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaArticulos();
            return _instancia;
        }
        // FIN DE SINGLETON

        public void AgregarArticulo(Articulo A)
        {
            FabricaPersistencia.getPersistenciaArticulo().AgregarArticulo(A);
        }

        public void EliminarArticulo(Articulo A)
        {
            FabricaPersistencia.getPersistenciaArticulo().EliminarArticulo(A);
        }

        public void ModificarArticulo(Articulo A)
        {
            FabricaPersistencia.getPersistenciaArticulo().ModificarArticulo(A);
        }

        public Articulo BuscarArticulo(int pCodigo)
        {
            return (FabricaPersistencia.getPersistenciaArticulo().BuscarArticulo(pCodigo));
        }

        public List<Articulo> ListarArticulo()
        {
            return (FabricaPersistencia.getPersistenciaArticulo().ListarArticulo());
        }
    }
}
