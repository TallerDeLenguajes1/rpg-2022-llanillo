using Videojuego;
using static Videojuego.UtilidadJuego;

public class Program
{

    private const int CantidadTurnos = 3;
    
    public static int Main(string[] args)
    {
        List<Personaje> peleadores = new List<Personaje>();

        Personaje? ganador;
        Personaje peleador1 = CrearPersonajeAleatorio();
        Personaje peleador2 = CrearPersonajeAleatorio();
        
        peleadores.Add(peleador1);
        peleadores.Add(peleador2);
        
        /*
         * Muestro las características de los peleadores
         */
        Console.WriteLine("--- Lista de Peleadores ---\n");
        foreach(Personaje temporal in peleadores)
        {
            Console.WriteLine("--- Peleador ---");
            MostrarCaracteristicas(temporal);
            Console.WriteLine();
        }
        Console.WriteLine("--- Final de lista ---\n");
        
        /*
         * Se juegan los turnos entre los peleadores
         */
        Console.WriteLine("--- Inicio de lucha ---");
        for (uint i = 0; i < CantidadTurnos * 2; i++)
        {
            if (i % 2 == 0)
            {
                MostrarBatalla(peleador1, peleador2, peleador1.AtacarPersonaje(ref peleador2));
            }
            else
            {
                MostrarBatalla(peleador2, peleador1, peleador2.AtacarPersonaje(ref peleador1));
            }
            

        }
        Console.Write("--- Fin de la lucha ---\n");
        
        /*
         * Buscamos al ganador entre los dos peleadores
         */
        switch (peleador1.ObtenerSalud())
        {
            case var _ when peleador1.ObtenerSalud() < peleador2.ObtenerSalud():
                ganador = peleador2;
                peleadores.Remove(peleador1);
                break;
            case var _ when peleador1.ObtenerSalud() > peleador2.ObtenerSalud():
                ganador = peleador1;
                peleadores.Remove(peleador2);
                break;
            default:
                ganador = null;
                break;
        }

        /*
         * Mostramos las características del ganador y lo subimos de nivel
         */
        Console.WriteLine("\n--- Salud final ---");
        Console.WriteLine(peleador1.ObtenerNombre() + " " + peleador1.ObtenerApodo() + " - " + peleador1.ObtenerSalud()); 
        Console.WriteLine(peleador2.ObtenerNombre() + " " + peleador2.ObtenerApodo() + " - " + peleador2.ObtenerSalud()); 
        Console.WriteLine();
        
        if (ganador == null)
        {
            Console.WriteLine("Hubo empate entre los peleadores");
        }
        else
        {
            ganador.SubirNivel();
            Console.WriteLine("--- Felicidades al ganador ---");
            MostrarCaracteristicas(ganador);
        }
        
        
        return 0;
    }
}


