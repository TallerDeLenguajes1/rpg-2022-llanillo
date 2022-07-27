using System.Net;
using System.Text.Json;

namespace Videojuego.Conexion;

public static class ServicioGenshin
{
    private const string TipoContenido = "application/json";
    private const string ApiUrl = "https://api.genshin.dev/characters";
    private const string Metodo = "GET";
        
    public static List<string>? VerResultadosApi()
    {
        List<string>? nombres = null;
        
        var request = (HttpWebRequest) WebRequest.Create(ApiUrl);
        request.Method = Metodo;
        request.ContentType = TipoContenido;
        request.Accept = TipoContenido;

        try
        {
            using WebResponse respuestaWeb = request.GetResponse();
            using Stream stream = respuestaWeb.GetResponseStream(); 
            using var streamReader = new StreamReader(stream);
            
            string responseBody = streamReader.ReadToEnd();
            nombres = JsonSerializer.Deserialize<List<string>>(responseBody);
            
        }catch(WebException e){
            Console.WriteLine(e.ToString());
        }

        return nombres;
    }
}