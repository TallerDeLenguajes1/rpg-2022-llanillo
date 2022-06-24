using Videojuego.ManejoArchivo;
using static Videojuego.Utilidad.UtilidadPath;

namespace Videojuego.Utilidad;

public static class UtilidadCsv
{
    private const string NombreArchivo = "ganadores.csv";
    
    private const string Titulo = "--- Ganadores ---";
    private const string PrimeraColumna = "Nombre";
    private const string SegundaColumna = "Apodo";
    private const string TerceraColumna = "Edad";
    
    /*
     * Escribe los datos de un ganador en un archivo CSV
     */
    public static void EscribirGanadorEnCsv(string nombre, string apodo, int edad)
    {
        string pathActual = VerPathProyecto();
        var auxiliarCsv = new AuxiliarCsv(pathActual, NombreArchivo);
        auxiliarCsv.IniciarArchivo(Titulo, PrimeraColumna, SegundaColumna, TerceraColumna);
        auxiliarCsv.EscribirLinea(nombre);
        auxiliarCsv.EscribirLinea(apodo);
        auxiliarCsv.EscribirNuevaLinea(edad.ToString());
    }
    
    /*
     * Lee los ganadores de un archivo CSV
     */
    public static void VerGanadoresEnCsv()
    {
        Console.WriteLine("¿Desea ver los ganadores anteriores? (0 - Sí, 1 - No)");
        var opcion = Console.ReadLine();
        
        switch (opcion?.ToLower())
        {
            case "0":
                string pathActual = VerPathProyecto();
                var auxiliarCsv = new AuxiliarCsv(pathActual, NombreArchivo);
                auxiliarCsv.LeerArchivo();
                break;
            default:
                Console.WriteLine("No escogió ninguna opción");
                break;
        }
    }
}