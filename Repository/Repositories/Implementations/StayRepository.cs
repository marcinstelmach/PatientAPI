﻿using System;
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
    public class StayRepository : IStayRepository
    {
        private readonly ApplicationDbContext _db;

        public StayRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Stay> FindById(int stayId)
        {
            return await _db.Stays.FirstOrDefaultAsync(s => s.StayId == stayId);
        }

        public async Task<List<Stay>> GetAll()
        {
            return await _db.Stays.ToListAsync();
        }

        public async Task<Stay> Update(int stayId, Stay stay)
        {
            var result = await FindById(stayId);
            if (result==null)
            {
                throw new Exception($"Stay id:{stayId} not found");
            }

            result.Department = stay.Department;
            result.From = stay.From;
            result.To = stay.To;
            result.Orders = stay.Orders;
            result.Room = stay.Room;
            _db.Stays.Update(result);
            await SaveChanges();
            return result;
        }

        public async Task Delete(int stayId)
        {
            var result = await FindById(stayId);
            if (result==null)
            {
                throw new Exception($"Stay id:{stayId} not found");
            }

            _db.Stays.Remove(result);
            await SaveChanges();
        }

        public async Task<Stay> Add(Stay stay)
        {
            var patient = await _db.Patients.FirstOrDefaultAsync(s => s.PatientId == stay.PatientId);
            if (patient==null)
            {
                throw new Exception($"Patient with id:{stay.PatientId} not found");
            }

            await _db.Stays.AddAsync(stay);
            await SaveChanges();
            return stay;
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Stay> GetPatientStay(int patientId, int stayId)
        {
            //var result = _db.Stays
            //                .Join(_db.Patients,
            //                stays => stays.PatientId,
            //                patients => patients.PatientId,
            //                (stays, patients) => new {Stay=stays, Patient=patients})
            //            .Where()

            return await _db.Stays.FirstOrDefaultAsync(s => s.PatientId==patientId && s.StayId==stayId);
        }

        public async Task<List<Stay>> GetAllPatientStays(int patientId)
        {
            return await _db.Stays.Where(s => s.PatientId == patientId).ToListAsync();
        }
    }
}
