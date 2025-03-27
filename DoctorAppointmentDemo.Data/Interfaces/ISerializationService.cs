namespace DoctorAppointmentDemo.Data.Interfaces;

public interface ISerializationService
{
    void Serialize<T>(string workingFolder, string fileNameWithoutExtension, T data);
    
    T Deserialize<T>(string workingFolder, string fileNameWithoutExtension);
}