using Videojuego.Entidad;
using Videojuego.ManejoArchivo;
using static Videojuego.Utilidad.UtilidadJuego;

namespace Videojuego;

public static class Program
{
    private static string Path = @"C:\UNT\rpg-2022-llanillo";
    
    public static int Main(string[] args)
    {
        var peleador1 = CrearPersonajeAleatorio();
        var peleador2 = CrearPersonajeAleatorio();

        var batalla = new Batalla();
        var ganador = batalla.EjecutarBatalla(ref peleador1, ref peleador2);

        var auxiliarCsv = new AuxiliarCsv(Path);
        auxiliarCsv.IniciarArchivo();
        auxiliarCsv.EscribirLinea(ganador?.VerNombre());
        auxiliarCsv.EscribirLinea(ganador?.VerApodo());
        auxiliarCsv.EscribirNuevaLinea(ganador?.Caracteristicas.Edad.ToString());

        Console.WriteLine("¿Desea ver los ganadores anteriores? (0 - Sí, 1 - No)");
        var opcion = Console.ReadLine();
        
        switch (opcion?.ToLower())
        {
            case "0":
                auxiliarCsv.LeerArchivo();
                break;
            default:
                Console.WriteLine("No escogió ninguna opción");
                break;
        }
        
        return 0;
    }
}


