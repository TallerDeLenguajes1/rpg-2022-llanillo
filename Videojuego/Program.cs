using Videojuego.Entidad;
using static Videojuego.Utilidad.UtilidadJuego;
using static Videojuego.Utilidad.UtilidadCsv;

namespace Videojuego;

public static class Program
{
    private const int CantidadPeleadores = 5;

    public static int Main(string[] args)
    {
        Console.WriteLine("Ingrese el path donde se guardarán todos los archivos");
        var path = Console.ReadLine() ?? string.Empty;
        
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
            batalla.IniciarSiguienteBatalla();
        }

        var ganador = batalla.VerGanador();
        
        if(ganador != null)
            EscribirGanadorEnCsv(path, ganador.VerNombre(), ganador.VerApodo(), ganador.VerEdad());
        
        VerGanadoresEnCsv(path);
        
        return 0;
    }
}


