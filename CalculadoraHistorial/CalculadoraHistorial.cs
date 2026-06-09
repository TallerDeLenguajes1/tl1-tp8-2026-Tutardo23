namespace EspacioCalculadora;
public enum TipoOperacion{
 Suma,
 Resta,
 Multiplicacion,
 Division,
 Limpiar // Representa la acción de borrar el resultado actual o el historial
 }
class Calculadora
{
    private double dato = 0;

    private List<Operacion> historial = new List<Operacion>();
    public void Suma(double termino)
    {
        Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Suma);
        historial.Add(nuevaOperacion);
        dato = dato + termino;
       
    }
    public void Resta(double termino)
    {
        Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Resta);
        historial.Add(nuevaOperacion);
       dato -= termino;
    }
    public void Multiplicar(double termino)
    {
        Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Multiplicacion);
        historial.Add(nuevaOperacion);
        dato = dato * termino;
    }
    public void Dividor(double termino)
    {
        Operacion nuevaOperacion = new Operacion(dato, termino, TipoOperacion.Division);
        historial.Add(nuevaOperacion);
        dato = dato / termino;
    }
    public void Limpiar()
    {
        dato = 0;
    }
    public double Resultado
    {
        get => dato;
    }
}
public class Operacion{
 private double resultadoAnterior; // Almacena el resultado previo al cálculo actual
 private double nuevoValor; //El valor con el que se opera sobre el resultadoAnterior
 private TipoOperacion operacion;// El tipo de operación realizada
 public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion)
    {
        this.resultadoAnterior = resultadoAnterior;
        this.nuevoValor = nuevoValor;
        this.operacion = operacion;
    }
 public double Resultado{
    get{
        switch(operacion){
            case TipoOperacion.Suma:
                return resultadoAnterior + nuevoValor;

            case TipoOperacion.Resta:
                return resultadoAnterior - nuevoValor;

            case TipoOperacion.Multiplicacion:
                return resultadoAnterior * nuevoValor;

            case TipoOperacion.Division:
                return resultadoAnterior / nuevoValor;

            default:
                return resultadoAnterior;
        }
    }
 }
// Propiedad pública para acceder al nuevo valor utilizado en la operación
 public double NuevoValor{
   get
    {
        return nuevoValor;
    }
 }
}
// Constructor u otros métodos necesarios para inicializar y gestionar la operación
// .