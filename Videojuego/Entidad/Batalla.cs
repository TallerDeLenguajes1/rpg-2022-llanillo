using static Videojuego.UtilidadJuego;

namespace Videojuego;

public class Batalla
{
    private const int CantidadTurnos = 3;
    private readonly List<Personaje> _peleadores = new List<Personaje>();

    private Personaje? _ganador = null;
    
    /*
     * Realiza la batlla más épica entre los dos peleadores recibidos
     */
    public Personaje? EjecutarBatalla(ref Personaje peleador1, ref Personaje peleador2)
    {
        _peleadores.Add(peleador1);
        _peleadores.Add(peleador2);
        
        Console.WriteLine("--- Lista de Peleadores ---\n");
        foreach(Personaje temporal in _peleadores)
        {
            Console.WriteLine("--- Peleador ---");
            temporal.MostrarCaracteristicas();
            Console.WriteLine();
        }

        Console.WriteLine("\n--- Inicio de lucha ---");
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
        
        switch (peleador1.VerSalud())
        {
            case var _ when peleador1.VerSalud() < peleador2.VerSalud():
                _ganador = peleador2;
                _peleadores.Remove(peleador1);
                break;
            case var _ when peleador1.VerSalud() > peleador2.VerSalud():
                _ganador = peleador1;
                _peleadores.Remove(peleador2);
                break;
            default:
                _ganador = null;
                break;
        }
        
        Console.WriteLine("\n--- Salud final ---");
        Console.WriteLine(peleador1.VerNombre() + " " + peleador1.VerApodo() + " - " + peleador1.VerSalud()); 
        Console.WriteLine(peleador2.VerNombre() + " " + peleador2.VerApodo() + " - " + peleador2.VerSalud() + '\n'); 
        
        if (_ganador == null)
        {
            Console.WriteLine("--- Hubo empate entre los peleadores ---");
        }
        else
        {
            _ganador.SubirNivel();
            Console.WriteLine("--- Felicidades al ganador ---");
            Console.WriteLine(_ganador.VerNombre() + " " + _ganador.VerApodo());
        }

        return _ganador;
    }

    /*
    * Muestra líneas de batallas épicas
    */
    private static void MostrarBatalla(Personaje atacante, Personaje defensor, int dano)
    {
        Console.WriteLine(atacante.VerNombre() + " " + atacante.VerApodo() 
                        + " realizó " + dano + " de daño a " + defensor.VerNombre() 
                        + " " + defensor.VerApodo());
    }

    /*
     * Devuelve el ganador de la batalla, nulo si no ha sido ejecutada
     * o si ha habido un empate
     */
    public Personaje? VerGanador()
    {
        return _ganador;
    }
    
    /*
     * Muestra los datos del ganador
     */
    public void VerDatosGanador()
    {
        if (_ganador == null) return;
        _ganador.MostrarDatos();
    }

    /*
     * Muestra las características del ganador
     */
    public void VerCaracteristicasGanador()
    {
        if (_ganador == null) return;
        _ganador.MostrarCaracteristicas();
    }
}