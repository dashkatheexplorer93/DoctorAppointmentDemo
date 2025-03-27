using DoctorAppointmentDemo.Data.Interfaces;
using DoctorAppointmentDemo.Data.Repositories;
using DoctorAppointmentDemo.Domain.Entities;
using DoctorAppointmentDemo.Service.Interfaces;

namespace DoctorAppointmentDemo.Service.Services;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;

    public DoctorService(ISerializationService serializationService)
    {
        _doctorRepository = new DoctorRepository(serializationService);
    }

    public Doctor Create(Doctor doctor)
    {
        return _doctorRepository.Create(doctor);
    }

    public bool Delete(int id)
    {
        return _doctorRepository.Delete(id);
    }

    public Doctor? Get(int id)
    {
        return _doctorRepository.GetById(id);
    }

    public IEnumerable<Doctor> GetAll()
    {
        return _doctorRepository.GetAll();
    }

    public Doctor Update(int id, Doctor doctor)
    {
        return _doctorRepository.Update(id, doctor);
    }
}