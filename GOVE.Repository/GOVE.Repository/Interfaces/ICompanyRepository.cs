using GOVE.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOVE.Repository.Interfaces
{
    public interface ICompanyRepository
    {
        public Task<CompanyMasterRequest> Get_CompanyMasterRepository(int? companyId);
    }
}
