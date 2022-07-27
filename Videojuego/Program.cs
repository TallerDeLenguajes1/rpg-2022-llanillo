using Videojuego.Entidad;
using static Videojuego.Conexion.ServicioGenshin;
using static Videojuego.Utilidad.UtilidadJuego;
using static Videojuego.Utilidad.UtilidadCsv;
using static Videojuego.Utilidad.UtilidadJson;

namespace Videojuego;

public static class Program
{
    private const int CantidadPeleadores = 2;

    public static int Main(string[] args)
    {
        List<string>? resultadoApi = VerResultadosApi();
        
        var peleadores = new List<Personaje>();
        var batalla = new Batalla();
        
        Console.WriteLine("\n¿Desea generar aleatoriamente los personaes o cargarlos desde el JSON? (0 - Aleatorio, 1 - JSON)");
        
        if (int.Parse(Console.ReadLine()) == 0)
        {
            CrearPersonajesIniciales(resultadoApi, peleadores);
        }
        else
        {
            try
            {
                peleadores = CargarPersonajesDeJson();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nError: No se consiguió un archivo JSON de jugadores, se procederá a crear aleatorios\n");
                CrearPersonajesIniciales(resultadoApi, peleadores);
            }
        }

        batalla.AgregarPeleadores(peleadores);
        EscribirPersonajesEnJson(peleadores);

        for (var i = 0; i < CantidadPeleadores; i++)
        {
            batalla.IniciarSiguienteBatalla();
        }

        var ganador = batalla.VerGanador();

        if (ganador != null)
        {
            Console.Write(ganador.VerCaracteristicas());
            EscribirGanadorEnCsv(ganador.VerNombre(), ganador.VerApodo(), ganador.VerEdad());
        }
        
        VerGanadoresEnCsv();
        
        return 0;
    }

    private static void CrearPersonajesIniciales(List<string>? resultadoApi, List<Personaje> peleadores)
    {
        for (var i = 0; i < CantidadPeleadores; i++)
        {
            var nombreAleatorio = resultadoApi?[new Random().Next(resultadoApi.Count)] ?? string.Empty;
            var peleador = CrearPersonajeAleatorio(nombreAleatorio);
            peleadores.Add(peleador);
        }
    }
}


