using System;
using System.Collections.Generic;
using EspacioToDo;

List<Tarea> tareasPendientes = new List<Tarea>();
List<Tarea> tareasRealizadas = new List<Tarea>();

Random random = new Random();

int opcion;

do
{
    Console.WriteLine("========== MENU PRINCIPAL ==========");
    Console.WriteLine("1 - Crear tareas aleatorias");
    Console.WriteLine("2 - Mover tarea pendiente a realizada");
    Console.WriteLine("3 - Buscar tarea pendiente por descripcion");
    Console.WriteLine("4 - Mostrar todas las tareas");
    Console.WriteLine("0 - Salir");
    Console.WriteLine("Ingrese una opcion:");

    string? opcionIngresada = Console.ReadLine();
    int.TryParse(opcionIngresada, out opcion);

    switch (opcion)
    {
        case 1:
            Console.WriteLine("Ingrese la cantidad de tareas:");
            string? cantidad = Console.ReadLine();

            int n;
            int.TryParse(cantidad, out n);

            for (int i = 0; i < n; i++)
            {
                Tarea tareaNueva = new Tarea();

                tareaNueva.TareaID = tareasPendientes.Count + tareasRealizadas.Count + 1;
                tareaNueva.Descripcion = "Tarea " + tareaNueva.TareaID;
                tareaNueva.Duracion = random.Next(10, 101);

                tareasPendientes.Add(tareaNueva);
            }

            Console.WriteLine("Tareas creadas correctamente.");
            break;

        case 2:
            Console.WriteLine("Ingrese el ID de la tarea realizada:");
            string? idBuscador = Console.ReadLine();

            int idBuscado;
            int.TryParse(idBuscador, out idBuscado);

            Tarea? tareaEncontrada = tareasPendientes.Find(t => t.TareaID == idBuscado);

            if (tareaEncontrada != null)
            {
                tareasRealizadas.Add(tareaEncontrada);
                tareasPendientes.Remove(tareaEncontrada);

                Console.WriteLine("Tarea movida a realizadas.");
            }
            else
            {
                Console.WriteLine("No se encontro una tarea pendiente con ese ID.");
            }

            break;

        case 3:
            Console.WriteLine("Ingrese una descripcion para buscar:");
            string? descripcionBuscada = Console.ReadLine();

            Console.WriteLine("Resultado de la busqueda:");

            foreach (Tarea tarea in tareasPendientes)
            {
                if (descripcionBuscada != null && tarea.Descripcion.Contains(descripcionBuscada))
                {
                    Console.WriteLine("ID: " + tarea.TareaID);
                    Console.WriteLine("Descripcion: " + tarea.Descripcion);
                    Console.WriteLine("Duracion: " + tarea.Duracion + " minutos");
                    Console.WriteLine("----------------------");
                }
            }

            break;

        case 4:
            Console.WriteLine("===== TAREAS PENDIENTES =====");

            foreach (Tarea tarea in tareasPendientes)
            {
                Console.WriteLine("ID: " + tarea.TareaID);
                Console.WriteLine("Descripcion: " + tarea.Descripcion);
                Console.WriteLine("Duracion: " + tarea.Duracion + " minutos");
                Console.WriteLine("----------------------");
            }

            Console.WriteLine("===== TAREAS REALIZADAS =====");

            foreach (Tarea tarea in tareasRealizadas)
            {
                Console.WriteLine("ID: " + tarea.TareaID);
                Console.WriteLine("Descripcion: " + tarea.Descripcion);
                Console.WriteLine("Duracion: " + tarea.Duracion + " minutos");
                Console.WriteLine("----------------------");
            }

            break;

        case 0:
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Opcion incorrecta.");
            break;
    }

} while (opcion != 0);