using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class ListadoFacturas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //la variable referencia para guardar el objeto que me fabrico la logica, debe ser del tipo interface 
            //(porque no veo la clase de trabajo y porque el objeto lo devolvi en nombre de la interface)

            ILogicaFactura fabrica = FabricaLogica.getLogicaFactura();

            //puedo usar al objeto, solo con lo que me expone publicamente la interface, el resto del contenido que pueda tener el objeto NO LO SE

            List<Factura> _lista = fabrica.ListarFactura();
            gvListadoFac.DataSource = _lista;
            gvListadoFac.DataBind();
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}