namespace Videojuego.Entidad;

public class Batalla
{
    private const int CantidadTurnos = 3;
    private const int MaximoPorcentaje = 100;
    
    private readonly Queue<Personaje> _peleadores = new();
    private Personaje? _ganador;

    /*
     * Agrega una lista de peleadores a la batalla
     */
    public void AgregarPeleadores(List<Personaje> lista)
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
        
        var peleador1 = _peleadores.Dequeue();
        var peleador2 = _peleadores.Dequeue();
        
        Console.WriteLine("--- Peleadores del round ---\n" +
                          peleador1.VerCaracteristicas() +
                          '\n' +
                          peleador2.VerCaracteristicas());
        
        Console.WriteLine("--- Inicio de lucha ---");
        for (uint i = 0; i < CantidadTurnos * 2; i++)
        {
            string? resultado = null;

            resultado = i % 2 == 0
                ? MostrarBatalla(peleador1, peleador2, AtacarPersonaje(ref peleador1, ref peleador2))
                : MostrarBatalla(peleador2, peleador1, AtacarPersonaje(ref peleador2, ref peleador1));

            Console.WriteLine(resultado);
        }
        
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
            _ganador.SubirDeNivel();
            _peleadores.Enqueue(_ganador);

            Console.WriteLine("--- Felicidades al ganador ---");
            Console.WriteLine(_ganador.VerNombre() + " " + _ganador.VerApodo() + '\n');
        }

        return _ganador;
    }

    /*
     * Devuelve el daño efectuado por el peleador 1 al peleador 2, la vida del
     * segundo peleador se actualiza en su referencia original
     * 
     */
    private int AtacarPersonaje(ref Personaje peleador1, ref Personaje peleador2)
    {
        int efectividadDisparo = new Random().Next(Personaje.MaximaEfectividadDisparo);
        double valorAtaque = peleador1.VerPoderAtaque() * efectividadDisparo;
        var danoProvocado = CalcularDano(valorAtaque, peleador2.VerPoderDefensa(), Personaje.MaximoDanoProvocable, MaximoPorcentaje);
        
        peleador2.ReducirSalud(danoProvocado);

        return danoProvocado;
    }

    /*
     * Devuelve la cantidad de daño efectuado por el ataque
     */
    private int CalcularDano(double ataque, double defensa, int maximoDano, int maximoPorcentaje)
    {
        return (int)((ataque - defensa) / maximoDano * maximoPorcentaje);
    }
    
    /*
    * Muestra líneas de batallas épicas
    */
    private static string MostrarBatalla(Personaje atacante1, Personaje atacante2, int dano)
    {
        return atacante1.VerNombre() + " " + atacante1.VerApodo() 
                        + " realizó " + dano + " de daño a " + atacante2.VerNombre() 
                        + " " + atacante2.VerApodo();
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