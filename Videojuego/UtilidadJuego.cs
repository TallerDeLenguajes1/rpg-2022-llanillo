using static Videojuego.UtilidadFecha;

namespace Videojuego;

public static class UtilidadJuego
{
    /*
     * Devuelve datos de personaje aleatorios
     */
    private static Datos CrearDatosAleatorios()
    {
        Random aleatorio = new Random();
        Datos datos = new Datos
        {
            Velocidad = aleatorio.Next(1, 11),
            Destreza = aleatorio.Next(1, 6),
            Fuerza = aleatorio.Next(1, 11),
            Nivel = aleatorio.Next(1, 11),
            Armadura = aleatorio.Next(1, 11)
        };

        return datos;
    }

    /*
     * Devuelve caracteristicas de personaje aleatorias
     */
    private static Caracteristicas CrearCaracteristicasAleatorias()
    {
        Random aleatorio = new Random();
        var tipos = Enum.GetValues<Tipo>();
        var fechaAleatoria = CrearFechaAleatoria();
        int edadAleatoria = CalcularEdad(fechaAleatoria);
        
        Caracteristicas caracteristicas = new Caracteristicas
        {
            Tipo = (Tipo) tipos.GetValue(aleatorio.Next(tipos.Length)),
            Nombre = Titulo.ObtenerNombreAleatorio(),
            Apodo = Titulo.ObtenerApodoAleatorio(),
            FechaNacimiento = fechaAleatoria,
            Edad = edadAleatoria,
            Salud = 100
        };
        
        return caracteristicas;
    }

    public static Personaje CrearPersonajeAleatorio()
    {
        return new Personaje(CrearDatosAleatorios(), CrearCaracteristicasAleatorias());
    }
    
    /*
     * Muestra las características del personaje
     */
    public static void MostrarCaracteristicas(Personaje personaje)
    {
        Console.WriteLine("Tipo: " + personaje.Caracteristicas.Tipo);
        Console.WriteLine("Nombre: " + personaje.Caracteristicas.Nombre);
        Console.WriteLine("Apodo: " + personaje.Caracteristicas.Apodo);
        Console.WriteLine("Fecha Nacimiento: " + personaje.Caracteristicas.FechaNacimiento);
        Console.WriteLine("Edad: " + personaje.Caracteristicas.Edad);
        Console.WriteLine("Salud: " + personaje.Caracteristicas.Salud);  
    }
    
    /*
     * Muestra los datos del personaje
     */
    public static void MostrarDatos(Personaje personaje)
    {
        Console.WriteLine("Velocidad: " + personaje.Datos.Velocidad);
        Console.WriteLine("Destreza: " + personaje.Datos.Destreza);
        Console.WriteLine("Fuerza: " + personaje.Datos.Fuerza);
        Console.WriteLine("Nivel: " + personaje.Datos.Nivel);
        Console.WriteLine("Amardura: " + personaje.Datos.Armadura);
    }
    
    /*
     * Muestra líneas de batallas épicas
     */
    public static void MostrarBatalla(Personaje atacante, Personaje defensor, int dano)
    {
        Console.WriteLine(atacante.ObtenerNombre() + " " + atacante.ObtenerApodo() 
                          + " realizó " + dano + " de daño a " + defensor.ObtenerNombre() 
                          + " " + defensor.ObtenerApodo());
    }
}