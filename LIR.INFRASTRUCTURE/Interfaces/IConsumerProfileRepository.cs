using LIR.DOMAIN.Entities;
using LIR.VIEWMODEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIR.INFRASTRUCTURE.Interfaces
{
    public interface IConsumerProfileRepository
    {
        /// <summary>
        /// Complete computation request
        /// </summary>
        /// <param name="model">Consumer Profile Model</param>
        /// <returns></returns>
        ConsumerProfileViewModel RequestComputation(ConsumerProfile model);

        /// <summary>
        /// Get all consumer records
        /// </summary>
        /// <returns>Consumer Profile ViewModel List</returns>
        List<ConsumerProfileViewModel> GetAll();

        /// <summary>
        /// Get consumer profile record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ConsumerProfileViewModel GetById(Guid id);
    }
}
