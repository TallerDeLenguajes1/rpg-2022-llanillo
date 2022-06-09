namespace Videojuego.Atributos;

/*
 * Estructura que define la información del personaje
 */
public struct Caracteristicas
{
    public Tipo Tipo { get; set; }
    public string? Nombre { get; set; }
    public string? Apodo { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public int Edad { get; set; }
    public int Salud { get; set; }
}