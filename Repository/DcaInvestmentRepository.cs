using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicrypto.Data;
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
        public async Task<List<DcaInvestment>> GetAllAsync()
        {
           return await  _context.DcaInvestments.ToListAsync();
        }

        public async Task<DcaInvestment?> GetByIdAsync(int id)
        {
            return await _context.DcaInvestments.FindAsync(id);
        }
    }
}