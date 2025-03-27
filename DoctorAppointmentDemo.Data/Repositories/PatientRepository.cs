using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Repositories;

public class PatientRepository : GenericRepository<Patient>
{
    public override string Path { get; set; }
    
    public override int LastId { get; set; }
    
    private readonly ISerializationService _serializationService;
    
    public PatientRepository(ISerializationService serializationService) : base(serializationService)
    {
        _serializationService = serializationService;
        
        var result = ReadFromAppSettings();

        Path = result.Database.Patients.Path;
        LastId = result.Database.Patients.LastId;
    }
    
    public override void ShowInfo(Patient patient)
    {
        Console.WriteLine($"--- {patient.GetType().Name} Information ---");

        foreach (var prop in patient.GetType().GetProperties())
        {
            Console.WriteLine($"{prop.Name}: {prop.GetValue(patient)}");
        }
    }

    protected override void SaveLastId()
    {
        var result = ReadFromAppSettings();
        result.Database.Patients.LastId = LastId;

        // File.WriteAllText(Constants.AppSettingsPath, result.ToString());
        _serializationService.Serialize(Constants.WorkingFolder, Constants.AppSettingsFileNameWithoutExtension, result);
    }
}
