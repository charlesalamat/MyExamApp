using LIR.DOMAIN.Entities;
using LIR.VIEWMODEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIR.INFRASTRUCTURE.Interfaces
{
    public interface IRetirementSetupRepository
    {
        bool CreateSetup(RetirementSetup model);
        RetirementSetup GetSetup();
        bool UpdateSetup(RetirementSetup model);
    }
}
