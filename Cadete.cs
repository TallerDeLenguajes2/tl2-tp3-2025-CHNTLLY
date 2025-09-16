namespace EspacioCadete
{
    public class Cadete
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Cadete(int ID_ingresar, string nombre_ingresar, string direccion_ingresar, string telefono_ingresar)
        {
            this.Id = ID_ingresar;
            this.Nombre = nombre_ingresar;
            this.Direccion = direccion_ingresar;
            this.Telefono = telefono_ingresar;
        }
        public Cadete() { }
        public int ObtenerIDCadete()
        {
            return Id;
        }
        public string ObtenerNombreCadete()
        {
            return Nombre;
        }
        public string ObtenerDireccionCadete()
        {
            return Direccion;
        }
        public string ObtenerTelefonoCadete()
        {
            return Telefono;
        }
    }
}