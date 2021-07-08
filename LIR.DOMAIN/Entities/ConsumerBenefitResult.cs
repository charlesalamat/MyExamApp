using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIR.DOMAIN.Entities
{
    public class ConsumerBenefitResult : BaseModel
    {
        public DateTime TransactionDateTime { get; set; }
        public int Multiple { get; set; }
        public double BenefitsAmountQuotation { get; set; }
        public double PendedAmount { get; set; }
        public string Benefits { get; set; }

        public Guid ConsumerProfileId { get; set; }
        public ConsumerProfile ConsumerProfile { get; set; }
    }
}
