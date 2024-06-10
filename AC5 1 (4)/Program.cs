using System;

namespace TeatroApp
{
    class Program
    {
        // Definición de la estructura Reserva
        struct Reserva
        {
            public string NombreCliente;
            public string ApellidoCliente;
            public string NumeroTelefono;
            public int AsientoReservado;
        }

        static void Main(string[] args)
        {
            const int tamanoAsientos = 10;
            const int tamanoReservas = 5;
            bool[] asientos = new bool[tamanoAsientos];
            Reserva[] reservas = new Reserva[tamanoReservas];
            int contadorReservas = 0;
            int opcion;

            do
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Realizar una nueva reserva");
                Console.WriteLine("2. Mostrar el estado actual de los asientos");
                Console.WriteLine("3. Mostrar todas las reservas realizadas");
                Console.WriteLine("4. Salir del programa");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        if (contadorReservas < tamanoReservas)
                        {
                            RealizarReserva(asientos, reservas, ref contadorReservas);
                        }
                        else
                        {
                            Console.WriteLine("No se pueden realizar más reservas.");
                        }
                        break;
                    case 2:
                        MostrarEstadoAsientos(asientos);
                        break;
                    case 3:
                        MostrarReservas(reservas, contadorReservas);
                        break;
                    case 4:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            } while (opcion != 4);
        }

        static void RealizarReserva(bool[] asientos, Reserva[] reservas, ref int contadorReservas)
        {
            Console.Write("Introduzca el nombre del cliente: ");
            string nombre = Console.ReadLine();
            Console.Write("Introduzca el apellido del cliente: ");
            string apellido = Console.ReadLine();
            Console.Write("Introduzca el número de teléfono del cliente: ");
            string telefono = Console.ReadLine();

            MostrarEstadoAsientos(asientos);
            Console.Write("Seleccione un número de asiento (0-9): ");
            int asiento = int.Parse(Console.ReadLine());

            if (asiento >= 0 && asiento < asientos.Length && !asientos[asiento])
            {
                asientos[asiento] = true;
                reservas[contadorReservas] = new Reserva { NombreCliente = nombre, ApellidoCliente = apellido, NumeroTelefono = telefono, AsientoReservado = asiento };
                contadorReservas++;
                Console.WriteLine("Reserva realizada exitosamente.");
            }
            else
            {
                Console.WriteLine("Asiento no válido o ya está ocupado. Intente nuevamente.");
            }
        }

        static void MostrarEstadoAsientos(bool[] asientos)
        {
            Console.WriteLine("Estado actual de los asientos:");
            for (int i = 0; i < asientos.Length; i++)
            {
                Console.WriteLine($"Asiento {i}: {(asientos[i] ? "Ocupado" : "Disponible")}");
            }
        }

        static void MostrarReservas(Reserva[] reservas, int contadorReservas)
        {
            Console.WriteLine("Reservas realizadas:");
            for (int i = 0; i < contadorReservas; i++)
            {
                Console.WriteLine($"Reserva {i + 1}:");
                Console.WriteLine($"  Nombre del Cliente: {reservas[i].NombreCliente}");
                Console.WriteLine($"  Apellido del Cliente: {reservas[i].ApellidoCliente}");
                Console.WriteLine($"  Número de Teléfono: {reservas[i].NumeroTelefono}");
                Console.WriteLine($"  Asiento Reservado: {reservas[i].AsientoReservado}");
            }
        }
    }
}
