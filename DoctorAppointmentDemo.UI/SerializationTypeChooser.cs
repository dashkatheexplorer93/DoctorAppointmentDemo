using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Service.Services;
using DoctorAppointmentDemo.UI.Enums;

namespace DoctorAppointmentDemo.UI;

public static class SerializationTypeChooser
{
    public static ISerializationService ChooseSerializationType()
    {
        while (true)
        {
            Console.WriteLine("Choose serialization type: 1 - JSON, 2 - XML: ");

            if (!int.TryParse(Console.ReadLine(), out var choice))
            {
                Console.WriteLine($"Invalid input. Please enter number 1 or 2.");
            }

            switch (choice)
            {
                case (int)SerializationTypes.Json:
                    return new JsonDataSerializerService();
                case (int)SerializationTypes.Xml: 
                    return new XmlDataSerializerService();
                default: 
                    Console.WriteLine("Invalid input. Please enter number 1 or 2.");
                    continue;
            }
        }
    }
}