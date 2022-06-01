namespace Videojuego;

public class Personaje{

    private const int MaximoDanoProvocable = 5000;
    
    private Caracteristicas _caracteristicas;
    private Datos _datos;
    
    public Personaje(Datos datos, Caracteristicas caracteristicas)
    {
        datos = datos;
        _caracteristicas = caracteristicas;
    }

    /*
     * Actualiza la vida del personaje recibido según el daño provocado generado aleatorio
     */
    public void AtacarPersonaje(Personaje personaje)
    {
        Random aleatorio = new Random();
        double efectividadDisparo = aleatorio.NextDouble();
        double valorAtaque = _datos.PoderDeAtaque() * efectividadDisparo;
        double DanoProvocado = ((valorAtaque * efectividadDisparo - personaje._datos.PoderDeDefensa()) 
                                / MaximoDanoProvocable) * 100;
        personaje._caracteristicas.Salud -= (int) DanoProvocado;
    }

    /*
     * Se aumenta un dato aleatorio con valores aleatorios
     */
    public void SubirNivel()
    {
        Random aleatorio = new Random();
        float porcentajePoder = 1 + aleatorio.Next(5, 10) / 100;
            
        switch (aleatorio.Next(5))
        {
            case 0:
                _caracteristicas.Salud += 10;
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
}