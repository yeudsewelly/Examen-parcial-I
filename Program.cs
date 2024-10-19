//Parcial I Programación

using System;
using System.Collections.Generic;
using System.Linq;

class Empleado
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public double Salario { get; set; }

    //Datos del empleado
    public Empleado(string cedula, string nombre, string direccion, string telefono, double salario)
    {
        Cedula = cedula;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Salario = salario;
    }
}

//Clase Menú
class Menu
{
    private List<Empleado> empleados = new List<Empleado>();

    public void MostrarMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("\nMenú Principal:");
            Console.WriteLine("1. Agregar Empleado");
            Console.WriteLine("2. Consultar Empleado por Cédula");
            Console.WriteLine("3. Modificar Empleado");
            Console.WriteLine("4. Borrar Empleado");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarEmpleado();
                    break;
                case 2:
                    ConsultarEmpleado();
                    break;
                case 3:
                    ModificarEmpleado();
                    break;
                case 4:
                    BorrarEmpleado();
                    break;
                case 5:
                    InicializarArreglos();
                    break;
                case 6:
                    MostrarSubMenuReportes();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del sistema...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 0);
    }

    private void AgregarEmpleado()
    {
        Console.Write("Ingrese cédula: ");
        string cedula = Console.ReadLine();
        Console.Write("Ingrese nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese dirección: ");
        string direccion = Console.ReadLine();
        Console.Write("Ingrese teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Ingrese salario: ");
        double salario = double.Parse(Console.ReadLine());

        empleados.Add(new Empleado(cedula, nombre, direccion, telefono, salario));
        Console.WriteLine("Empleado agregado exitosamente.");
    }

    private void ConsultarEmpleado()
    {
        Console.Write("Ingrese la cédula del empleado: ");
        string cedula = Console.ReadLine();

        var empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
        if (empleado != null)
        {//Definiciones
            Console.WriteLine($"Cédula: {empleado.Cedula}");
            Console.WriteLine($"Nombre: {empleado.Nombre}");
            Console.WriteLine($"Dirección: {empleado.Direccion}");
            Console.WriteLine($"Teléfono: {empleado.Telefono}");
            Console.WriteLine($"Salario: {empleado.Salario}");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }
    //Ejecucion de datos
    private void ModificarEmpleado()
    {
        Console.Write("Ingrese la cédula del empleado a modificar: ");
        string cedula = Console.ReadLine();

        var empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
        if (empleado != null)
        {
            Console.Write("Ingrese nuevo nombre: ");
            empleado.Nombre = Console.ReadLine();
            Console.Write("Ingrese nueva dirección: ");
            empleado.Direccion = Console.ReadLine();
            Console.Write("Ingrese nuevo teléfono: ");
            empleado.Telefono = Console.ReadLine();
            Console.Write("Ingrese nuevo salario: ");
            empleado.Salario = double.Parse(Console.ReadLine());

            Console.WriteLine("Empleado modificado exitosamente.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    private void BorrarEmpleado()
    {
        Console.Write("Ingrese la cédula del empleado a borrar: ");
        string cedula = Console.ReadLine();

        var empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
        if (empleado != null)
        {
            empleados.Remove(empleado);
            Console.WriteLine("Empleado borrado exitosamente.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    private void InicializarArreglos()
    {
        empleados.Clear();
        Console.WriteLine("Arreglos inicializados exitosamente.");
    }

    private void MostrarSubMenuReportes()
    {
        int opcion;
        do
        {//Reportes
            Console.WriteLine("\nSubmenú de Reportes:");
            Console.WriteLine("1. Listar todos los empleados ordenados por nombre");
            Console.WriteLine("2. Calcular y mostrar el promedio de los salarios");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ListarEmpleadosPorNombre();
                    break;
                case 2:
                    CalcularPromedioSalarios();
                    break;
                case 0:
                    Console.WriteLine("Volviendo al menú principal...");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 0);
    }
    //Listado de empleados
    private void ListarEmpleadosPorNombre()
    {
        var empleadosOrdenados = empleados.OrderBy(e => e.Nombre).ToList();
        Console.WriteLine("\nLista de empleados ordenados por nombre:");
        foreach (var empleado in empleadosOrdenados)
        {
            Console.WriteLine($"Nombre: {empleado.Nombre}, Cédula: {empleado.Cedula}");
        }
    }

    private void CalcularPromedioSalarios()
    {
        if (empleados.Count > 0)
        {
            double promedio = empleados.Average(e => e.Salario);
            Console.WriteLine($"\nEl promedio de los salarios es: {promedio}");
        }
        else
        {
            Console.WriteLine("\nNo hay empleados registrados para calcular el promedio.");
        }
    }
}

class Program
{
    static void Main()
    {
        Menu menu = new Menu();
        menu.MostrarMenu();
    }
}
