using System;
using System.Collections.Generic;

class Robot
{
    public string Name { get; private set; }
    public string Model { get; }

    public Robot(string model)
    {
        Model = model;
        Reset();
    }

    public void Reset()
    {
        Name = GenerateName();
    }

    private string GenerateName()
    {
        var random = new Random();
        string letters = $"{(char)('A' + random.Next(26))}{(char)('A' + random.Next(26))}";
        string digits = random.Next(1000).ToString("D3");
        return $"{letters}{digits}";
    }
}

class RobotFactory
{
    private List<Robot> robots = new List<Robot>();

    public Robot CreateRobot(string model)
    {
        var robot = new Robot(model);
        robots.Add(robot);
        return robot;
    }

    public void ResetRobot(int position)
    {
        if (position >= 0 && position < robots.Count)
        {
            robots[position].Reset();
        }
    }

    public Robot GetRobotAtPosition(int position)
    {
        return position >= 0 && position < robots.Count ? robots[position] : null;
    }

    public void RemoveRobot(int position)
    {
        if (position >= 0 && position < robots.Count)
        {
            robots.RemoveAt(position);
        }
    }

    public void ListAllRobots()
    {
        Console.WriteLine("Lista de todos los robots:");
        for (int i = 0; i < robots.Count; i++)
        {
            Console.WriteLine($"Position {i}: Name - {robots[i].Name}, Model - {robots[i].Model}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        RobotFactory factory = new RobotFactory();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Generar Robot");
            Console.WriteLine("2. Resetear Robot");
            Console.WriteLine("3. Mostrar Posicion de Robot");
            Console.WriteLine("4. Eliminar Robot de su Posición");
            Console.WriteLine("5. Lista de Todos los Robots");
            Console.WriteLine("6. Salir");
            Console.Write("Escoje tu opción: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Opcion Invalida. Escoje un numero.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Modelo; (R2D2, C3PO, BBB): ");
                    string model = Console.ReadLine();
                    factory.CreateRobot(model);
                    Console.WriteLine("Nuevo Robot Creado.");
                    break;
                case 2:
                    Console.Write("Posicion a resetar: ");
                    int resetPosition;
                    if (!int.TryParse(Console.ReadLine(), out resetPosition))
                    {
                        Console.WriteLine("Posición invalida.");
                        continue;
                    }
                    factory.ResetRobot(resetPosition);
                    Console.WriteLine("Robot resetado.");
                    break;
                case 3:
                    Console.Write("Posición a mostrar: ");
                    int showPosition;
                    if (!int.TryParse(Console.ReadLine(), out showPosition))
                    {
                        Console.WriteLine("Posición invalida.");
                        continue;
                    }
                    var robot = factory.GetRobotAtPosition(showPosition);
                    if (robot != null)
                    {
                        Console.WriteLine($"Robot at position {showPosition}: Name - {robot.Name}, Model - {robot.Model}");
                    }
                    else
                    {
                        Console.WriteLine("Posición invalida.");
                    }
                    break;
                case 4:
                    Console.Write("Posición del robot a eliminar: ");
                    int removePosition;
                    if (!int.TryParse(Console.ReadLine(), out removePosition))
                    {
                        Console.WriteLine("Posición invalida.");
                        continue;
                    }
                    factory.RemoveRobot(removePosition);
                    Console.WriteLine("Robot eliminado.");
                    break;
                case 5:
                    factory.ListAllRobots();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción invalida ( numero del 1 al 6).");
                    break;
                    
            }
        }
    }
}
