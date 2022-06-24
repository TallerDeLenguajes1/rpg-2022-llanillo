using System.Reflection;

namespace Videojuego.Utilidad;

public static class UtilidadPath
{

    public static string VerPathProyecto()
    {
        string envDir = Environment.CurrentDirectory;
        DirectoryInfo? pathProyecto = Directory.GetParent(envDir)?.Parent;
        
        if (pathProyecto?.Parent != null)
            return pathProyecto?.Parent.FullName ?? string.Empty;
        
        return string.Empty;
    }
}