namespace Videojuego.Atributos;

/*
 * Estructura que define todos los atributos del personaje
 */
public struct Datos
{
    public float Velocidad { get; set; }
    public float Destreza { get; set; }
    public float Fuerza { get; set; }
    public int Nivel { get; set; }
    public float Armadura { get; set; }

    public float VerPoderDeAtaque()
    {
        return Destreza * Fuerza * Nivel;
    }

    public float VerPoderDeDefensa()
    {
        return Armadura * Velocidad;
    }
}