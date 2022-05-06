using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Transactions
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
