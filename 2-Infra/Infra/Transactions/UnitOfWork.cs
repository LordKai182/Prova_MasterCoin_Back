using Infra.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MasterCoinContext _context;


        public UnitOfWork(MasterCoinContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
