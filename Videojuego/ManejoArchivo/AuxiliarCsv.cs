using System;

namespace Videojuego.ManejoArchivo;

public class AuxiliarCsv
{
    private const string SeparadorCsv = ";";
    
    private readonly string _pathArchivo;
    private readonly string _pathCarpeta;
    
    public AuxiliarCsv(string path, string nombreArchivo)
    {
        _pathCarpeta = path;
        _pathArchivo = path + @"\" + nombreArchivo;
    }

    /*
     * Crea el archivo CSV y le agrega un título y texto a las tres primers columnas
     */
    public void IniciarArchivo(string titulo, string primeraCol, string segundaCol, string terceraCol)
    {
        if (File.Exists(_pathArchivo)) return;

        Directory.CreateDirectory(_pathCarpeta);
        
        try
        {
            using TextWriter streamWriter = new StreamWriter(_pathArchivo);
            streamWriter.WriteLine(SeparadorCsv + titulo);
            streamWriter.Write(SeparadorCsv + primeraCol);
            streamWriter.Write(SeparadorCsv + segundaCol);
            streamWriter.WriteLine(SeparadorCsv + terceraCol);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    /*
     * Retorna verdadero si la escritura fue exitosa
     */
    public void EscribirLinea(string? texto)
    {
        try
        {
            using TextWriter streamWriter = File.AppendText(_pathArchivo);
            streamWriter.Write(SeparadorCsv + texto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    /*
     * Escribe el texto en el archivo y agrega un salto de línea.
     * Retorna verdadero si la escritura fue exitosa.
     */
    public void EscribirNuevaLinea(string? texto)
    {
        try
        {
            using TextWriter streamWriter = File.AppendText(_pathArchivo);
            streamWriter.WriteLine(SeparadorCsv + texto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    /*
     * Lee el archivo ubicado en el path y muestra por pantalla su contenido
     */
    public void LeerArchivo()
    {
        if (!File.Exists(_pathArchivo)) return;
        
        try
        {
            using TextReader streamReader = new StreamReader(_pathArchivo);
            var textoArchivo = streamReader.ReadToEnd();
            textoArchivo = textoArchivo.Replace(";", " ");
            Console.WriteLine(textoArchivo);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}