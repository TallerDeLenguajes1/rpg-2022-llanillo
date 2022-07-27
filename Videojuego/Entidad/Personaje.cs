using Videojuego.Atributos;

namespace Videojuego.Entidad;

public class Personaje{

    public const int MaximoDanoProvocable = 50000;
    public const int MaximaEfectividadDisparo = 101;
    
    private const int MaximoPorcentaje = 100;
    private const int AumentoSalud = 10;

    private Caracteristicas _caracteristicas;
    public Caracteristicas Caracteristicas
    {
        get => _caracteristicas;
        set => _caracteristicas = value;
    }

    private Datos _datos;
    public Datos Datos
    {
        get => _datos;
        set => _datos = value;
    }

    public Personaje(Datos datos, Caracteristicas caracteristicas)
    {
        Datos = datos;
        Caracteristicas = caracteristicas;
    }

    /*
     * Se aumenta un dato aleatorio con valores aleatorios
     */
    public void SubirDeNivel()
    {
        var aleatorio = new Random();
        float porcentajePoder = 1 + aleatorio.Next(5, 11) / MaximoPorcentaje;
            
        switch (aleatorio.Next(5))
        {
            case 0:
                _caracteristicas.Salud += AumentoSalud;
                break;
            case 1:
                _datos.Fuerza *= porcentajePoder;
                break;
            case 2:
                _datos.Destreza *= porcentajePoder;
                break;
            case 3:
                _datos.Velocidad *= porcentajePoder;
                break;
            case 4:
                _datos.Armadura *= porcentajePoder;
                break;
        }

        _datos.Nivel++;
    }

    public void ReducirSalud(int cantidad)
    {
        _caracteristicas.Salud -= cantidad;
    }
    
    /*
    * Devuelve las características del personaje
    */
    public string VerCaracteristicas()
    {
        return "Tipo: " + Caracteristicas.Tipo + '\n'
               + "Nombre: " + Caracteristicas.Nombre + '\n'
               + "Apodo: " + Caracteristicas.Apodo + '\n'
               + "Fecha Nacimiento: " + Caracteristicas.FechaNacimiento.ToShortDateString() + '\n'
               + "Edad: " + Caracteristicas.Edad + '\n'
               + "Salud: " + Caracteristicas.Salud + '\n';
    }
    
    /*
     * Devuelve los datos del personaje
     */
    public string VerDatos()
    {
        return "Velocidad: " + Datos.Velocidad + '\n'
               + "Destreza: " + Datos.Destreza + '\n'
               + "Fuerza: " + Datos.Fuerza + '\n'
               + "Nivel: " + Datos.Nivel + '\n'
               + "Amardura: " + Datos.Armadura + '\n';
    }

    /*
     * Devuelve el poder de ataque
     */
    public float VerPoderAtaque()
    {
        return Datos.VerPoderDeAtaque();
    }

    /*
     * Devuelve el poder de defensa
     */
    public float VerPoderDefensa()
    {
        return Datos.VerPoderDeDefensa();
    }
    
    /*
     * Devuelve la cantidad de salud 
     */
    public int VerSalud()
    {
        return Caracteristicas.Salud;
    }

    /*
     * Devuelve el nombre del peleador
     */
    public string VerNombre()
    {
        return Caracteristicas.Nombre ?? string.Empty;
    }

    /*
     * Devuelve el apodo del peleador
     */
    public string VerApodo()
    {
        return Caracteristicas.Apodo ?? string.Empty;
    }

    /*
     * Devuelve la edad del peleador
     */
    public int VerEdad()
    {
        return Caracteristicas.Edad;
    }
}