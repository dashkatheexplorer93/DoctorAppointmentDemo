using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Repositories;

public class AppointmentRepository : GenericRepository<Appointment>
{
    public override string Path { get; set; }
    public override int LastId { get; set; }

    public AppointmentRepository()
    {
        var result = ReadFromAppSettings();

        Path = result.Database.Appointments.Path;
        LastId = result.Database.Appointments.LastId;
    }

    public override void ShowInfo(Appointment appointment)
    {
        Console.WriteLine($"--- {appointment.GetType().Name} Informmation ---");

        foreach (var prop in appointment.GetType().GetProperties())
        {
            Console.WriteLine($"{prop.Name}: {prop.GetValue(appointment)}");
        }
    }

    protected override void SaveLastId()
    {
        var result = ReadFromAppSettings();
        result.Database.Doctors.LastId = LastId;

        File.WriteAllText(Constants.AppSettingsPath, result.ToString());
    }
}