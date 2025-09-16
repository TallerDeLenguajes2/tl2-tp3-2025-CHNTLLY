namespace EspacioCliente
{
    public class Cliente
    {
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string datosReferenciaDireccion { get; set; }

        public Cliente(string nombreCliente, string direccionCliente, string telefonoCliente, string datosRefCliente)
        {
            this.nombre = nombreCliente;
            this.direccion = direccionCliente;
            this.telefono = telefonoCliente;
            this.datosReferenciaDireccion = datosRefCliente;
        }
        public string obtenerDireccionCLiente()
        {
            return direccion;
        }
        public string obtenerRefCLiente()
        {
            return datosReferenciaDireccion;
        }
    }
}