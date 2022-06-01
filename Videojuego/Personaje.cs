namespace Videojuego;

public class Personaje{

    private Datos _datos;
    private Caracteristicas _caracteristicas;

    public Personaje(Datos datos, Caracteristicas caracteristicas)
    {
        _datos = datos;
        _caracteristicas = caracteristicas;
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
        Console.WriteLine("Amardura: " + _datos.Amardura);
    }
}