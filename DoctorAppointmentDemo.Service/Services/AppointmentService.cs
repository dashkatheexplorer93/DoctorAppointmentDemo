using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;

namespace DoctorAppointmentDemo.Service.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IGenericRepository<Appointment> _appointmentRepository;

    public AppointmentService(ISerializationService serializationService)
    {
        _appointmentRepository = new AppointmentRepository(serializationService);
    }

    public Appointment Create(Appointment appointment)
    {
        return _appointmentRepository.Create(appointment);
    }
    
    public bool Delete(int id)
    {
        return _appointmentRepository.Delete(id);
    }
    
    public Appointment? Get(int id)
    {
        return _appointmentRepository.GetById(id);
    }

    public IEnumerable<Appointment> GetAll()
    {
        return _appointmentRepository.GetAll();
    }

    public Appointment Update(int id, Appointment appointment)
    {
        return _appointmentRepository.Update(id, appointment);
    }
}