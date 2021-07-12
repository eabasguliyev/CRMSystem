using System.Collections;
using System.Collections.Generic;
using CrmSystem.Domain.Models;

namespace CrmSystem.Domain.Repositories
{
    public interface IContractRepository:IRepository<Contract>
    {
        IEnumerable<Contract> GetContracts(int id);
    }
}