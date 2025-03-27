using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Repositories;

public class AppointmentRepository : GenericRepository<Appointment>
{
    private readonly ISerializationService _serializationService;
    public override string Path { get; set; }
    public override int LastId { get; set; }

    public AppointmentRepository(ISerializationService serializationService) : base(serializationService)
    {
        _serializationService = serializationService;
        
        var result = ReadFromAppSettings();

        Path = result.Database.Appointments.Path;
        LastId = result.Database.Appointments.LastId;
    }

    public override void ShowInfo(Appointment appointment)
    {
        Console.WriteLine($"--- {appointment.GetType().Name} Information ---");

        foreach (var prop in appointment.GetType().GetProperties())
        {
            Console.WriteLine($"{prop.Name}: {prop.GetValue(appointment)}");
        }
    }

    protected override void SaveLastId()
    {
        var result = ReadFromAppSettings();
        result.Database.Doctors.LastId = LastId;
        
        // File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        _serializationService.Serialize(Constants.WorkingFolder, Constants.AppSettingsFileNameWithoutExtension, result);
    }
}
