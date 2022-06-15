using Videojuego.Entidad;
using Videojuego.ManejoArchivo;

namespace Videojuego.Utilidad;

public static class UtilidadJson
{
    private const string NombreArchivo = "jugadores.json";
    
    /*
     * Escribe los datos de los personajes en un archivo json
     */
    public static void EscribirPersonajesEnJson<T>(string path, List<T> lista)
    {
        var auxiliarJson = new AuxiliarJson(path, NombreArchivo);
        auxiliarJson.EscribirNuevaLinea(lista);
    }
    
    /*
     * Lee los ganadores de un archivo CSV
     */
    public static List<Personaje>? CargarPersonajesDeJson(string path)
    {
        var auxiliarJson = new AuxiliarJson(path, NombreArchivo);
        return auxiliarJson.LeerArchivo<Personaje>();
    }
}