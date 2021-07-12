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
        /// <summary>
        /// Create setup setting
        /// </summary>
        /// <param name="model">Retirement Setup Model</param>
        /// <returns>true = saved || false = failed</returns>
        bool CreateSetup(RetirementSetup model);

        /// <summary>
        /// Get setup setting for computation
        /// </summary>
        /// <returns>Retirement Setup Model</returns>
        RetirementSetup GetSetup();

        /// <summary>
        /// Update setup setting
        /// </summary>
        /// <param name="model">Retirement Setup Model</param>
        /// <returns>true = saved || false = failed</returns>
        bool UpdateSetup(RetirementSetup model);
    }
}
