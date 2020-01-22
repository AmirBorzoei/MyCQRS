using System;
using System.Collections.Generic;

namespace Sales.SalesManagement.Domain.Factor.Services
{
    public interface IFactorRepository
    {
        Factor Get(Guid id);

        IList<Factor> GetAll();

        void Create(Factor factor);
    }
}