namespace Videojuego;

public class UtilidadFecha
{
    /*
     * Devuelve una fecha aleatoria desde 1940 hasta 2022
     */
    public static DateTime CrearFechaAleatoria()
    {
        Random aleatorio = new Random();
        return new DateTime(aleatorio.Next(1980, 2005), aleatorio.Next(1, 13), 
            aleatorio.Next(1, 28), aleatorio.Next(25), aleatorio.Next(60), aleatorio.Next(60));
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