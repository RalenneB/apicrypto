using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicrypto.Data;
using apicrypto.Dtos.DcaInvestmentDto;
using apicrypto.Helpers;
using apicrypto.Interfaces;
using apicrypto.Models;
using Microsoft.EntityFrameworkCore;

namespace apicrypto.Repository
{
    public class DcaInvestmentRepository : IDcaInvestmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DcaInvestmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DcaInvestment> CreateAsync(DcaInvestment dcaInvestmentModel)
        {
            await _context.DcaInvestments.AddAsync(dcaInvestmentModel);
            await _context.SaveChangesAsync();
            return dcaInvestmentModel;
        }

        public Task<bool> DcaInvestmentExists(int id)
        {
           return _context.DcaInvestments.AnyAsync(s=> s.Id == id);
        }

        public async Task<DcaInvestment?> DeleteAsync(int id)
        {
            var dcaInvestmentModel = await _context.DcaInvestments.FirstOrDefaultAsync(x=> x.Id == id);
            if(dcaInvestmentModel == null)
            {
                return null;
            }
             _context.DcaInvestments.Remove(dcaInvestmentModel);
             await _context.SaveChangesAsync();
             return dcaInvestmentModel;
        }

        public async Task<List<DcaInvestment>> GetAllAsync(QueryObject query)
        {
            // filtering

          var investments = _context.DcaInvestments.Include(c => c.Comments).AsQueryable();
          if(!string.IsNullOrWhiteSpace(query.CryptoType)) // BTC, ETH etc
          {
             investments = investments.Where(s => s.CryptoType.Contains(query.CryptoType));
          }

           if (query.CryptoPrice.HasValue) // price
            {
                investments = investments.Where(s => s.CryptoPrice == query.CryptoPrice.Value);
            }

          if(query.StartDate.HasValue) //startDate
          {
            investments = investments.Where(s => s.StartDate == query.StartDate);
          }

           if(query.EndDate.HasValue) //endDate
          {
            investments = investments.Where(s => s.EndDate == query.EndDate);
          }


       
        return await investments.ToListAsync();           
        }

        public async Task<DcaInvestment?> GetByIdAsync(int id)
        {
            return await _context.DcaInvestments.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<DcaInvestment?> UpdateAsync(int id, UpdateDcaInvestmentRequestDto dcaInvestmentDo)
        {
           var existingDcaInvestment = await _context.DcaInvestments.FirstOrDefaultAsync(x => x.Id == id);

           if(existingDcaInvestment == null) 
           { 
            return null;
           }
            existingDcaInvestment.CryptoPrice = dcaInvestmentDo.CryptoPrice;
            existingDcaInvestment.CryptoType = dcaInvestmentDo.CryptoType;
            existingDcaInvestment.StartDate = dcaInvestmentDo.StartDate;
            existingDcaInvestment.EndDate = dcaInvestmentDo.EndDate;
            existingDcaInvestment.InvestedAmount = dcaInvestmentDo.InvestedAmount;

            await _context.SaveChangesAsync();
            return existingDcaInvestment;
        }
    }
}