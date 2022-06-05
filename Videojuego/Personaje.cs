namespace Videojuego;

public class Personaje{

    private const int MaximoDanoProvocable = 50000;
    
    private Caracteristicas _caracteristicas;
    private Datos _datos;
    
    public Datos Datos => _datos;

    public Caracteristicas Caracteristicas => _caracteristicas;
    

    public Personaje(Datos datos, Caracteristicas caracteristicas)
    {
        _datos = datos;
        _caracteristicas = caracteristicas;
    }

    /*
     * Actualiza la vida del personaje recibido según el daño generado aleatoriamente
     */
    public int AtacarPersonaje(ref Personaje personaje)
    {
        Random aleatorio = new Random();
        int efectividadDisparo = aleatorio.Next(101);
        double valorAtaque = _datos.PoderDeAtaque() * efectividadDisparo;
        var danoProvocado = (int)(((valorAtaque - personaje.Datos.PoderDeDefensa()) / MaximoDanoProvocable) * 100);
        personaje._caracteristicas.Salud -= danoProvocado;

        return danoProvocado;
    }

    /*
     * Se aumenta un dato aleatorio con valores aleatorios
     */
    public void SubirNivel()
    {
        Random aleatorio = new Random();
        float porcentajePoder = 1 + aleatorio.Next(5, 11) / 100;
            
        switch (aleatorio.Next(5))
        {
            case 0:
                _caracteristicas.Salud += 10;
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
    
    public int ObtenerSalud()
    {
        return _caracteristicas.Salud;
    }

    public string ObtenerNombre()
    {
        return _caracteristicas.Nombre ?? string.Empty;
    }

    public string ObtenerApodo()
    {
        return _caracteristicas.Apodo ?? string.Empty;
    }
}