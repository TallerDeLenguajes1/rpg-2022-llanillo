using System.Collections;

namespace Videojuego.Entidad;

public class Batalla
{
    private const int CantidadTurnos = 3;
    private readonly Queue<Personaje> _peleadores = new();

    private Personaje? _ganador;

    /*
     * Agrega un peleador a la lista de futuros peleadores
     */
    public void AgregarPeleador(Personaje peleador)
    {
        _peleadores.Enqueue(peleador);
    }

    /*
     * Agrega una lista de peleadores a la batalla
     */
    public void AgregarPeleadores(IEnumerable<Personaje> lista)
    {
        foreach (var peleador in lista)
        {
            _peleadores.Enqueue(peleador);
        }
    }
    
    /*
     * Realiza la batlla más épica entre los dos siguientes peleadores,
     * si no hay suficientes peleadores, devuelve el último ganador
     */
    public Personaje? IniciarSiguienteBatalla()
    {
        if (_peleadores.Count <= 1) return _ganador;
        
        Personaje peleador1 = _peleadores.Dequeue();
        Personaje peleador2 = _peleadores.Dequeue();
        
        Console.WriteLine("--- Peleadores del round ---\n" +
                          peleador1.VerCaracteristicas() +
                          '\n' +
                          peleador2.VerCaracteristicas());
        
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
        
        _ganador = peleador1.VerSalud() switch
        {
            _ when peleador1.VerSalud() < peleador2.VerSalud() => peleador2,
            _ when peleador1.VerSalud() > peleador2.VerSalud() => peleador1,
            _ => null
        };

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
            _peleadores.Enqueue(_ganador);

            Console.WriteLine("--- Felicidades al ganador ---");
            Console.WriteLine(_ganador.VerNombre() + " " + _ganador.VerApodo() + '\n');
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
    public string? VerDatosGanador()
    {
        return _ganador?.VerDatos();
    }

    /*
     * Muestra las características del ganador
     */
    public string? VerCaracteristicasGanador()
    {
        return _ganador?.VerCaracteristicas();
    }
}