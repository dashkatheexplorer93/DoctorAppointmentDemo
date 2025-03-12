namespace DoctorAppointmentDemo.Data.Configuration;

public class AppSettings
{
        public DatabaseSettings Database { get; set; } = new();
}

public class DatabaseSettings
{
    public DoctorSettings Doctors { get; set; } = new();
    public PatientSettings Patients { get; set; } = new();
    public AppointmentSettings Appointments { get; set; } = new();
}

public class DoctorSettings
{
    public string Path { get; set; } = string.Empty;
    public int LastId { get; set; }
}

public class PatientSettings
{
    public string Path { get; set; } = string.Empty;
    public int LastId { get; set; }
}

public class AppointmentSettings
{
    public string Path { get; set; } = string.Empty;
    public int LastId { get; set; }
}