namespace Videojuego;

/*
 * Enumeración que define los tipos de personaje
 */
public enum Tipo
{
    Guerrero,
    Arquero,
    Paladin,
    Ladron
}

/*
 * Clase de utilidad para guardar nombres y apodos
 */
public static class Titulo
{
    private static readonly string[] Nombres = { "Beatriz", "Orlando", "Thor", "Loki", "Pepe" };
    private static readonly string[] Apodos = { "Mata-Dragones", "Mata-Chorizos", "Mata-Suegras", "Destructor", "Peregrino" };

    public static string ObtenerNombreAleatorio()
    {
        Random aleatorio = new Random();
        return Nombres[aleatorio.Next(Apodos.Length)];
    }

    public static string ObtenerApodoAleatorio()
    {
        Random aleatorio = new Random();
        return Apodos[aleatorio.Next(Nombres.Length)];
    }
}

/*
 * Estructura que define todos los atributos del personaje
 */
public struct Datos{
    public float Velocidad ;
    public float Destreza;
    public float Fuerza;
    public int Nivel;
    public float Armadura;

    public float PoderDeAtaque()
    {
        return Destreza * Fuerza * Nivel;
    }

    public float PoderDeDefensa()
    {
        return Armadura * Velocidad;
    }
}

/*
 * Estructura que define la información del personaje
 */
public struct Caracteristicas{
    public Tipo Tipo;
    public string? Nombre;
    public string? Apodo;
    public DateTime FechaNacimiento;
    public int Edad;
    public int Salud;
}