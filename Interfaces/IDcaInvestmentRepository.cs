using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicrypto.Models;

namespace apicrypto.Interfaces
{
    public interface IDcaInvestmentRepository
    {
        Task<List<DcaInvestment>> GetAllAsync();
        Task<DcaInvestment?> GetByIdAsync(int id);
        
    }
}