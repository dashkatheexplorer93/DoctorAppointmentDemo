using DoctorAppointmentDemo.Data.Interfaces;
using Newtonsoft.Json;

namespace DoctorAppointmentDemo.Service.Services;

public class JsonDataSerializerService : ISerializationService
{
    public void Serialize<T>(string workingFolder, string fileNameWithoutExtension, T data)
    {
        var path = Path.Combine(workingFolder, $"{fileNameWithoutExtension}.json");
        File.WriteAllText(path, JsonConvert.SerializeObject(data, Formatting.Indented));
    }

    public T Deserialize<T>(string workingFolder, string fileNameWithoutExtension)
    {
        var path = Path.Combine(workingFolder, $"{fileNameWithoutExtension}.json");
        var json = File.ReadAllText(path);

        return JsonConvert.DeserializeObject<T>(json)!;
    }
}