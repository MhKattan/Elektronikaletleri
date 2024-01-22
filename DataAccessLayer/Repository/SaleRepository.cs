using BusinessLayer.Common;
using DataAccessLayer.Data;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class SaleRepository : GenericRepository<Sale>, ISaleRepository
    {
        private readonly ApplicationDbContext _context;
        public SaleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
