﻿using Videojuego.Entidad;
using static Videojuego.Conexion.ServicioGenshin;
using static Videojuego.Utilidad.UtilidadJuego;
using static Videojuego.Utilidad.UtilidadCsv;
using static Videojuego.Utilidad.UtilidadJson;

namespace Videojuego;

public static class Program
{
    private const int CantidadPeleadores = 5;

    public static int Main(string[] args)
    {
        List<string>? nombresApi = VerGenshinNombres();
        var peleadores = new List<Personaje>();
        var aleatorio = new Random();
        var batalla = new Batalla();
        
        Console.WriteLine("¿Desea generar aleatoriamente los personaes o cargarlos desde un JSON? (0 - Aleatorio, 1 - JSON)");
        var jsonNoEncontrado = 0;
        
        while (jsonNoEncontrado != 1)
        {
            if (jsonNoEncontrado == 2 || int.Parse(Console.ReadLine()) == 0)
            {
                for (var i = 0; i < CantidadPeleadores; i++)
                {
                    string nombre = nombresApi?[aleatorio.Next(nombresApi.Count)] ?? string.Empty;
                    var peleador = CrearPersonajeAleatorio(nombre);
                    peleadores.Add(peleador);
                }

                jsonNoEncontrado = 1;
            }
            else
            {
                try
                {
                    peleadores = CargarPersonajesDeJson();
                }
                catch (Exception e)
                {
                    Console.WriteLine("No se consiguió un archivo JSON de jugadores, se procederá a crear aleatorios");
                    jsonNoEncontrado = 2;
                }
            }
        }
        
        batalla.AgregarPeleadores(peleadores);
        EscribirPersonajesEnJson(peleadores);

        for (var i = 0; i < CantidadPeleadores; i++)
        {
            batalla.IniciarSiguienteBatalla();
        }

        var ganador = batalla.VerGanador();

        if (ganador != null)
        {
            Console.Write(ganador.VerCaracteristicas());
            EscribirGanadorEnCsv(ganador.VerNombre(), ganador.VerApodo(), ganador.VerEdad());
        }
        
        VerGanadoresEnCsv();
        
        return 0;
    }
}


