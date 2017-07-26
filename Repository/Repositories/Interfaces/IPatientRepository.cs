using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Repository.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient> FindById(int patientId);
        Task<List<Patient>> GetAll();
        Task<Patient> Update(int patientId, Patient patient);
        Task Delete(int patientId);
        Task<Patient> Add(Patient patient);
        Task SaveChanges();
    }
}
