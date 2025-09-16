using EspacioCadete;
using EspacioPedido;
namespace EspacioCadeteria
{
    public class Cadeteria
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public List<Cadete> ListadoCadetes { get; set; } = new List<Cadete>();
        public List<Pedido> ListadoPedidos { get; set; } = new List<Pedido>();

        public Cadeteria(string nombreInsertar, string telefonoInsertar)
        {
            this.Nombre = nombreInsertar;
            this.Telefono = telefonoInsertar;
        }
        public Cadeteria() { }

        public string ObtenerNombreCadeteria()
        {
            return Nombre;
        }
        public string ObtenerTelefonoCadeteria()
        {
            return Telefono;
        }

        // public void AgregarALista(Cadete agregar)
        // {
        //     ListadoCadetes.Add(agregar);
        // }
        public void AgregarALista(int ID_ingresar, string nombre_ingresar, string direccion_ingresar, string telefono_ingresar)
        {
            Cadete agregar = new Cadete(ID_ingresar, nombre_ingresar, direccion_ingresar, telefono_ingresar);
            ListadoCadetes.Add(agregar);
        }

        public float JornalACobrar(int IDcadete)
        {
            float retorno = 0;
            foreach (Pedido pedido in ListadoPedidos)
            {
                if (pedido.Cadete.ObtenerIDCadete() == IDcadete && pedido.ObtenerEstado() == true)
                {
                    retorno += 500;
                }
            }
            return (retorno);
        }
        public void AsignarCadeteAPedido(int IDcadete, int NroPedido)
        {
            Cadete cadeteaux = null;
            foreach (Cadete cadete in ListadoCadetes)
            {
                if (cadete.ObtenerIDCadete() == IDcadete)
                {
                    cadeteaux = cadete;
                }
            }
            //bool pedidoEncontrado = false;
            if (cadeteaux != null)
            {
                foreach (Pedido pedido in ListadoPedidos)
                {
                    if (pedido.ObtenerNro() == NroPedido)
                    {
                        pedido.Cadete = cadeteaux;
                        //pedidoEncontrado = true;
                    }
                }
            }
            // if (pedidoEncontrado == false)
            // {
            //     Console.WriteLine("EL ID DEL CADETE ES INCORRECTO O EL NUMERO DE PEDIDO ES INCORRECTO");
            // }
            // else
            // {
            //     Console.WriteLine("EL CADETE FUE ASIGNADO CORRECTAMENTE AL PEDIDO");
            // }
        }
        public int EnviosRealizados(int Idcadete)
        {
            int pedidos = 0;
            foreach (Pedido pedido in ListadoPedidos)
            {
                if (pedido.Cadete.ObtenerIDCadete() == Idcadete)
                {
                    pedidos++;
                }
            }
            return (pedidos);
        }
        public void GenerarInforme()
        {
            int EnviosTotales = 0;
            float GananciaTotal = 0;
            float ContCadetes = 0;
            foreach (Cadete cadete in ListadoCadetes)
            {
                float jornal = JornalACobrar(cadete.ObtenerIDCadete());
                Console.WriteLine($"NOMBRE DEL CADETE : {cadete.ObtenerNombreCadete()}");
                Console.WriteLine($"Jornal a cobrar : {jornal}");
                Console.WriteLine($"Pedidos realizados : {EnviosRealizados(cadete.ObtenerIDCadete())}");
                Console.WriteLine("\n");
                EnviosTotales += EnviosRealizados(cadete.ObtenerIDCadete());
                GananciaTotal += jornal;
                ContCadetes += 1;
            }
            Console.WriteLine("\n");
            Console.WriteLine($"ENVIOS TOTALES REALIZADOS POR EL SERVICIO DE CADETERIA : {EnviosTotales}");
            Console.WriteLine($"GANANCIA TOTAL DEL SERVICIO DE CADETERIA : {GananciaTotal}");
            Console.WriteLine($"PROMEDIO DE ENVIOS POR CADETE : {EnviosTotales/ContCadetes}");
        }
    }
}