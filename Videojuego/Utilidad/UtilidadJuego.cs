using Videojuego.Atributos;
using Videojuego.Entidad;
using static Videojuego.Utilidad.UtilidadFecha;

namespace Videojuego.Utilidad;

public static class UtilidadJuego
{

    private const int SaludInicial = 100;
    
    private const int MinimoValorDatos = 1;
    private const int MaximoValorDatos = 11;
    
    /*
     * Devuelve datos de personaje aleatorios
     */
    private static Datos CrearDatosAleatorios()
    {
        Random aleatorio = new Random();
        Datos datos = new Datos
        {
            Velocidad = aleatorio.Next(MinimoValorDatos, MaximoValorDatos),
            Destreza = aleatorio.Next(MinimoValorDatos, MaximoValorDatos),
            Fuerza = aleatorio.Next(MinimoValorDatos, MaximoValorDatos),
            Nivel = aleatorio.Next(MinimoValorDatos, MaximoValorDatos),
            Armadura = aleatorio.Next(MinimoValorDatos, MaximoValorDatos)
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
        int edad = CalcularEdad(fechaAleatoria);
        
        Caracteristicas caracteristicas = new Caracteristicas
        {
            Tipo = (Tipo) (tipos.GetValue(aleatorio.Next(tipos.Length)) ?? throw new InvalidOperationException()),
            Nombre = Nombre.ObtenerNombreAleatorio(),
            Apodo = Apodo.ObtenerApodoAleatorio(),
            FechaNacimiento = fechaAleatoria,
            Edad = edad,
            Salud = SaludInicial
        };
        
        return caracteristicas;
    }

    public static Personaje CrearPersonajeAleatorio()
    {
        return new Personaje(CrearDatosAleatorios(), CrearCaracteristicasAleatorias());
    }
}