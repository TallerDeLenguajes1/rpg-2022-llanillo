using Videojuego.Atributos;

namespace Videojuego.Entidad;

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
        var danoProvocado = (int)(((valorAtaque - personaje._datos.PoderDeDefensa()) / MaximoDanoProvocable) * Porcentaje);
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
        Console.WriteLine("Tipo: " + _caracteristicas.Tipo);
        Console.WriteLine("Nombre: " + _caracteristicas.Nombre);
        Console.WriteLine("Apodo: " + _caracteristicas.Apodo);
        Console.WriteLine("Fecha Nacimiento: " + _caracteristicas.FechaNacimiento);
        Console.WriteLine("Edad: " + _caracteristicas.Edad);
        Console.WriteLine("Salud: " + _caracteristicas.Salud);  
    }
    
    /*
     * Muestra los datos del personaje
     */
    public void MostrarDatos()
    {
        Console.WriteLine("Velocidad: " + _datos.Velocidad);
        Console.WriteLine("Destreza: " + _datos.Destreza);
        Console.WriteLine("Fuerza: " + _datos.Fuerza);
        Console.WriteLine("Nivel: " + _datos.Nivel);
        Console.WriteLine("Amardura: " + _datos.Armadura);
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