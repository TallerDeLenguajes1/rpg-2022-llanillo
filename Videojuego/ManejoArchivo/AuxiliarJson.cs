using System.Text.Json;
using Videojuego.Entidad;

namespace Videojuego.ManejoArchivo;

public class AuxiliarJson
{
    private readonly string _pathArchivo;
    
    public AuxiliarJson(string path)
    {
        _pathArchivo = path;
    }
    public void EscribirLinea(object @object)
    {
        string objectJson = JsonSerializer.Serialize(@object);
        
        try
        {
            using TextWriter streamWriter = new StreamWriter(_pathArchivo);
            streamWriter.Write(objectJson);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void EscribirNuevaLinea(object @object)
    {
        string objectJson = JsonSerializer.Serialize(@object);
        
        try
        {
            using TextWriter streamWriter = new StreamWriter(_pathArchivo);
            streamWriter.WriteLine(objectJson);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public List<Personaje>? CargarPersonajes()
    {
        using TextReader streamReader = new StreamReader(_pathArchivo);
        var personajes = JsonSerializer.Deserialize<List<Personaje>>(_pathArchivo);
        return personajes;
    }
}