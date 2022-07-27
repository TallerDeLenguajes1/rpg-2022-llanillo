using System.Reflection;

namespace Videojuego.Utilidad;

public static class UtilidadPath
{

    public static string VerPathProyecto()
    {
        string directorioEnv = Environment.CurrentDirectory;
        DirectoryInfo? pathProyecto = Directory.GetParent(directorioEnv)?.Parent;
        
        if (pathProyecto?.Parent != null)
            return pathProyecto?.Parent.FullName ?? string.Empty;
        
        return string.Empty;
    }
}