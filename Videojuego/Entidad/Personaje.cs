namespace Videojuego;

public class Personaje{

    private const int MaximoDanoProvocable = 50000;
    private const int MaximaEfectividadDisparo = 101;
    
    private const int Porcentaje = 100;

    private const int AumentoSalud = 10;
    
    public Caracteristicas Caracteristicas => _caracteristicas;
    private Caracteristicas _caracteristicas;
    
    public Datos Datos => _datos;
    private Datos _datos;
    
    public Personaje(Datos datos, Caracteristicas caracteristicas)
    {
        _datos = datos;
        _caracteristicas = caracteristicas;
    }

    /*
     * Actualiza la vida del personaje recibido según el daño generado aleatoriamente
     */
    public int AtacarPersonaje(ref Personaje personaje)
    {
        Random aleatorio = new Random();
        int efectividadDisparo = aleatorio.Next(MaximaEfectividadDisparo);
        double valorAtaque = _datos.PoderDeAtaque() * efectividadDisparo;
        var danoProvocado = (int)(((valorAtaque - personaje.Datos.PoderDeDefensa()) / MaximoDanoProvocable) * Porcentaje);
        personaje._caracteristicas.Salud -= danoProvocado;

        return danoProvocado;
    }

    /*
     * Se aumenta un dato aleatorio con valores aleatorios
     */
    public void SubirNivel()
    {
        Random aleatorio = new Random();
        float porcentajePoder = 1 + aleatorio.Next(5, 11) / Porcentaje;
            
        switch (aleatorio.Next(5))
        {
            case 0:
                _caracteristicas.Salud += AumentoSalud;
                break;
            case 1:
                _datos.Fuerza *= porcentajePoder;
                break;
            case 2:
                _datos.Destreza *= porcentajePoder;
                break;
            case 3:
                _datos.Velocidad *= porcentajePoder;
                break;
            case 4:
                _datos.Armadura *= porcentajePoder;
                break;
        }

        _datos.Nivel++;
    }
    
    /*
    * Muestra las características del personaje
    */
    public void MostrarCaracteristicas()
    {
        Console.WriteLine("Tipo: " + Caracteristicas.Tipo);
        Console.WriteLine("Nombre: " + Caracteristicas.Nombre);
        Console.WriteLine("Apodo: " + Caracteristicas.Apodo);
        Console.WriteLine("Fecha Nacimiento: " + Caracteristicas.FechaNacimiento);
        Console.WriteLine("Edad: " + Caracteristicas.Edad);
        Console.WriteLine("Salud: " + Caracteristicas.Salud);  
    }
    
    /*
     * Muestra los datos del personaje
     */
    public void MostrarDatos()
    {
        Console.WriteLine("Velocidad: " + Datos.Velocidad);
        Console.WriteLine("Destreza: " + Datos.Destreza);
        Console.WriteLine("Fuerza: " + Datos.Fuerza);
        Console.WriteLine("Nivel: " + Datos.Nivel);
        Console.WriteLine("Amardura: " + Datos.Armadura);
    }
    
    public int VerSalud()
    {
        return _caracteristicas.Salud;
    }

    public string VerNombre()
    {
        return _caracteristicas.Nombre ?? string.Empty;
    }

    public string VerApodo()
    {
        return _caracteristicas.Apodo ?? string.Empty;
    }
}