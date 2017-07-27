using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Models;

namespace Repository.DAL
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Doctors.Any())
            {
                return;   // DB has been seeded
            }

            var patients = new Patient[]
            {
            new Patient{FirstName = "Jan", LastName = "Kowalski", City = "Radom", Street = "Szypka"},
            new Patient{FirstName = "Michał", LastName = "Wereszczak", City = "Buda", Street = "brak"},
            };
            foreach (var patient in patients)
            {
                context.Patients.Add(patient);
            }
            context.SaveChanges();

            var stays = new Stay[]
            {
                new Stay{PatientId = 1, From = DateTime.Today, To = DateTime.Today.AddDays(14), Department = "Family", Room = "15"},
                new Stay{PatientId = 1, From = DateTime.Today.AddDays(16), To = DateTime.Today.AddDays(19), Department = "Dentist", Room = "A01"},
                new Stay{PatientId = 2, From = DateTime.Today.AddDays(-3), To = DateTime.Today.AddDays(2), Department = "Surgery", Room = "B505"},
                new Stay{PatientId = 2, From = DateTime.Today.AddDays(6), To = DateTime.Today.AddDays(9), Department = "Surgery", Room = "C18"},
            };
            foreach (var stay in stays)
            {
                context.Stays.Add(stay);
            }
            context.SaveChanges();

            

            var doctors = new Doctor[]
            {
                new Doctor{FirstName = "Marcin", LastName = "Stelmach", Specjalization = "Surgeon"},
                new Doctor{FirstName = "Stefan", LastName = "Piszczel", Specjalization = "Urologist"},
            };
            foreach (var doctor in doctors)
            {
                context.Doctors.Add(doctor);
            }
            context.SaveChanges();

            var tests = new Test[]
            {
                new Test{Name = "Blood", Date = DateTime.Today.AddHours(5),Result = "55Mg/l"},
                new Test{Name = "HandCut", Date = DateTime.Today.AddDays(2).AddHours(5),Result = "cutted"},
                new Test{Name = "Cholesterol", Date = DateTime.Today.AddDays(18).AddHours(5),Result = "22Mg/l"},
                new Test{Name = "Blood", Date = DateTime.Today.AddHours(1),Result = "0.5Mg/l"},
                new Test{Name = "Cholesterol", Date = DateTime.Today.AddDays(6).AddHours(5),Result = "555Mg/l"},
            };
            foreach (var test in tests)
            {
                context.Tests.Add(test);
            }
            context.SaveChanges();

            var orders = new Order[]
            {
                new Order{DoctorId = 1, StayId = 1, TestId = 1, Date = DateTime.Today.AddDays(2)},
                new Order{DoctorId = 2, StayId = 1, TestId = 2, Date = DateTime.Today.AddDays(3)},
                new Order{DoctorId = 1, StayId = 2, TestId = 3, Date = DateTime.Today.AddDays(18)},
                new Order{DoctorId = 2, StayId = 3, TestId = 4, Date = DateTime.Today},
                new Order{DoctorId = 1, StayId = 4, TestId = 5, Date = DateTime.Today.AddDays(6)},
            };
            foreach (var order in orders)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();

        }
    }
}
