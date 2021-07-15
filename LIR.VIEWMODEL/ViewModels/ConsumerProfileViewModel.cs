using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIR.VIEWMODEL.ViewModels
{
    public class ConsumerProfileViewModel : BaseViewModel
    {
        private IList<ConsumerBenefitResultViewModel> _consumerBenefitResultViewModels;
        [Required]
        [Display(Name = "Consumer Name")]
        public string ConsumerName { get; set; }
        [Required]
        [Display(Name = "Basic Salary")]
        public double BasicSalary { get; set; }
        [Required]
        [Display(Name = "Birth Date")]
        public DateTime Birthdate { get; set; }
        public string BirthdateStr { get; set; }

        public IList<ConsumerBenefitResultViewModel> ConsumerBenefitResults
        {
            get { return _consumerBenefitResultViewModels; }
            set { _consumerBenefitResultViewModels = value; }
        }
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
