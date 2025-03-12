using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Domain.Enums;
using DoctorAppointmentDemo.Service.Interfaces;
using DoctorAppointmentDemo.Service.Services;

namespace DoctorAppointmentDemo.UI;

public class Menu
{
    private readonly IDoctorService _doctorService = new DoctorService();

    public void Launch()
    {
        while (true)
        {
            Console.WriteLine("MENU:");
            Console.WriteLine("1. Show all doctors");
            Console.WriteLine("2. Add doctor");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Choose option by entering the relevant number: ");

            if (!int.TryParse(Console.ReadLine(), out var choice))
            {
                Console.WriteLine($"Invalid input. Please enter a number from 1 to 3.");
            }

            switch (choice)
            {
                case 1:
                    ShowDoctorsList();
                    break;
                case 2:
                    AddDoctor();
                    break;
                case 3:
                    Console.WriteLine("Take care of yourself, bye!");
                    return;
                default:
                    Console.WriteLine("Invalid input. Please enter a number from 1 to 3.");
                    break;
            }
        }
    }

    private void ShowDoctorsList()
    {
        Console.WriteLine("Current doctors list: ");
        var docs = _doctorService.GetAll();

        foreach (var doc in docs)
        {
            Console.WriteLine(doc.Name);
        }
    }

    private void AddDoctor() {
        Console.WriteLine("Enter doctor's name: ");
        var name = Console.ReadLine();

        Console.WriteLine("Enter doctor's surname: ");
        var surname = Console.ReadLine();

        Console.WriteLine("Enter doctor's years of experience: ");
        var yearsOfExperience = byte.Parse(Console.ReadLine());

        Console.WriteLine("Enter doctor's type (1 - Dentist, 2 - Dermatologist, 3 - FamilyDoctor, 4 - Paramedic): ");
        var doctorType = (DoctorTypes)int.Parse(Console.ReadLine());

        var newDoctor = new Doctor
        {
            Name = name,
            Surname = surname,
            Experience = yearsOfExperience,
            DoctorType = doctorType
        };
        
        Console.WriteLine($"Adding doctor: {name} {surname}, experience: {yearsOfExperience} years, type: {doctorType}");

        _doctorService.Create(newDoctor);
    }
}