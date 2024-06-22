using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apicrypto.Dtos.DcaInvestmentDto;
using apicrypto.Helpers;
using apicrypto.Models;

namespace apicrypto.Interfaces
{
    public interface IDcaInvestmentRepository
    {
        Task<List<DcaInvestment>> GetAllAsync(QueryObject query);
        Task<DcaInvestment?> GetByIdAsync(int id);
        Task<DcaInvestment> CreateAsync(DcaInvestment dcaInvestmentModel);
        Task<DcaInvestment?> UpdateAsync(int id, UpdateDcaInvestmentRequestDto dcaInvestmentDo);
        Task<DcaInvestment?> DeleteAsync(int id);
        Task<bool> DcaInvestmentExists(int id);

        
    }
}