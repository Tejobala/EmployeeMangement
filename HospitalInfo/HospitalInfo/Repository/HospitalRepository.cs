using HospitalInfo.Data;
using HospitalInfo.Migrations;
using HospitalInfo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HospitalInfo.Repository
{
    public class HospitalRepository: IHospitalRepository
    {
        private readonly HospitalDbContext _context;

        public HospitalRepository(HospitalDbContext context)
        {
           _context = context;
        }

        public async Task<List<HospitalModel>> GetAll()
        {

            var records = await _context.Hospitals.Select(x => new HospitalModel
            {
               Id = x.Id,
                HospitalName = x.HospitalName,
                Description = x.Description,
                Address = x.Address,
                DateOfRegistration=x.DateOfRegistration
            }).ToListAsync();
            return records;
        }

        public async Task<HospitalModel> GetByIdAsync(int Id)
        {
            var records = await _context.Hospitals.Where(x => x.Id == Id).Select(x => new HospitalModel
            {
                Id = x.Id,
                HospitalName = x.HospitalName,
                Description = x.Description,
                Address = x.Address,
                DateOfRegistration = x.DateOfRegistration
            }).FirstOrDefaultAsync();
            return records;
        }
        public async Task<int> AddHospitalAsync(HospitalModel hospitalModel)
        {
            var hospital = new Data.Hospital()
            {
                Id = hospitalModel.Id,
                HospitalName = hospitalModel.HospitalName,
                Description = hospitalModel.Description,
                Address = hospitalModel.Address,
                DateOfRegistration = DateTime.Now
            };
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();
            return hospital.Id;
        }
        public async Task UpdateHospitalAsync(int Id, HospitalModel hospitalModel)
        {
            var hospital = await _context.Hospitals.FindAsync(Id);
            if (hospital != null)
            {
                hospital.HospitalName = hospitalModel.HospitalName;
                hospital.Description = hospitalModel.Description;
                hospital.Address = hospitalModel.Address;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteHospitalAsync(int Id)
        {
            var hospital = new Data.Hospital()
            {
                Id = Id
            };
            _context.Hospitals.Remove(hospital);
            await _context.SaveChangesAsync();
        }
    }
}
