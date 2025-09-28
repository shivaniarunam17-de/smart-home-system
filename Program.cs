dude using System;
using System.Collections.Generic;

class SmartDevice
{
    public int Id;
    public string Type;
    public string Status; 

    public SmartDevice(int id, string type)
    {
        Id = id;
        Type = type;
        Status = "Off";
    }

    public void TurnOn()
    {
        Status = "On";
        Console.WriteLine($"{Type} {Id} turned On.");
    }

    public void TurnOff()
    {
        Status = "Off";
        Console.WriteLine($"{Type} {Id} turned Off.");
    }

    public void ShowStatus()
    {
        Console.WriteLine($"{Type} {Id} Status: {Status}");
    }
}

class SmartHome
{
    private List<SmartDevice> devices = new List<SmartDevice>();

    public void AddDevice(SmartDevice device)
    {
        devices.Add(device);
        Console.WriteLine($"{device.Type} {device.Id} added to Smart Home.");
    }

    public void ShowAllDevices()
    {
        Console.WriteLine("---- All Devices ----");
        if (devices.Count == 0)
        {
            Console.WriteLine("No devices in Smart Home.");
        }
        foreach (var d in devices)
        {
            d.ShowStatus();
        }
    }

    public SmartDevice GetDeviceById(int id)
    {
        foreach (var d in devices)
        {
            if (d.Id == id) return d;
        }
        return null;
    }
}

class Program
{
    static void Main()
    {
        SmartHome home = new SmartHome();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nSmart Home Menu: 1-Add Device 2-Turn On 3-Turn Off 4-Show Devices 5-Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Device ID (number): ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.Write("Enter Device Type (Light/Thermostat/Door): ");
                        string type = Console.ReadLine();
                        home.AddDevice(new SmartDevice(id, type));
                    }
                    else Console.WriteLine("Invalid ID. Must be a number.");
                    break;

                case "2":
                    Console.Write("Enter Device ID to Turn On: ");
                    if (int.TryParse(Console.ReadLine(), out int idOn))
                    {
                        SmartDevice devOn = home.GetDeviceById(idOn);
                        if (devOn != null) devOn.TurnOn();
                        else Console.WriteLine("Device not found.");
                    }
                    else Console.WriteLine("Invalid input.");
                    break;

                case "3":
                    Console.Write("Enter Device ID to Turn Off: ");
                    if (int.TryParse(Console.ReadLine(), out int idOff))
                    {
                        SmartDevice devOff = home.GetDeviceById(idOff);
                        if (devOff != null) devOff.TurnOff();
                        else Console.WriteLine("Device not found.");
                    }
                    else Console.WriteLine("Invalid input.");
                    break;

                case "4":
                    home.ShowAllDevices();
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}