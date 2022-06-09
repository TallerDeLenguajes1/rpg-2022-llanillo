namespace Videojuego;

/*
 * Estructura que define todos los atributos del personaje
 */
public struct Datos
{
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