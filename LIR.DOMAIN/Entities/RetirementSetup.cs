using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIR.DOMAIN.Entities
{
    public class RetirementSetup : BaseModel
    {
        public double GuaranteedIssue { get; set; }
        [MaxLength(3)]
        public int MaxAgeLimit { get; set; }
        [MaxLength(3)]
        public int MinAgeLimit { get; set; }
        public int MinimumRange { get; set; }
        public int MaximumRange { get; set; }
        public int Increments { get; set; }
    }
}
