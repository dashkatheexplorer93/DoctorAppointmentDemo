namespace DoctorAppointmentDemo.UI;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello and Welcome to the Doctor Appointment System!");
        
        var serializationService = SerializationTypeChooser.ChooseSerializationType();
        var menu = new Menu(serializationService);
        menu.Launch();
    }
}