namespace Videojuego.Atributos;

/*
 * Clase utilidad para guardar y obtener apodos aleatorios
 */
public static class Apodo
{
    private static readonly string[] Apodos = { "Mata-Dragones", "Come-Chorizos", "Besa-Suegras", "Destructor", "Peregrino" };

    public static string VerApodoAleatorio()
    {
        return Apodos[new Random().Next(Apodos.Length)];
    }
}