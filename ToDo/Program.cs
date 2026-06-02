using System;
using System.Collections.Generic;
using EspacioToDo; 

int i = 0;
List<Tarea> tareasPendientes = new List<Tarea>();

    Console.WriteLine("Ingrese la cantidad de tareas:");
    string? cantidad = Console.ReadLine();
    int n;
    int.TryParse(cantidad, out n);

    for( i = 0; i < n; i++)
{
    Tarea tareaNueva = new Tarea();
    tareaNueva.TareaID =  i + 1;

    Console.WriteLine("Ingrese la descripción de la tarea:");
    tareaNueva.Descripcion = Console.ReadLine();

    Console.WriteLine("Ingrese la duración (en minutos):");
    string? duracionInput = Console.ReadLine();
    int duracion;
    int.TryParse(duracionInput, out duracion);
    tareaNueva.Duracion = duracion;

  
    tareasPendientes.Add(tareaNueva);
}

List<Tarea> tareasRealizadas = new List<Tarea>();
int idBuscado;

        do{
            Console.WriteLine("Ingrese el id de la tarea realizada(Ingrese 0 si no pasa mas): ");
            string? idBuscador = Console.ReadLine();
            int.TryParse(idBuscador, out idBuscado);
            Tarea tareaEncontrada = tareasPendientes.Find(t => t.TareaID == idBuscado);
            if (tareaEncontrada != null)
                {
                    tareasRealizadas.Add(tareaEncontrada);
                    tareasPendientes.RemoveAt(tareaEncontrada);
                }
        }while(idBuscado != 0);