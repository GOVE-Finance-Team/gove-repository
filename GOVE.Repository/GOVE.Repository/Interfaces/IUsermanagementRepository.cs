using GOVE.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOVE.Repository.Interfaces
{
    public interface IUsermanagementRepository
    {
        public Task<UserTranslanderEntites> getUsertranslander(int? companyId, int? userId);
    }
}
