using System;
using System.Reflection.Emit;
using System.Threading;
namespace Parical_Final
{
    class Parcial_Final
    {
        static void Main()
        {   
            //Variable
            int opcion=0; 
            int [] Boletas= new int [6]; 
            double [] Comisiones = new double [6]; //Arreglo para almacenar comisiones de choferes.
            
            string [,] Choferes_Rutas_Horario = new string [6,3]; //Matriz para almacenar choferes y rutas asignadas.
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
                        Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(350);
                        Administracion_choferes(Choferes_Rutas_Horario, Comisiones, Boletas);
                        break;
                        //Agregar las funcion.
                    case 2:
                        Console.Write("\nCargando administración de rutas");
                        Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(350);
                        Administracion_rutas(Choferes_Rutas_Horario, Comisiones, Boletas);
                        break;
                    case 3:
                        Console.Write("\nCargando administración de puestos");
                        Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(350);
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
        static void Administracion_choferes (string[,] Choferes_Rutas_Horario, double[] Comisiones, int[] Boletas)
        {   
            int opcion=0; int Num_Chofer=0;
            int cantidad_choferes=0;  // Contador de choferes registrados
            string nombre_chofer="";   //Nombre del chofer a agregar
            while (opcion != 4)
            {   
                for (int k = 0; k < Choferes_Rutas_Horario.GetLength(0); k++)
                {  //Cuenta la cantidad de choferes registrados
                    if (Choferes_Rutas_Horario[k,0] != null)
                    {
                        cantidad_choferes=cantidad_choferes + 1;
                    }
                } 
                int i=0;
                Console.Clear(); //Menu de administración de choferes
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
                        Console.Clear();  
                        Console.WriteLine("Listado de choferes: ");
                        for (i = 0; i < Choferes_Rutas_Horario.GetLength(0) ; i++) //Muestra la lista de choferes
                        {   
                            if (Choferes_Rutas_Horario[i,0] == null)
                            {
                                Console.WriteLine((i+1)+". [Vacío]");
                            }
                            else
                            {
                                Console.WriteLine((i+1)+". "+ Choferes_Rutas_Horario[i,0]);
                            }                            
                     }
                        Console.Write("Presione cualquier tecla para continuar..."); Console.ReadKey();
                        break;
                    case 2: //Agregar o eliminar choferes
                        Console.Clear();
                        Console.WriteLine("Seleccione que desea realizar:");
                        Console.WriteLine("0. Salir \n1. Agregar chofer \n2. Eliminar chofer");
                        Console.Write("Opcion: ");
                        while(!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 2)
                        {
                            Console.Write("\nOpcion invalida \nSeleccione una opcion del 0 al 2: ");
                        }
                        if (opcion==1) //Agregar choferes
                        {   
                            bool nombreEsValido=false;
                            do
                            {
                                // 1. Pedir la entrada
                                Console.Write("Ingrese el nombre del chofer a agregar: ");
                                nombre_chofer = Console.ReadLine()!;
                                // 2. Validar la entrada
                                nombreEsValido = !string.IsNullOrWhiteSpace(nombre_chofer) && nombre_chofer.All(char.IsLetter);
                                // 3. Si no es válido, mostrar el error
                                if (!nombreEsValido)
                                {
                                    Console.WriteLine("Nombre inválido. No se permiten dígitos, caracteres especiales ni espacios en blanco.");
                                }
                            // 4. Repetir el bucle si el nombre NO es válido
                            } while (!nombreEsValido);
                            Console.WriteLine("Seleccione la posición donde desea agregar el chofer:");
                            for (i = 0; i < Choferes_Rutas_Horario.GetLength(0) ; i++) //Muestra la lista de choferes
                            {   
                                if (Choferes_Rutas_Horario[i,0] == null)
                                {
                                    Console.WriteLine((i+1)+". [Vacío]");
                                }
                                else
                                {
                                    Console.WriteLine((i+1)+". "+ Choferes_Rutas_Horario[i,0]);
                                }                            
                            }       
                            Console.Write("Posicion: "); //Lee la posicion y en caso de error vuelve a pedirla
                            if (int.TryParse(Console.ReadLine(), out Num_Chofer) && Num_Chofer >= 1 && Num_Chofer <= 10)
                            {   
                                if (Choferes_Rutas_Horario[Num_Chofer - 1, 0] == null)
                                {
                                    Num_Chofer = Num_Chofer - 1;
                                    Choferes_Rutas_Horario[Num_Chofer,0]= nombre_chofer;
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
                        else if (opcion==2)//Eliminar choferes
                        {   
                            if (cantidad_choferes==0)
                            {
                                Console.WriteLine("No hay choferes registrados \nPresione cualquier tecla para continuar...\n");
                            }
                            else
                            {   
                                Console.WriteLine("Choferes disponibles:");
                                Console.WriteLine("0. Salir");
                                for (i = 0; i < Choferes_Rutas_Horario.GetLength(0) ; i++) //Muestra la lista de choferes
                                {   
                                    if (Choferes_Rutas_Horario[i,0] == null)
                                    {
                                        Console.WriteLine((i+1)+". [Vacío]");
                                    }
                                    else
                                    {   
                                        Console.WriteLine((i+1)+". "+ Choferes_Rutas_Horario[i,0]);
                                    }                            
                                }
                                Console.Write("Seleccione el numero del chofer a eliminar: ");
                                
                                if (int.TryParse(Console.ReadLine(), out Num_Chofer) && Num_Chofer >= 1 && Num_Chofer <= 10)
                                {
                                    Num_Chofer--;
                                    if (!string.IsNullOrEmpty(Choferes_Rutas_Horario[Num_Chofer, 0]))
                                    {
                                        Choferes_Rutas_Horario[Num_Chofer, 0] = "";
                                        Choferes_Rutas_Horario[Num_Chofer, 1] = "";
                                        Comisiones[Num_Chofer] = 0.00;
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
                        else
                        {
                            Console.WriteLine("\nSaliendo");
                            Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(350);
                        }
                        break;
                    case 3:
                        Console.Clear();
                         for (i = 0; i < Choferes_Rutas_Horario.GetLength(0) ; i++)
                        {   //Modificar el calculo de comisiones.
                            int precio= Boletas[i] * 25000;
                            Comisiones[i]= precio * 0.45;
                            
                        }
                        Console.WriteLine("Tabla de comision por transporte");
                        Console.WriteLine();
                        // Encabezado
                        Console.WriteLine("{0,-34} {1,12}", "CHOFERES", "COMISION");
                        Console.WriteLine(new string('-', 48));

                        int contador = 0;
                        for (i = 0; i < Choferes_Rutas_Horario.GetLength(0); i++)
                        {
                            string nombre = Choferes_Rutas_Horario[i, 0];
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
                    case 4:     
                        Console.Write("Saliendo");
                        Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(350);
                        break;
                }
            }

        }

        static void Administracion_rutas (string[,] Choferes_Rutas_Horario, double[] Comisiones, int[] Boletas)
        {   
            string origen="";
            string destino="";
            int opcion=0, Num_Chofer=0, horario=0;
            while (opcion!=4)
            {   
                Console.Clear();
                Console.WriteLine("----Menu adiministración de rutas----");
                Console.WriteLine("1. Mostrar rutas con jornada de los choferes");
                Console.WriteLine("2. Configurar rutas a choferes ");
                Console.WriteLine("3. Configurar horarios a choferes");
                Console.WriteLine("4. Salir ");
                Console.Write("Selecciones una opcion: ");
                while(!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
                {
                    Console.Write("\nOpcion invalida \nSeleccione una opcion del 1 al 4: ");
                }
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Listado de rutas asignadas a choferes: ");
                        for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0); i++)
                        {   
                            if (Choferes_Rutas_Horario[i,0] == null)
                            {
                                Console.WriteLine("1. [Vacío]");
                                continue;
                            }
                            else
                            {   
                                if (Choferes_Rutas_Horario[i,1] == null)
                                {
                                    Choferes_Rutas_Horario[i,1] = "[Sin ruta asignada]";
                                }
                                if (Choferes_Rutas_Horario[i,2] == null)
                                {
                                    Choferes_Rutas_Horario[i,2] = "[Sin jornada asignada]";
                                }
                            }
                            Console.WriteLine(i+". "+Choferes_Rutas_Horario[i,0]+ " -> " + Choferes_Rutas_Horario[i,1] + " | Jornada: " + Choferes_Rutas_Horario[i,2]);
                        }
                        Console.Write("Presione cualquier tecla para continuar..."); Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        bool nombreEsValido=false;
                        do
                        {
                            // 1. Pedir la entrada
                            Console.Write("Agregue el punto de origen del viaje: ");
                            origen= Console.ReadLine()!;
                            // 2. Validar la entrada
                            nombreEsValido = !string.IsNullOrWhiteSpace(origen) && origen.All(char.IsLetter);
                            // 3. Si no es válido, mostrar el error
                            if (!nombreEsValido)
                            {
                                Console.WriteLine("Nombre de origen inválido. No se permiten dígitos, caracteres especiales ni espacios en blanco.");
                            }
                        // 4. Repetir el bucle si el nombre NO es válido
                        } while (!nombreEsValido);
                        nombreEsValido=false;
                        do
                        {
                            // 1. Pedir la entrada
                            Console.Write("Agrege el destino del viaje: ");
                            destino= Console.ReadLine()!;
                            // 2. Validar la entrada
                            nombreEsValido = !string.IsNullOrWhiteSpace(destino) && destino.All(char.IsLetter);
                            // 3. Si no es válido, mostrar el error
                            if (!nombreEsValido)
                            {
                                Console.WriteLine("Nombre de destino inválido. No se permiten dígitos, caracteres especiales ni espacios en blanco.");
                            }
                        // 4. Repetir el bucle si el nombre NO es válido
                        } while (!nombreEsValido);
                        Console.WriteLine("La ruta creada es de "+ origen + " a " + destino);
                        Console.WriteLine("A que chofer desea asignar esta ruta?");    
                        Console.WriteLine("0. Salir");
                        for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0) ; i++) //Muestra la lista de choferes
                        {   
                                if (Choferes_Rutas_Horario[i,0] == null)
                                {
                                    Console.WriteLine((i+1)+". [Vacío]");
                                }
                                else
                                {   
                                    Console.WriteLine((i+1)+". "+ Choferes_Rutas_Horario[i,0]);
                                }                            
                        }
                        Console.Write("Seleccione el numero del chofer a escoger: ");
                        if (int.TryParse(Console.ReadLine(), out Num_Chofer) && Num_Chofer >= 1 && Num_Chofer <= 6)
                        {
                            Num_Chofer--;
                            if (!string.IsNullOrEmpty(Choferes_Rutas_Horario[Num_Chofer, 0]))
                            {
                                Choferes_Rutas_Horario[Num_Chofer, 1] = origen + "/" + destino;
                                Console.WriteLine("Ruta asignada correctamente.");
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
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Seleccione el numero del chofer al que le desea asignar un horario: \n");
                        Console.WriteLine("0. Salir");
                        for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0) ; i++) //Muestra la lista de choferes
                        {   
                                if (Choferes_Rutas_Horario[i,0] == null)
                                {
                                    Console.WriteLine((i+1)+". [Vacío]");
                                }
                                else
                                {   
                                    Console.WriteLine((i+1)+". "+ Choferes_Rutas_Horario[i,0]);
                                }                            
                        }
                        Console.Write("Seleccione el numero del chofer a escoger: ");
                        if (int.TryParse(Console.ReadLine(), out Num_Chofer) && Num_Chofer >= 1 && Num_Chofer <= 6)
                        {
                            Num_Chofer--;
                            if (!string.IsNullOrEmpty(Choferes_Rutas_Horario[Num_Chofer, 0]))
                            {   
                                Console.Clear();
                                Console.WriteLine("Seleccione el horario para el chofer: ");
                                Console.WriteLine("1. Mañana ");
                                Console.WriteLine("2. Tarde ");
                                Console.Write("Ingrese el horario del chofer ("+ Choferes_Rutas_Horario[Num_Chofer,0]+"): ");
                                while(!int.TryParse(Console.ReadLine(), out horario) || horario < 1 || horario > 2)
                                {
                                    Console.Write("\nOpcion invalida \nSeleccione una opcion del 1 al 4: ");
                                }
                                if (horario==1)
                                {
                                    Choferes_Rutas_Horario[Num_Chofer,2]="Mañana";
                                }
                                else if (horario==2)
                                {
                                    Choferes_Rutas_Horario[Num_Chofer,2]="Tarde";
                                }
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
                        Console.Write("Presione cualquier tecla para continuar..."); Console.ReadKey();
                        break;
                    case 4:
                        Console.Write("Saliendo");
                        Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(350);
                        break;
                }
            }    
        }
    }
}