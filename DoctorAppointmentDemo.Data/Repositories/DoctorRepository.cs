using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities; 

namespace DoctorAppointmentDemo.Data.Repositories;

public class DoctorRepository : GenericRepository<Doctor>, IDoctorRepository
{
    public override string Path { get; set; }
    
    public override int LastId { get; set; }
    
    private readonly ISerializationService _serializationService;

    public DoctorRepository(ISerializationService serializationService) : base(serializationService)
    {
        _serializationService = serializationService;
        
        var result = ReadFromAppSettings();

        Path = result.Database.Doctors.Path;
        LastId = result.Database.Doctors.LastId;
    }

    public override void ShowInfo(Doctor doctor)
    {
        Console.WriteLine($"--- {doctor.GetType().Name} Information ---");

        foreach (var prop in doctor.GetType().GetProperties())
        {
            Console.WriteLine($"{prop.Name}: {prop.GetValue(doctor)}");
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
