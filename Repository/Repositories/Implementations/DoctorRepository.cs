using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implementations
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _db;

        public DoctorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Doctor> FindById(int doctorId)
        {
            return await _db.Doctors.FirstOrDefaultAsync(s => s.DoctorId == doctorId);
        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _db.Doctors.ToListAsync();
        }

        public async Task<Doctor> Update(int doctorId, Doctor doctor)
        {
            var restult = await FindById(doctorId);
            if (restult == null)
            {
                throw new Exception($"Doctor with id: {doctorId} not found");
            }

            _db.Doctors.Update(doctor);
            await SaveChanges();
            return doctor;
        }

        public async Task Delete(int doctorId)
        {
            var result = await FindById(doctorId);
            if (result == null)
            {
                throw new Exception($"Doctor with id: {doctorId} not found");
            }

            _db.Doctors.Remove(result);
            await SaveChanges();
        }

        public async Task<Doctor> Add(Doctor doctor)
        {
            await _db.AddAsync(doctor);
            await SaveChanges();
            return doctor;
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Doctor> GetPatientDoctor(int patientId, int doctorId)
        {
            var result = await _db.Doctors
                .Join(_db.Orders,
                    doctor => doctor.DoctorId,
                    order => order.DoctorId,
                    (doctor, order) => new { Doctor = doctor, Order = order })
                    .Where(s => s.Doctor.DoctorId == doctorId)
                .Join(_db.Stays,
                    orderDoctor => orderDoctor.Order.StayId,
                    stay => stay.StayId,
                    (orderDoctor, stay) => new { OrderDoctor = orderDoctor, Stay = stay })
                .FirstOrDefaultAsync(s => s.Stay.PatientId == patientId);
            return result.OrderDoctor.Doctor;
        }

        public async Task<List<Doctor>> GetPatientDoctors(int patientId)
        {
            var result = await _db.Doctors
                .Join(_db.Orders,
                    doctor => doctor.DoctorId,
                    order => order.DoctorId,
                    (doctor, order) => new { Doctor = doctor, Order = order })
                .Join(_db.Stays,
                    orderDoctor => orderDoctor.Order.StayId,
                    stay => stay.StayId,
                    (orderDoctor, stay) => new { OrderDoctor = orderDoctor, Stay = stay })
                .Where(s => s.Stay.PatientId == patientId)
                .Select(s => s.OrderDoctor.Doctor)
                .ToListAsync();

            return result;
        }
    }
}
