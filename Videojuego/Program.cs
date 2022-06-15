using Videojuego.Entidad;
using Videojuego.Utilidad;
using static Videojuego.Utilidad.UtilidadJuego;
using static Videojuego.Utilidad.UtilidadCsv;
using static Videojuego.Utilidad.UtilidadJson;

namespace Videojuego;

public static class Program
{
    private const int CantidadPeleadores = 5;

    public static int Main(string[] args)
    {
        var peleadores = new List<Personaje>();
        var batalla = new Batalla();
        
        Console.WriteLine("Ingrese el path donde se guardarán/cargaran todos los archivos");
        var path = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("¿Desea generar aleatoriamente los personaes o cargarlos desde un JSON? (0 - Aleatorio, 1 - JSON)");
        
        if (int.Parse(Console.ReadLine()) == 0)
        {
            for (var i = 0; i < CantidadPeleadores; i++)
            {
                var peleador = CrearPersonajeAleatorio();
                peleadores.Add(peleador);
            }
        }
        else
        {
            peleadores = CargarPersonajesDeJson(path);
        }

        batalla.AgregarPeleadores(peleadores);
        EscribirPersonajesEnJson(path, peleadores);

        for (var i = 0; i < CantidadPeleadores; i++)
        {
            batalla.IniciarSiguienteBatalla();
        }

        var ganador = batalla.VerGanador();
        
        if(ganador != null)
            EscribirGanadorEnCsv(path, ganador.VerNombre(), ganador.VerApodo(), ganador.VerEdad());
        
        VerGanadoresEnCsv(path);
        
        return 0;
    }
}


