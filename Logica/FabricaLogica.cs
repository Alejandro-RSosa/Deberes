using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class FabricaLogica
    {
        // ponemos la interfaz de devolucion para que enmascare.
        public static ILogicaArticulo getLogicaArticulo()
        {
            return (LogicaArticulos.GetInstancia());
        }
    }
}
