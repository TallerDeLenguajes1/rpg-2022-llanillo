namespace Videojuego;

public static class Utilidad
{
    /*
     * Devuelve datos de personaje aleatorios
     */
    public static Datos CrearDatosAleatorios()
    {
        Random aleatorio = new Random();
        Datos datos = new Datos
        {
            Velocidad = aleatorio.Next(1, 10),
            Destreza = aleatorio.Next(1, 5),
            Fuerza = aleatorio.Next(1, 10),
            Nivel = aleatorio.Next(1, 10),
            Armadura = aleatorio.Next(1, 10)
        };

        return datos;
    }

    /*
     * Devuelve caracteristicas de personaje aleatorias
     */
    public static Caracteristicas CrearCaracteristicasAleatorias()
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
    /*
     * Devuelve una fecha aleatoria desde 1940 hasta 2022
     */
    public static DateTime CrearFechaAleatoria()
    {
        Random aleatorio = new Random();
        return new DateTime(aleatorio.Next(1, 28), aleatorio.Next(1, 12), aleatorio.Next(1940, 2022));
    }

    /*
     * Devuelve la edad en años dada una fecha
     */
    public static int CalcularEdad(DateTime fechaNacimiento)
    {
        DateTime fechaActual = DateTime.Now;
        int edad = fechaActual.Year - fechaNacimiento.Year;

        if(fechaActual < fechaNacimiento.AddYears(edad)){
            edad--;
        }

        return edad;
    }
}