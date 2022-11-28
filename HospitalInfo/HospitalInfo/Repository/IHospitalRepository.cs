using HospitalInfo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalInfo.Repository
{
    public interface IHospitalRepository
    {
        Task<List<HospitalModel>> GetAll();
        Task<HospitalModel> GetByIdAsync(int Id);
        Task<int> AddHospitalAsync(HospitalModel hospitalModel);

        Task UpdateHospitalAsync(int Id, HospitalModel hospitalModel);
        Task DeleteHospitalAsync(int Id);
    }
}