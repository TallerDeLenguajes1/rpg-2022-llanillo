using Videojuego.Entidad;
using static Videojuego.Utilidad.UtilidadPath;
using Videojuego.ManejoArchivo;

namespace Videojuego.Utilidad;

public static class UtilidadJson
{
    private const string NombreArchivo = "jugadores.json";
    
    /*
     * Escribe los datos de los personajes en un archivo json
     */
    public static void EscribirPersonajesEnJson<T>(List<T> lista)
    {
        string pathActual = VerPathProyecto();
        var auxiliarJson = new AuxiliarJson(pathActual, NombreArchivo);
        auxiliarJson.EscribirNuevaLinea(lista);
    }
    
    /*
     * Lee los ganadores de un archivo CSV
     */
    public static List<Personaje>? CargarPersonajesDeJson()
    {
        string pathActual = VerPathProyecto();
        var auxiliarJson = new AuxiliarJson(pathActual, NombreArchivo);
        return auxiliarJson.LeerArchivo<Personaje>();
    }
}