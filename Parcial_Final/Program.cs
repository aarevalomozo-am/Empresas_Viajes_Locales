using System;
namespace Parical_Final
{
    class Parcial_Final
    {
        static void Main()
        {   
            //Variables
            int opcion=0;
            //Inicio del programa
            Console.Clear();
            Console.WriteLine("Bienvenido al sistema de gestión de transporte \nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            //Menu principal
            while (opcion!=5 )
            {
                Console.Clear();
                Console.WriteLine("Menu principal");
                Console.WriteLine("1. Administración de choferes");
                Console.WriteLine("2. Administración de rutas");
                Console.WriteLine("3. Administración de puestos");
                Console.WriteLine("4. Reiniciar sistema");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");
                while(!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
                {
                    Console.Write("\nOpcion invalida \nSeleccione una opcion del 1 al 5: ");
                }
                switch (opcion)
                {
                    case 1:
                        Console.Write("\nCargando administración de choferes");
                        Thread.Sleep(500);
                        Console.Write(".");
                        Thread.Sleep(500);
                        Console.Write(".");
                        Thread.Sleep(500);
                        Console.WriteLine(".");
                        break;
                        //Agregar las funcion.
                    case 2:
                        Console.Write("\nCargando administración de rutas");
                        Thread.Sleep(500);
                        Console.Write(".");
                        Thread.Sleep(500);
                        Console.Write(".");
                        Thread.Sleep(500);
                        Console.WriteLine(".");
                        break;
                    case 3:
                        Console.Write("\nCargando administración de puestos");
                        Thread.Sleep(500);
                        Console.Write(".");
                        Thread.Sleep(500);
                        Console.Write(".");
                        Thread.Sleep(500);
                        Console.WriteLine(".");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\nEl sistema se ha reiniciado correctamente.\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Gracias por usar el sistema de gestión de transporte. ¡Hasta luego!");
                        break;
                }

            }
        }
    }
}