namespace Videojuego.Atributos;

/*
 * Clase utilidad para guardar y obtener nombres aleatorios
 */
public static class Nombre
{
    private static readonly string[] Nombres = { "Beatriz", "Orlando", "Thor", "Loki", "Pepe" };
    
    public static string ObtenerNombreAleatorio()
    {
        Random aleatorio = new Random();
        return Nombres[aleatorio.Next(Nombres.Length)];
    }
}