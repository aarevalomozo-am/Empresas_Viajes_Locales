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
            for (int i = 0; i < Comisiones.Length; i++)
            {
                Comisiones[i] = 0.00;
            }
            string [,] Choferes_Rutas_Horario = new string [6,3]; //Matriz para almacenar choferes y rutas asignadas.
            for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0) ; i++) //Muestra la lista de choferes
            {   
                Choferes_Rutas_Horario[i,0] ="[Vacío]";                         
            }
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
                        Administracion_boletas(Choferes_Rutas_Horario, Comisiones, Boletas);
                        break;
                    case 4:
                        Console.Clear();
                        Reiniciar_sistema(Choferes_Rutas_Horario, Comisiones, Boletas);
                        Console.WriteLine("\nEl sistema se ha reiniciado correctamente.\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Gracias por usar el sistema de gestión de transporte. ¡Hasta luego!");
                        break;
                }

            }
        }
        static void Administracion_choferes(string[,] Choferes_Rutas_Horario, double[] Comisiones, int[] Boletas)
    {
        int opcion = 0;
        int Num_Chofer = 0;
        string nombre_chofer = "";

        while (opcion != 4)
        {
            // 1. LÓGICA DE CONTEO Y ESTANDARIZACIÓN DE CHOFERES
            int cantidad_choferes = 0;
            for (int k = 0; k < Choferes_Rutas_Horario.GetLength(0); k++)
            {
                // Estandariza celdas realmente vacías (null o "") a "[Vacío]" para la interfaz
                if (string.IsNullOrEmpty(Choferes_Rutas_Horario[k, 0]) || string.IsNullOrWhiteSpace(Choferes_Rutas_Horario[k, 0]))
                {
                    Choferes_Rutas_Horario[k, 0] = "[Vacío]";
                }
                if (Choferes_Rutas_Horario[k, 0] != "[Vacío]")
                {
                    cantidad_choferes++;
                }
            }
            Console.Clear(); // Menu de administración de choferes
            Console.WriteLine("----Menu administración de choferes----");
            Console.WriteLine($"Choferes registrados: {cantidad_choferes}"); // Muestra el conteo
            Console.WriteLine("1. Mostrar nombre de los choferes existentes");
            Console.WriteLine("2. Agregar o eliminar choferes");
            Console.WriteLine("3. Comision por transporte");
            Console.WriteLine("4. Salir");
            Console.Write("Selecciones una opcion: ");
            while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
            {
                Console.Write("\nOpcion invalida \nSeleccione una opcion del 1 al 4: ");
            }
            switch (opcion)
            {
                case 1: // Imprimir el listado de choferes.
                    Console.Clear();
                    Console.WriteLine("Listado de choferes: ");
                    for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0); i++) // Muestra la lista de choferes
                    {
                        Console.WriteLine((i + 1) + ". " + Choferes_Rutas_Horario[i, 0]);
                    }
                    Console.Write("Presione cualquier tecla para continuar..."); Console.ReadKey();
                    break;

                case 2: // Agregar o eliminar choferes
                    Console.Clear();
                    Console.WriteLine("Seleccione que desea realizar:");
                    Console.WriteLine("0. Salir \n1. Agregar chofer \n2. Eliminar chofer");
                    Console.Write("Opcion: ");
                    while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 0 || opcion > 2)
                    {
                        Console.Write("\nOpcion invalida \nSeleccione una opcion del 0 al 2: ");
                    }

                    if (opcion == 1) // Agregar choferes
                    {
                        // Lógica de validación del nombre con bucle do-while
                        bool nombreEsValido = false;
                        do
                        {
                            Console.Write("Ingrese el nombre del chofer a agregar: ");
                            nombre_chofer = Console.ReadLine()!;
                            
                            // Validación: no vacío y todos los caracteres deben ser letras
                            nombreEsValido = !string.IsNullOrWhiteSpace(nombre_chofer) && nombre_chofer.All(char.IsLetter);

                            if (!nombreEsValido)
                            {
                                Console.WriteLine("Nombre inválido. No se permiten dígitos, caracteres especiales ni espacios en blanco.");
                            }
                        } while (!nombreEsValido);

                        Console.WriteLine("Seleccione la posición donde desea agregar el chofer:");
                        for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0); i++) // Muestra la lista de choferes
                        {
                            Console.WriteLine((i + 1) + ". " + Choferes_Rutas_Horario[i, 0]);
                        }
                        Console.Write("Posicion: ");

                        // Valida la posición y si está dentro de los límites
                        if (int.TryParse(Console.ReadLine(), out Num_Chofer) && Num_Chofer >= 1 && Num_Chofer <= Choferes_Rutas_Horario.GetLength(0))
                        {
                            Num_Chofer--;
                            if (Choferes_Rutas_Horario[Num_Chofer, 0] == "[Vacío]")
                            {
                                Choferes_Rutas_Horario[Num_Chofer, 0] = nombre_chofer;
                                
                                // Opcional: Limpiar otras columnas para el nuevo chofer
                                for (int col = 1; col < Choferes_Rutas_Horario.GetLength(1); col++)
                                {
                                    Choferes_Rutas_Horario[Num_Chofer, col] = ""; 
                                }
                                Comisiones[Num_Chofer] = 0.00;
                                Boletas[Num_Chofer] = 0;
                                
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
                    else if (opcion == 2) // Eliminar choferes
                    {
                        // 3. RESTRICCIÓN DE ELIMINACIÓN
                        if (cantidad_choferes == 0) // Usa la variable de conteo corregida
                        {
                            Console.WriteLine("No hay choferes registrados para eliminar. \nPresione cualquier tecla para continuar...");
                        }
                        else
                        {
                            Console.WriteLine("Choferes disponibles:");
                            Console.WriteLine("0. Salir");
                            for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0); i++) // Muestra la lista de choferes
                            {
                                Console.WriteLine((i + 1) + ". " + Choferes_Rutas_Horario[i, 0]);
                            }
                            Console.Write("Seleccione el numero del chofer a eliminar: ");

                            if (int.TryParse(Console.ReadLine(), out Num_Chofer) && Num_Chofer >= 1 && Num_Chofer <= Choferes_Rutas_Horario.GetLength(0))
                            {
                                Num_Chofer--;
                                
                                // Verificar que la posición tenga un chofer válido antes de eliminar
                                if (Choferes_Rutas_Horario[Num_Chofer, 0] != "[Vacío]")
                                {
                                    // Limpiar todos los datos del chofer
                                    Choferes_Rutas_Horario[Num_Chofer, 0] = "[Vacío]"; // Establecer como [Vacío]
                                    for (int i = 1; i < Choferes_Rutas_Horario.GetLength(1); i++)
                                    {
                                        Choferes_Rutas_Horario[Num_Chofer, i] = ""; // Limpiar Ruta y Horario
                                    }
                                    Comisiones[Num_Chofer] = 0.00;
                                    Boletas[Num_Chofer] = 0;
                                    
                                    Console.WriteLine("Chofer eliminado correctamente.");
                                }
                                else
                                {
                                    Console.WriteLine("Esa posición ya está vacía.");
                                }
                            }
                            else if (Num_Chofer == 0)
                            {
                                Console.WriteLine("Operación cancelada.");
                            }
                            else
                            {
                                Console.WriteLine("Número de posición inválido.");
                            }
                        }
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Write("\nSaliendo");
                        Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(250); Console.Write("."); Thread.Sleep(350);
                    }
                    break;

                case 3:
                    Console.Clear();
                    // 1. Modificar y calcular el valor de las comisiones para todos los choferes
                    for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0); i++) 
                    {
                        if (Choferes_Rutas_Horario[i, 0] != "[Vacío]" && Comisiones != null)
                        {
                            int precio_total_ventas = Boletas[i] * 25000;
                            Comisiones[i] = precio_total_ventas * 0.45;
                        }
                        else
                        {
                        Comisiones[i] = 0.00; // Asegurarse de que la comisión es cero para espacios vacíos
                        }
                    }
    // 2. TÍTULO Y ENCABEZADOS MEJORADOS
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("--- 💰 TABLA DE COMISIÓN POR TRANSPORTE 💰 ---");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine();
    // Encabezado con tres columnas: No., CHOFER y COMISIÓN
                    Console.WriteLine("{0,-4} | {1,-30} | {2,12}", "No.", "CHOFER", "COMISIÓN");
                    Console.WriteLine(new string('-', 49));
    // 3. IMPRESIÓN DE DATOS Y CORRECCIÓN DE BUG
                    int contador_choferes_activos = 0;
                    for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0); i++)
                    {
                        string nombre = Choferes_Rutas_Horario[i, 0];
                        if (nombre != "[Vacío]") // Solo muestra choferes activos
                        { 
                            contador_choferes_activos++;
                            // Formato de tabla: {0,-4} | {1,-30} | {2,12:C2}
                            Console.WriteLine("{0,-4} | {1,-30} | {2,12}", (i + 1), nombre,  Comisiones[i]);
                        }
                    }
                    Console.WriteLine(new string('-', 49)); // Línea de cierre
    // 4. MENSAJE FINAL
                    if (contador_choferes_activos == 0)
                    {
                        Console.WriteLine("No hay choferes registrados.");
                    }
                    else
                    {
                        Console.WriteLine($"Total de choferes con comisión: {contador_choferes_activos}");
                    }   
                    Console.Write("\nPresione cualquier tecla para continuar..."); Console.ReadKey();
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
                    case 1: //Mostrar rutas con jornada de los choferes
                        Console.Clear();
                        Console.WriteLine("Listado de rutas asignadas a choferes: ");
                        for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0); i++)
                        {    
                            if (Choferes_Rutas_Horario[i,1] == null)
                            {
                                Choferes_Rutas_Horario[i,1] = "[Sin ruta asignada]";
                            }
                            if (Choferes_Rutas_Horario[i,2] == null)
                            {
                                Choferes_Rutas_Horario[i,2] = "[Sin jornada asignada]";
                            }
                            
                            Console.WriteLine((i+1)+". "+Choferes_Rutas_Horario[i,0]+ " -> " + Choferes_Rutas_Horario[i,1] + " | Jornada: " + Choferes_Rutas_Horario[i,2]);
                        }
                        Console.Write("Presione cualquier tecla para continuar..."); Console.ReadKey();
                        break;
                    case 2: //Configurar rutas a choferes
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
                    case 3: //Configurar horarios a choferes
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
                                Console.WriteLine("Seleccione el horario para el chofer ("+ Choferes_Rutas_Horario[Num_Chofer,0]+"): ");
                                Console.WriteLine("1. Mañana ");
                                Console.WriteLine("2. Tarde ");
                                Console.WriteLine("3. Eliminar asignacion establecida ");
                                Console.Write("Ingrese la opcion deseada: ");
                                while(!int.TryParse(Console.ReadLine(), out horario) || horario < 1 || horario > 3)
                                {
                                    Console.Write("\nOpcion invalida \nSeleccione una opcion del 1 al 2: ");
                                }
                                if (horario==1)
                                {   
                                    if (Choferes_Rutas_Horario[Num_Chofer,1] == "Mañana")
                                    {
                                        Console.WriteLine("El chofer ya tiene asignado ese horario.");
                                    }
                                    else
                                    {
                                        Choferes_Rutas_Horario[Num_Chofer,2]="Mañana";
                                    }
                                }
                                else if (horario==2)
                                {
                                    if (Choferes_Rutas_Horario[Num_Chofer,1] == "Tarde")
                                    {
                                        Console.WriteLine("El chofer ya tiene asignado ese horario.");
                                    }
                                    else
                                    {
                                        Choferes_Rutas_Horario[Num_Chofer,2]="Tarde";
                                    }
                                }
                                else if (horario==3)
                                {
                                    Choferes_Rutas_Horario[Num_Chofer,2]="";
                                    Console.WriteLine("Asignación de horario eliminada correctamente.");
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
        static void Administracion_boletas (string[,] Choferes_Rutas_Horario, double[] Comisiones, int[] Boletas)
        {   
            int opcion =0, num_ruta=0;
            while (opcion!=3)
            {   
                Console.Clear();
                Console.WriteLine("----Menu administración de boletas----");
                Console.WriteLine("1. Vender boletas");
                Console.WriteLine("2. Retirar boletas");
                Console.WriteLine("3. Reporte de boletas vendidas");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opcion: ");
                while(!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 3)
                {
                    Console.Write("\nOpcion invalida \nSeleccione una opcion del 1 al 3: ");
                }
                switch (opcion)
                {
                    case 1: 
                        Console.Clear();
                        Console.WriteLine("A que ruta desea viajar:");
                        for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0) ; i++) //Muestra la lista de choferes
                        {   
                                if (Choferes_Rutas_Horario[i,1] == null)
                                {
                                    Console.WriteLine((i+1)+". [Vacío]");
                                }
                                else
                                {   
                                    Console.WriteLine("|Ruta ("+(i+1)+"): " + Choferes_Rutas_Horario[i,1]+ " | Jornada: " + Choferes_Rutas_Horario[i,2]);
                                }                            
                        }
                        Console.Write("Seleccione el numero de la ruta a escoger: ");
                        while(!int.TryParse(Console.ReadLine(), out num_ruta) || num_ruta < 1 || num_ruta > 6)
                        {
                            Console.Write("\nOpcion invalida \nSeleccione una opcion del 1 al 6: ");
                        }
                        num_ruta--;
                        if (!string.IsNullOrEmpty(Choferes_Rutas_Horario[num_ruta, 1]))
                        {
                            Boletas[num_ruta] = Boletas[num_ruta] + 1;
                            Console.WriteLine("Boleta vendida correctamente para la ruta: " + Choferes_Rutas_Horario[num_ruta,1]);
                        }
                        else
                        {
                            Console.WriteLine("Esa posición está vacía.");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("De que ruta desea retirar boletas:");
                        for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0) ; i++) //Muestra la lista de choferes
                        {   
                                if (Choferes_Rutas_Horario[i,1] == null)
                                {
                                    Console.WriteLine((i+1)+". [Vacío]");
                                }
                                else
                                {   
                                    Console.WriteLine("|Ruta ("+(i+1)+"): " + Choferes_Rutas_Horario[i,1]+ " | Jornada: " + Choferes_Rutas_Horario[i,2]);
                                }                            
                        }
                        Console.Write("Seleccione el numero de la ruta a escoger: ");
                        while(!int.TryParse(Console.ReadLine(), out num_ruta) || num_ruta < 1 || num_ruta > 6)
                        {
                            Console.Write("\nOpcion invalida \nSeleccione una opcion del 1 al 6: ");
                        }
                        num_ruta--;
                        if (!string.IsNullOrEmpty(Choferes_Rutas_Horario[num_ruta, 1]))
                        {
                            if (Boletas[num_ruta] > 0)
                            {
                                Boletas[num_ruta] = Boletas[num_ruta] - 1;
                                Console.WriteLine("Boleta retirada correctamente para la ruta: " + Choferes_Rutas_Horario[num_ruta,1]);
                            }
                            else
                            {
                                Console.WriteLine("No hay boletas para retirar en esta ruta.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Esa posición está vacía.");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Reporte de boletas vendidas por ruta:");
                        for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0) ; i++) //Muestra la lista de choferes
                        {   
                                if (Choferes_Rutas_Horario[i,1] == null)
                                {
                                    Console.WriteLine((i+1)+". [Vacío]");
                                }
                                else
                                {   
                                    Console.WriteLine("|Ruta ("+(i+1)+"): " + Choferes_Rutas_Horario[i,1]+ " | Boletas vendidas: " + Boletas[i]);
                                }                            
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
        static void Reiniciar_sistema(string[,] Choferes_Rutas_Horario, double[] Comisiones, int[] Boletas)
        {
            for (int i = 0; i < Choferes_Rutas_Horario.GetLength(0); i++)
            {
                Choferes_Rutas_Horario[i, 0] = "[Vacío]";
                for (int j = 1; j < Choferes_Rutas_Horario.GetLength(1); j++)
                {
                    Choferes_Rutas_Horario[i, j] = "";
                }
                Comisiones[i] = 0.0;
                Boletas[i] = 0;
            }
        }
    }
}