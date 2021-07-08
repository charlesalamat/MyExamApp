using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIR.VIEWMODEL.ViewModels
{
    public class ConsumerProfileViewModel : BaseViewModel
    {
        public string ConsumerName { get; set; }
        public double BasicSalary { get; set; }
        public DateTime Birthdate { get; set; }

        public IList<ConsumerBenefitResultViewModel> ConsumerBenefitResults { get; set; }
    }

    public class ConsumerBenefitResultViewModel : BaseViewModel
    {
        public DateTime TransactionDateTime { get; set; }
        public int Multiple { get; set; }
        public double BenefitsAmountQuotation { get; set; }
        public double PendedAmount { get; set; }
        public string Benefits { get; set; }
    }
}
