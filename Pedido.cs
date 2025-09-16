using EspacioCliente;
using EspacioCadete;
namespace EspacioPedido
{
    public class Pedido
    {
        private int numero;
        private string observacion;
        public Cliente cliente { get; set; }
        private bool estado;
        private Cadete cadete;

        public Cadete Cadete
        {
            get => cadete;
            set => cadete = value;
        }

        public Pedido(string nroPedido, string observaciones, string nombreClientePedido, string direccionClientePedido, string telefonoClientePedido, string datosRefPedido, int IdCadetePedido, string nombreCadetePedido, string direccionCadetePedido, string telefonoCadetePedido)
        {
            numero = int.Parse(nroPedido);
            observacion = observaciones;

            cliente.nombre = nombreClientePedido;
            cliente.direccion = direccionClientePedido;
            cliente.telefono = telefonoClientePedido;
            cliente.datosReferenciaDireccion = datosRefPedido;
            estado = false;

            cadete.Id = IdCadetePedido;
            cadete.Nombre = nombreCadetePedido;
            cadete.Direccion = direccionCadetePedido;
            cadete.Telefono = telefonoCadetePedido;
        }


        public string VerDireccionCliente()
        {
            return cliente.obtenerDireccionCLiente();
        }
        public string VerDatosCliente()
        {
            return cliente.obtenerRefCLiente();
        }
        public int ObtenerNro()
        {
            return numero;
        }
        public bool ObtenerEstado()
        {
            return estado;
        }
        public void ModificarEstado()
        {
            if (estado == false)
            {
                estado = true;
                //Console.WriteLine("Estado cambiado a: ENTREGADO");
            }
            else
            {
                estado = false;
                //Console.WriteLine("Estado cambiado a: NO ENTREGADO");
            }
        }
    }
}