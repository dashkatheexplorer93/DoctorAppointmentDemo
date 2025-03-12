using DoctorAppointmentDemo.Data.Configuration;
using DoctorAppointmentDemo.Domain.Entities;

namespace DoctorAppointmentDemo.Data.Repositories;

public class PatientRepository : GenericRepository<Patient>
{
    public override string Path { get; set; }
    public override int LastId { get; set; }
    
    public PatientRepository()
    {
        var result = ReadFromAppSettings();

        Path = result.Database.Doctors.Path;
        LastId = result.Database.Doctors.LastId;
    }
    
    public override void ShowInfo(Patient patient)
    {
        Console.WriteLine($"--- {patient.GetType().Name} Informmation ---");

        foreach (var prop in patient.GetType().GetProperties())
        {
            Console.WriteLine($"{prop.Name}: {prop.GetValue(patient)}");
        }
    }

    protected override void SaveLastId()
    {
        var result = ReadFromAppSettings();
        result.Database.Patients.LastId = LastId;

        File.WriteAllText(Constants.AppSettingsPath, result.ToString());
    }
}