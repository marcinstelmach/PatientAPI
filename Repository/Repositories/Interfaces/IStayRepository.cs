using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Repository.Repositories.Interfaces
{
    public interface IStayRepository
    {
        Task<Stay> FindById(int stayId);
        Task<List<Stay>> GetAll();
        Task<Stay> Update(int stayId, Stay stay);
        Task Delete(int stayId);
        Task<Stay> Add(Stay stay);
        Task SaveChanges();
    }
}
