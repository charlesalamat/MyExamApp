using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIR.DOMAIN.Entities
{
    public class ConsumerProfile : BaseModel
    {
        public string ConsumerName { get; set; }
        public double BasicSalary { get; set; }
        public DateTime Birthdate { get; set; }

        public ICollection<ConsumerBenefitResult> ConsumerBenefitResults { get; set; }
    }
}
