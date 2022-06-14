using System.Collections;
using Videojuego.Entidad;
using Videojuego.ManejoArchivo;
using static Videojuego.Utilidad.UtilidadJuego;

namespace Videojuego;

public static class Program
{
    private static string Path = @"C:\UNT\rpg-2022";
    private const int CantidadPeleadores = 5;

    public static int Main(string[] args)
    {
        var peleadores = new List<Personaje>();
        var batalla = new Batalla();
        
        for (var i = 0; i < CantidadPeleadores; i++)
        {
            var peleador = CrearPersonajeAleatorio();
            peleadores.Add(peleador);
        }

        batalla.AgregarPeleador(peleadores);

        for (var i = 0; i < CantidadPeleadores; i++)
        {
            var ganador = batalla.IniciarSiguienteBatalla();

            if (ganador != null)
                VerArchivoGanadores(ganador.VerNombre(), ganador.VerApodo(), ganador.Caracteristicas.Edad); 
        }
        
        VerGanadoresAnteriores();
        
        return 0;
    }

    private static void VerArchivoGanadores(string nombre, string apodo, int edad)
    {
        var auxiliarCsv = new AuxiliarCsv(Path);
        auxiliarCsv.IniciarArchivo();
        auxiliarCsv.EscribirLinea(nombre);
        auxiliarCsv.EscribirLinea(apodo);
        auxiliarCsv.EscribirNuevaLinea(edad.ToString());
    }

    private static void VerGanadoresAnteriores()
    {
        Console.WriteLine("¿Desea ver los ganadores anteriores? (0 - Sí, 1 - No)");
        var opcion = Console.ReadLine();
        
        switch (opcion?.ToLower())
        {
            case "0":
                var auxiliarCsv = new AuxiliarCsv(Path);
                auxiliarCsv.LeerArchivo();
                break;
            default:
                Console.WriteLine("No escogió ninguna opción");
                break;
        }
    }
}


