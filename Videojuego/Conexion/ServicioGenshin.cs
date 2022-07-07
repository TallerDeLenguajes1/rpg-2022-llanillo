using System.Net;
using System.Text.Json;

namespace Videojuego.Conexion;

public static class ServicioGenshin
{
    private const string JsonType = "application/json";
    private const string Url = "https://api.genshin.dev/characters";
        
    public static List<string>? VerGenshinNombres()
    {
        List<string>? nombres = null;
        
        var request = (HttpWebRequest) WebRequest.Create(Url);
        request.Method = "GET";
        request.ContentType = JsonType;
        request.Accept = JsonType;

        try
        {
            using WebResponse respuesta = request.GetResponse();
            using Stream streamReader = respuesta.GetResponseStream(); 
            using StreamReader objReader = new StreamReader(streamReader);
            string responseBody = objReader.ReadToEnd();
            nombres = JsonSerializer.Deserialize<List<string>>(responseBody);
        }catch(WebException e){
            Console.WriteLine(e.ToString());
        }

        return nombres;
    }
}