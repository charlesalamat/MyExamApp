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
        /// Get consumer computation history
        /// </summary>
        /// <param name="consumerName">Consumer Name</param>
        /// <returns>Consumer Profile ViewModel</returns>
        ConsumerProfileViewModel ViewMyHistory(string consumerName);
    }
}
