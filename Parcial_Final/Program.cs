using System;
using System.Threading;
namespace Parical_Final
{
    class Parcial_Final
    {
        static void Main()
        {   
            //Variables
            int opcion=0; 
            double [] Comisiones = new double [10]; //Arreglo para almacenar comisiones de choferes.
            string [,] Choferes_Rutas = new string [10,2]; //Matriz para almacenar choferes y rutas asignadas.
            //Inicio del programa
            Console.Clear();
            Console.WriteLine("Bienvenido al sistema de gestión de transporte \nPresione cualquier tecla para continuar...");
            Console.ReadKey();
            //Menu principal
            while (opcion!=5 )
            {
                Console.Clear();
                Console.WriteLine("Menu principal");
                Console.WriteLine("1. Administración de choferes"); Console.WriteLine("2. Administración de rutas");
                Console.WriteLine("3. Administración de puestos"); Console.WriteLine("4. Reiniciar sistema");
                Console.WriteLine("5. Salir"); Console.Write("Seleccione una opción: ");
                while(!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 5)
                {
                    Console.Write("\nOpcion invalida \nSeleccione una opcion del 1 al 5: ");
                }
                switch (opcion)
                {
                    case 1:
                        Console.Write("\nCargando administración de choferes");
                        Thread.Sleep(500); Console.Write(".");
                        Thread.Sleep(500); Console.Write(".");
                        Thread.Sleep(500); Console.Write(".");
                        Console.Clear();
                        Administracion_choferes(Choferes_Rutas, Comisiones);
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
        static void Administracion_choferes (string[,] Choferes_Rutas, double[] Comisiones)
        {   
            int opcion=0; int Num_Chofer=0;
            int cantidad_choferes=0;  // Contador de choferes registrados
            string nombre_chofer="";   
            while (opcion != 4)
            {   
                cantidad_choferes= Choferes_Rutas.GetLength(0);
                int i=0;
                Console.Clear();
                Console.WriteLine("----Menu administración de choferes----");
                Console.WriteLine("1. Mostrar nombre de los choferes existentes");   
                Console.WriteLine("2. Agregar o eliminar choferes");
                Console.WriteLine("3. Comision por transporte");
                Console.WriteLine("4. Salir");
                Console.Write("Selecciones una opcion: ");
                while(!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
                {
                    Console.Write("\nOpcion invalida \nSeleccione una opcion del 1 al 4: ");
                }
                switch (opcion)
                {
                    case 1: //Imprimir el listado de choferes.
                        Console.Clear();  //Rediseñar esto.
                        Console.WriteLine("Listado de choferes: ");
                        for (i = 0; i < Choferes_Rutas.GetLength(0) ; i++)
                        {
                            Console.WriteLine((i+1)+". "+Choferes_Rutas[i,0]);
                        }
                        Console.Write("Presione cualquier tecla para continuar..."); Console.ReadKey();
                        break;
                    case 2: //Agregar o eliminar choferes
                        Console.Clear();
                        Console.WriteLine("Seleccione que desea realizar:");
                        Console.WriteLine("1. Agregar chofer \n2. Eliminar chofer");
                        Console.Write("Opcion: ");
                        while(!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
                        {
                            Console.Write("\nOpcion invalida \nSeleccione una opcion del 1 al 2: ");
                        }
                        if (opcion==1) //Agregar choferes
                        {
                            Console.Write("Ingrese el nombre del chofer a agregar: ");
                            nombre_chofer= Console.ReadLine()!; //Agrega el nombre
                            Console.WriteLine("Seleccione la posición donde desea agregar el chofer:");
                            for (i = 0; i < Choferes_Rutas.GetLength(0) ; i++) //Muestra la lista de choferes
                            {
                                Console.WriteLine((i+1)+". "+Choferes_Rutas[i,0]);
                            }
                            Console.Write("Posicion: "); //Lee la posicion y en caso de error vuelve a pedirla
                            if (int.TryParse(Console.ReadLine(), out Num_Chofer) && Num_Chofer >= 1 && Num_Chofer <= 10)
                            {   
                                 if (Choferes_Rutas[Num_Chofer - 1, 0] != "")
                                {
                                    Num_Chofer = Num_Chofer - 1;
                                Choferes_Rutas[Num_Chofer,0]= nombre_chofer;
                                Console.WriteLine("Chofer agregado correctamente. Presione cualquier tecla para continuar...");
                                }
                                else
                                {
                                    Console.WriteLine("La posición ya está ocupada. Intente de nuevo.");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("Posición inválida. Intente de nuevo.");
                            }
                            Console.ReadKey();
                        }    
                        else //Eliminar choferes
                        {   
                            if (cantidad_choferes==0)
                            {
                                Console.WriteLine("No hay choferes registrados \nPresione cualquier tecla para continuar...\n");
                            }
                            else
                            {   
                                Console.WriteLine("Choferes disponibles:");
                                Console.WriteLine("0. Salir");
                                for (i = 0; i < Choferes_Rutas.GetLength(0) ; i++)
                                {
                                    Console.WriteLine((i+1)+". "+Choferes_Rutas[i,0]);
                                }
                                Console.Write("Seleccione el numero del chofer a eliminar: ");
                                
                                if (int.TryParse(Console.ReadLine(), out Num_Chofer) && Num_Chofer >= 1 && Num_Chofer <= 10)
                                {
                                    Num_Chofer--;
                                    if (!string.IsNullOrEmpty(Choferes_Rutas[Num_Chofer, 0]))
                                    {
                                        Choferes_Rutas[Num_Chofer, 0] = "";
                                        Choferes_Rutas[Num_Chofer, 1] = "";
                                        Comisiones[Num_Chofer] = 0;
                                        Console.WriteLine("Chofer eliminado correctamente.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Esa posición está vacía.");
                                    }
                                }
                                else if (Num_Chofer == 0)
                                {
                                    Console.WriteLine("Operación cancelada.");
                                }
                                else
                                {
                                    Console.WriteLine("Número inválido.");
                                }
                            }
                            
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Tabla de comision por transporte");
                        Console.WriteLine();
                        // Encabezado
                        Console.WriteLine("{0,-34} {1,12}", "CHOFERES", "COMISION");
                        Console.WriteLine(new string('-', 48));

                        int contador = 0;
                        for (i = 0; i < Choferes_Rutas.GetLength(0); i++)
                        {
                            string nombre = Choferes_Rutas[i, 0];
                            if (!string.IsNullOrWhiteSpace(nombre))
                            {
                                contador++;
                                double comision = 0.0;
                                if (Comisiones != null && i < Comisiones.Length) comision = Comisiones[i];
                                if (nombre.Length > 34) nombre = nombre.Substring(0, 34);
                                Console.WriteLine("{0,-34} {1,12:F2}", nombre, comision);
                            }
                        }

                        if (contador == 0)
                        {
                            Console.WriteLine("No hay choferes registrados.");
                        }

                        Console.Write("Presione cualquier tecla para continuar..."); Console.ReadKey();
                        break;
                }
            }

        }

        static void Administracion_rutas ()
        {   
            
            //Codigo
        }
    }
}