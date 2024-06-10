using System;
using System.Collections.Generic;
using System.Linq;

public class Producto
{
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public int Cantidad { get; set; }

    public Producto(string nombre, string categoria, decimal precio, int cantidad)
    {
        Nombre = nombre;
        Categoria = categoria;
        Precio = precio;
        Cantidad = cantidad;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, Categoría: {Categoria}, Precio: {Precio:C}, Cantidad: {Cantidad}";
    }
}

public class Almacen
{
    private List<Producto> productos;
    private const int MaxProductos = 20;

    public Almacen()
    {
        productos = new List<Producto>
        {
            new Producto("Laptop", "Electrónica", 1000.99m, 10),
            new Producto("Mouse", "Electrónica", 25.50m, 50),
            new Producto("Teclado", "Electrónica", 45.00m, 30),
            new Producto("Monitor", "Electrónica", 150.75m, 20),
            new Producto("Cámara", "Electrónica", 250.00m, 15),
            new Producto("Camisa", "Ropa", 20.00m, 100),
            new Producto("Pantalones", "Ropa", 30.00m, 80),
            new Producto("Zapatos", "Ropa", 50.00m, 60),
            new Producto("Sombrero", "Ropa", 15.00m, 40),
            new Producto("Chaqueta", "Ropa", 70.00m, 30),
            new Producto("Manzana", "Alimentos", 0.50m, 200),
            new Producto("Banana", "Alimentos", 0.30m, 180),
            new Producto("Naranja", "Alimentos", 0.60m, 150),
            new Producto("Leche", "Alimentos", 1.20m, 100),
            new Producto("Pan", "Alimentos", 1.00m, 120),
            new Producto("Silla", "Muebles", 35.00m, 50),
            new Producto("Mesa", "Muebles", 75.00m, 20),
            new Producto("Sofá", "Muebles", 300.00m, 10),
            new Producto("Cama", "Muebles", 250.00m, 15),
            new Producto("Lámpara", "Muebles", 40.00m, 25),
            new Producto("Pelota", "Deportes", 15.00m, 70),
            new Producto("Bicicleta", "Deportes", 150.00m, 10),
            new Producto("Raqueta", "Deportes", 40.00m, 30),
            new Producto("Guantes", "Deportes", 20.00m, 50),
            new Producto("Pesas", "Deportes", 60.00m, 20),
            new Producto("Libro", "Libros", 10.00m, 80),
            new Producto("Revista", "Libros", 5.00m, 60),
            new Producto("Cuaderno", "Libros", 3.00m, 100),
            new Producto("Enciclopedia", "Libros", 25.00m, 20),
            new Producto("Comics", "Libros", 7.00m, 50),
            new Producto("Taladro", "Herramientas", 50.00m, 15),
            new Producto("Martillo", "Herramientas", 10.00m, 40),
            new Producto("Destornillador", "Herramientas", 5.00m, 70),
            new Producto("Llave Inglesa", "Herramientas", 8.00m, 60),
            new Producto("Alicate", "Herramientas", 12.00m, 50),
            new Producto("Perfume", "Cosméticos", 60.00m, 30),
            new Producto("Jabón", "Cosméticos", 2.00m, 100),
            new Producto("Shampoo", "Cosméticos", 5.00m, 80),
            new Producto("Crema", "Cosméticos", 10.00m, 50),
            new Producto("Maquillaje", "Cosméticos", 20.00m, 40),
            new Producto("Juguete", "Juguetes", 10.00m, 70),
            new Producto("Muñeca", "Juguetes", 15.00m, 50),
            new Producto("Carro", "Juguetes", 20.00m, 40),
            new Producto("Pelota de Juguete", "Juguetes", 8.00m, 80),
            new Producto("Rompecabezas", "Juguetes", 12.00m, 60)
        };
    }

    public bool AgregarProducto(Producto producto)
    {
        if (productos.Count >= MaxProductos)
        {
            Console.WriteLine("No se puede agregar más productos. Almacén lleno.");
            return false;
        }
        productos.Add(producto);
        return true;
    }

    public bool BorrarProducto(string nombre)
    {
        var producto = productos.FirstOrDefault(p => p.Nombre == nombre);
        if (producto == null)
        {
            Console.WriteLine("Producto no encontrado.");
            return false;
        }
        productos.Remove(producto);
        return true;
    }

    public bool EditarProducto(string nombre, string nuevoNombre, string nuevaCategoria, decimal nuevoPrecio, int nuevaCantidad)
    {
        var producto = productos.FirstOrDefault(p => p.Nombre == nombre);
        if (producto == null)
        {
            Console.WriteLine("Producto no encontrado.");
            return false;
        }
        producto.Nombre = nuevoNombre;
        producto.Categoria = nuevaCategoria;
        producto.Precio = nuevoPrecio;
        producto.Cantidad = nuevaCantidad;
        return true;
    }

    public void MostrarTodosLosProductos()
    {
        if (productos.Count == 0)
        {
            Console.WriteLine("No hay productos en el almacén.");
            return;
        }
        foreach (var producto in productos)
        {
            Console.WriteLine(producto);
        }
    }

    public void MostrarProductosPorCategoria(string categoria)
    {
        var productosPorCategoria = productos.Where(p => p.Categoria == categoria).ToList();
        if (productosPorCategoria.Count == 0)
        {
            Console.WriteLine("No hay productos en esta categoría.");
            return;
        }
        foreach (var producto in productosPorCategoria)
        {
            Console.WriteLine(producto);
        }
    }
}

public class Program
{
    public static void Main()
    {
        var almacen = new Almacen();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\nSeleccione una opción:");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Borrar producto");
            Console.WriteLine("3. Editar producto");
            Console.WriteLine("4. Mostrar todos los productos");
            Console.WriteLine("5. Mostrar productos por categoría");
            Console.WriteLine("6. Salir");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Nombre del producto: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Categoría del producto: ");
                    string categoria = Console.ReadLine();
                    Console.Write("Precio del producto: ");
                    decimal precio = decimal.Parse(Console.ReadLine());
                    Console.Write("Cantidad del producto: ");
                    int cantidad = int.Parse(Console.ReadLine());
                    almacen.AgregarProducto(new Producto(nombre, categoria, precio, cantidad));
                    break;

                case "2":
                    Console.Write("Nombre del producto a borrar: ");
                    string nombreBorrar = Console.ReadLine();
                    almacen.BorrarProducto(nombreBorrar);
                    break;

                case "3":
                    Console.Write("Nombre del producto a editar: ");
                    string nombreEditar = Console.ReadLine();
                    Console.Write("Nuevo nombre del producto: ");
                    string nuevoNombre = Console.ReadLine();
                    Console.Write("Nueva categoría del producto: ");
                    string nuevaCategoria = Console.ReadLine();
                    Console.Write("Nuevo precio del producto: ");
                    decimal nuevoPrecio = decimal.Parse(Console.ReadLine());
                    Console.Write("Nueva cantidad del producto: ");
                    int nuevaCantidad = int.Parse(Console.ReadLine());
                    almacen.EditarProducto(nombreEditar, nuevoNombre, nuevaCategoria, nuevoPrecio, nuevaCantidad);
                    break;

                case "4":
                    almacen.MostrarTodosLosProductos();
                    break;

                case "5":
                    Console.Write("Categoría de los productos a mostrar: ");
                    string categoriaMostrar = Console.ReadLine();
                    almacen.MostrarProductosPorCategoria(categoriaMostrar);
                    break;

                case "6":
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
