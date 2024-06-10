using System;

namespace ProductosApp
{
    class Program
    {
        // Definición de la estructura Producto
        struct Producto
        {
            public string Nombre;
            public double Precio;
            public int Cantidad;
            public bool Categoria; // true == alimentación, false == general
        }

        static void Main(string[] args)
        {
            const int categorias = 2; // 0: alimentación, 1: general
            const int tamano = 5;
            Producto[,] productos = new Producto[categorias, tamano];
            int[] contador = new int[categorias]; // Para llevar cuenta de productos por categoría
            int opcion;

            do
            {
                Console.WriteLine("Menú:");
                Console.WriteLine("1. Agregar un producto de alimentación");
                Console.WriteLine("2. Agregar un producto de otra categoría");
                Console.WriteLine("3. Mostrar todos los productos de alimentación");
                Console.WriteLine("4. Mostrar todos los productos de la categoría general");
                Console.WriteLine("5. Calcular el importe total de los productos almacenados");
                Console.WriteLine("6. Calcular el total de los productos de cada categoría");
                Console.WriteLine("7. Salir del programa");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        AgregarProducto(productos, contador, true);
                        break;
                    case 2:
                        AgregarProducto(productos, contador, false);
                        break;
                    case 3:
                        MostrarProductos(productos, 0, contador[0]);
                        break;
                    case 4:
                        MostrarProductos(productos, 1, contador[1]);
                        break;
                    case 5:
                        CalcularImporteTotal(productos, contador);
                        break;
                    case 6:
                        CalcularTotalProductosPorCategoria(contador);
                        break;
                    case 7:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }
            } while (opcion != 7);
        }

        static void AgregarProducto(Producto[,] productos, int[] contador, bool esAlimentacion)
        {
            int indiceCategoria = esAlimentacion ? 0 : 1;
            if (contador[indiceCategoria] < 5)
            {
                Console.WriteLine($"Introduzca los datos del producto {(esAlimentacion ? "de alimentación" : "de otra categoría")}:");
                Console.Write("Nombre: ");
                productos[indiceCategoria, contador[indiceCategoria]].Nombre = Console.ReadLine();
                Console.Write("Precio: ");
                productos[indiceCategoria, contador[indiceCategoria]].Precio = double.Parse(Console.ReadLine());
                Console.Write("Cantidad: ");
                productos[indiceCategoria, contador[indiceCategoria]].Cantidad = int.Parse(Console.ReadLine());
                productos[indiceCategoria, contador[indiceCategoria]].Categoria = esAlimentacion;
                contador[indiceCategoria]++;
                Console.WriteLine("Producto guardado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se pueden guardar más productos en esta categoría.");
            }
        }

        static void MostrarProductos(Producto[,] productos, int categoria, int cantidad)
        {
            Console.WriteLine(categoria == 0 ? "Productos de alimentación:" : "Productos de categoría general:");
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"Nombre: {productos[categoria, i].Nombre}");
                Console.WriteLine($"Precio: {productos[categoria, i].Precio}");
                Console.WriteLine($"Cantidad: {productos[categoria, i].Cantidad}");
                Console.WriteLine();
            }
        }

        static void CalcularImporteTotal(Producto[,] productos, int[] contador)
        {
            double totalImporte = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < contador[i]; j++)
                {
                    totalImporte += productos[i, j].Precio * productos[i, j].Cantidad;
                }
            }
            Console.WriteLine($"El importe total de los productos almacenados es: {totalImporte}");
        }

        static void CalcularTotalProductosPorCategoria(int[] contador)
        {
            Console.WriteLine($"Total de productos de alimentación: {contador[0]}");
            Console.WriteLine($"Total de productos de categoría general: {contador[1]}");
        }
    }
}
