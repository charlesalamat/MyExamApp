using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIR.VIEWMODEL.ViewModels
{
    public class RetirementSetupViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "Guaranteed Issue")]
        public double GuaranteedIssue { get; set; }
        [Required]
        [Display(Name = "Max Age Limit")]
        public int MaxAgeLimit { get; set; }
        [Required]
        [Display(Name = "Min Age Limit")]
        public int MinAgeLimit { get; set; }
        [Required]
        [Display(Name = "Minimum Range")]
        public int MinimumRange { get; set; }
        [Required]
        [Display(Name = "Maximum Range")]
        public int MaximumRange { get; set; }
        [Required]
        [Display(Name = "Increments")]
        public int Increments { get; set; }
    }
}
