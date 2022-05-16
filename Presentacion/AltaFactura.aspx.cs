using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class AltaFactura : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
            lblError.Text = "";
        else
            LimpioForm();
    }

    private void LimpioForm()
    {
        txtCantidad.Text = "";
        txtCodArt.Text = "";
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        int cant, codArt;
        Articulo _unArticulo = null;
        try
        {
            cant = Convert.ToInt32(txtCantidad.Text.Trim());
            codArt = Convert.ToInt32(txtCodArt.Text.Trim());

            if (cant <= 0 && codArt <= 0)
                throw new Exception(" Ninguno de los campos puede ser 0 o negativo");
            else
            {
                Factura _fact = null;
                _unArticulo = FabricaLogica.getLogicaArticulo().BuscarArticulo(codArt);
                _fact = new Factura(0, DateTime.Now, cant, _unArticulo);
                FabricaLogica.getLogicaFactura().AgregarFactura(_fact);
                lblError.Text = "Alta con exito";
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}