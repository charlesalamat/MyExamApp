using LIR.DAL;
using LIR.DOMAIN.Entities;
using LIR.INFRASTRUCTURE.Interfaces;
using LIR.VIEWMODEL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIR.INFRASTRUCTURE.Services
{
    public class RetirementSetupRepository : IRetirementSetupRepository
    {
        private readonly LIRDbContext _context;

        public RetirementSetupRepository(LIRDbContext context)
        {
            _context = context;
        }
        public bool CreateSetup(RetirementSetup model)
        {
            try
            {
                _context.RetirementSetups.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RetirementSetup GetSetup()
        {
            try
            {
                var setup = _context.RetirementSetups.FirstOrDefault();
                if (setup != null)
                {
                    return setup;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }

        public bool UpdateSetup(RetirementSetup model)
        {
            try
            {
                _context.Entry(model).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}