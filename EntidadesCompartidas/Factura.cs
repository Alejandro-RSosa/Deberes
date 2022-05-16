using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Factura
    {
        //atributos
        private int _codigoF;
        private DateTime _fecha;
        private int _cantidad;
        Articulo _articuloF;

        //propiedades
        public int CodigoF
        {
            get { return _codigoF; }
            set { _codigoF = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("La cantidad debe ser mayor a 0");
                }
                _cantidad = value;
            }
        }
        public Articulo ArticuloF
        {
            get { return _articuloF; }
            set
            {
                if (value == null)
                {
                    throw new Exception("El articulo no puede ser nulo");
                }
                _articuloF = value;
            }
        }


        //Contructor
        public Factura(int pCodigoF, DateTime pFechaF, int pCantidad, Articulo pArticuloF)
        {
            CodigoF = pCodigoF;
            Fecha = pFechaF;
            Cantidad = pCantidad;
            ArticuloF = pArticuloF;
        }
    }
}
