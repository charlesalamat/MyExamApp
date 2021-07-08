using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIR.VIEWMODEL.ViewModels
{
    public class RetirementSetupViewModel : BaseViewModel
    {
        public double GuaranteedIssue { get; set; }
        public int MaxAgeLimit { get; set; }
        public int MinAgeLimit { get; set; }
        public int MinimumRange { get; set; }
        public int MaximumRange { get; set; }
        public int Increments { get; set; }
    }
}
