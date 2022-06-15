using System.Text.Json;

namespace Videojuego.ManejoArchivo;

public class AuxiliarJson
{
    private readonly string _pathArchivo;
    
    public AuxiliarJson(string path, string nombreArchivo)
    {
        _pathArchivo = path + @"\" + nombreArchivo;
    }
    
    /*
    * Crea el archivo JSON y le agrega un objecto
    */
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

    /*
    * Crea el archivo JSON y le agrega un objecto con un salto de línea
    */
    public void EscribirNuevaLinea<T>(T @object)
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

    /*
     * Devuelve una lista de objectos de tipo T que tiene el archivo JSON
     */
    public List<T>?  LeerArchivo<T>()
    {
        using TextReader streamReader = new StreamReader(_pathArchivo);
        return JsonSerializer.Deserialize<List<T>>(streamReader.ReadToEnd());
    }
}