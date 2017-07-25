using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Patient> FindById(int patientId)
        {
            return await _db.Patients.FirstOrDefaultAsync(s => s.PatientId == patientId);
        }

        public async Task<List<Patient>> GetAll()
        {
            return await _db.Patients.ToListAsync();
        }

        public async Task<Patient> Update(int patientId, Patient patient)
        {
            var result = await FindById(patientId);
            if (result==null)
            {
                throw new Exception($"Patient wth id: {patientId} not found");
            }

            _db.Patients.Update(patient);
            await SaveChanges();
            return patient;
        }

        public async Task Delete(int patientId)
        {
            var result = await FindById(patientId);
            if (result==null)
            {
                throw new Exception($"Patient wth id: {patientId} not found");
            }
            _db.Patients.Remove(result);
            await SaveChanges();
        }

        public async Task<Patient> Add(Patient patient)
        {
            await _db.Patients.AddAsync(patient);
            await SaveChanges();
            return patient;
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
