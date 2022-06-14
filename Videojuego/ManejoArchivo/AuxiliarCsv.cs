using System;

namespace Videojuego.ManejoArchivo;

public class AuxiliarCsv
{
    private const string NombreArchivo = "ganadores.csv";
    private const string SeparadorCsv = ";";

    private const string Titulo = "--- Ganadores ---";
    private const string PrimeraColumna = "Nombre";
    private const string SegundaColumna = "Apodo";
    private const string TerceraColumna = "Edad";
    
    private readonly string _pathArchivo;
    private readonly string _pathCarpeta;
    
    public AuxiliarCsv(string path)
    {
        _pathCarpeta = path;
        _pathArchivo = path + @"\" + NombreArchivo;
    }

    public void IniciarArchivo()
    {
        if (File.Exists(_pathArchivo)) return;

        Directory.CreateDirectory(_pathCarpeta);
        
        try
        {
            using TextWriter streamWriter = new StreamWriter(_pathArchivo);
            streamWriter.WriteLine(SeparadorCsv + Titulo);
            streamWriter.Write(SeparadorCsv + PrimeraColumna);
            streamWriter.Write(SeparadorCsv + SegundaColumna);
            streamWriter.WriteLine(SeparadorCsv + TerceraColumna);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    /*
     * Retorna verdadero si la escritura fue exitosa
     */
    public bool EscribirLinea(string? texto)
    {
        try
        {
            using TextWriter streamWriter = File.AppendText(_pathArchivo);
            streamWriter.Write(SeparadorCsv + texto);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    /*
     * Escribe el texto en el archivo y agrega un salto de línea.
     * Retorna verdadero si la escritura fue exitosa.
     */
    public bool EscribirNuevaLinea(string? texto)
    {
        try
        {
            using TextWriter streamWriter = File.AppendText(_pathArchivo);
            streamWriter.WriteLine(SeparadorCsv + texto);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
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