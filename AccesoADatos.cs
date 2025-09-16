using EspacioCadeteria;
using EspacioCadete;
using System.Text.Json.Nodes;
using System.Text.Json;
namespace AccesoADatos
{
    public interface IAccesoADatos
    {
        Cadeteria LeerArchivo();
    }
    public class AccesoADatosJSON : IAccesoADatos
    {
        public Cadeteria LeerArchivo()
        {
            Console.WriteLine("INGRESE EL NOMBRE DE LA CADETERIA: ");
            string cadeteria_nombre = Console.ReadLine();
            Console.WriteLine("INGRESE EL NUMERO DE TELEFONO DE LA CADETERIA");
            string cadeteria_numero = Console.ReadLine();

            Cadeteria servicio_cadeteria = new Cadeteria(cadeteria_nombre,cadeteria_numero);

            FileInfo info_json = new FileInfo("datosCadeteria.json");
            string ruta_json = info_json.FullName; //LEO EL PATH DEL JSON

            string json_string = File.ReadAllText(ruta_json);
            List<Cadete> listadoCadetes = new List<Cadete>();
            listadoCadetes = JsonSerializer.Deserialize<List<Cadete>>(json_string);

            servicio_cadeteria.ListadoCadetes = listadoCadetes;

            return (servicio_cadeteria);
        }
    }
    public class AccesoADatosCSV : IAccesoADatos
    {
        public Cadeteria LeerArchivo()
        {
            FileInfo info_csv = new FileInfo("datosCadeteria.csv");
            string ruta_csv = info_csv.FullName; //LEO EL PATH DEL CSV

            StreamReader reader = new StreamReader(ruta_csv); //CREO EL STRAMREADER DEL CSV
            string linea = reader.ReadLine();
            string[] campos = linea.Split(';');

            Cadeteria servicio_cadeteria = new Cadeteria(campos[0], campos[1]); //ASIGNO LOS DATOS DE LA CADETERIA

            linea = reader.ReadLine(); //VUELVO A LEER PARA POSICIONARME EN EL PRIMER CADETE
            campos = linea.Split(';');
            
            while (linea != null) //LEO HASTA QUE LLEGUE AL FINAL DEL CSV
            {
                Cadete cadete_nuevo = new Cadete(int.Parse(campos[0]), campos[1], campos[2], campos[3]); 
                servicio_cadeteria.AgregarALista(cadete_nuevo.ObtenerIDCadete(), cadete_nuevo.ObtenerNombreCadete(), cadete_nuevo.ObtenerDireccionCadete(), cadete_nuevo.ObtenerTelefonoCadete()); //ASIGNO A LA LISTA DE CADETES DE LA CADETERIA
                linea = reader.ReadLine();
                if (linea != null)
                {
                    campos = linea.Split(';');
                }
            }
            reader.Close();
            return (servicio_cadeteria);
        }
    }
}