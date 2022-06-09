namespace Videojuego.Atributos;

/*
 * Clase utilidad para guardar y obtener apodos aleatorios
 */
public static class Apodo
{
    private static readonly string[] Apodos = { "Mata-Dragones", "Mata-Chorizos", "Mata-Suegras", "Destructor", "Peregrino" };

    public static string ObtenerApodoAleatorio()
    {
        Random aleatorio = new Random();
        return Apodos[aleatorio.Next(Apodos.Length)];
    }
}