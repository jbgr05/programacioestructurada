using System;

namespace EmpleadosApp
{
    class Program
    {
        // Definición de la estructura Direccion
        struct Direccion
        {
            public string Calle;
            public string Ciudad;
            public string CodigoPostal;
        }

        // Definición de la estructura Empleado
        struct Empleado
        {
            public string Nombre;
            public int Edad;
            public double Salario;
            public Direccion DireccionEmpleado;
        }

        static void Main(string[] args)
        {
            const int tamano = 3;
            Empleado[] empleados = new Empleado[tamano];

            // Ingresar información de los empleados
            for (int i = 0; i < tamano; i++)
            {
                Console.WriteLine($"Introduzca los datos del empleado {i + 1}:");
                Console.Write("Nombre: ");
                empleados[i].Nombre = Console.ReadLine();
                Console.Write("Edad: ");
                empleados[i].Edad = int.Parse(Console.ReadLine());
                Console.Write("Salario: ");
                empleados[i].Salario = double.Parse(Console.ReadLine());

                Console.WriteLine("Introduzca la dirección del empleado:");
                Console.Write("Calle: ");
                empleados[i].DireccionEmpleado.Calle = Console.ReadLine();
                Console.Write("Ciudad: ");
                empleados[i].DireccionEmpleado.Ciudad = Console.ReadLine();
                Console.Write("Código Postal: ");
                empleados[i].DireccionEmpleado.CodigoPostal = Console.ReadLine();
            }

            // Utilizar un ciclo foreach para imprimir la información de los empleados
            foreach (var empleado in empleados)
            {
                Console.WriteLine("\nInformación del Empleado:");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Edad: {empleado.Edad}");
                Console.WriteLine($"Salario: {empleado.Salario}");
                Console.WriteLine("Dirección:");
                Console.WriteLine($"  Calle: {empleado.DireccionEmpleado.Calle}");
                Console.WriteLine($"  Ciudad: {empleado.DireccionEmpleado.Ciudad}");
                Console.WriteLine($"  Código Postal: {empleado.DireccionEmpleado.CodigoPostal}");
            }
        }
    }
}
