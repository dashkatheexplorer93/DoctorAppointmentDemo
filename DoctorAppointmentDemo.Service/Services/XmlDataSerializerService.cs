using System.Xml.Serialization;
using DoctorAppointmentDemo.Data.Interfaces;

namespace DoctorAppointmentDemo.Service.Services;

public class XmlDataSerializerService : ISerializationService
{
    public void Serialize<T>(string workingFolder, string fileNameWithoutExtension, T data)
    {
        var serializer = new XmlSerializer(typeof(T));
        var path = Path.Combine(workingFolder, $"{fileNameWithoutExtension}.xml");
        using var stream = new FileStream(path, FileMode.OpenOrCreate);
        serializer.Serialize(stream, data);
    }

    public T Deserialize<T>(string workingFolder, string fileNameWithoutExtension)
    {
        var serializer = new XmlSerializer(typeof(T));
        var path = Path.Combine(workingFolder, $"{fileNameWithoutExtension}.xml");
        using var stream = new FileStream(path, FileMode.OpenOrCreate);
        return (T)serializer.Deserialize(stream)!;
    }
}