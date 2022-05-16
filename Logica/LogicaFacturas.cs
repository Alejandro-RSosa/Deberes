using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaFacturas : ILogicaFactura
    {

        //SINGLETON
        //1) Atributo privado
        private static LogicaFacturas _instancia = null;

        //2) Constructor privado y vacio
        private LogicaFacturas() { }

        //3) Mecanismo publico para obtener objeto
        public static LogicaFacturas GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaFacturas();
            return _instancia;
        }
        // FIN DE SINGLETON


        public void AgregarFactura(Factura F)
        {
            FabricaPersistencia.getPersistenciaFactura().AgregarFactura(F);
        }

        public List<Factura> ListarFactura()
        {
            return FabricaPersistencia.getPersistenciaFactura().ListarFactura();
        }
    }
}
