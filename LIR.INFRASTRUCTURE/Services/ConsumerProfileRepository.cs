using LIR.DAL;
using LIR.DOMAIN.Entities;
using LIR.INFRASTRUCTURE.Interfaces;
using LIR.VIEWMODEL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIR.INFRASTRUCTURE.Services
{
    public class ConsumerProfileRepository : IConsumerProfileRepository
    {
        private readonly LIRDbContext _context;

        public ConsumerProfileRepository(LIRDbContext context)
        {
            _context = context;
        }

        public ConsumerProfileViewModel RequestComputation(ConsumerProfile model)
        {
            try
            {
                //check if consumer have record
                var consumerExist = _context.ConsumerProfiles.FirstOrDefault(x => x.ConsumerName == model.ConsumerName.Trim());
                if (consumerExist == null)
                {
                    //new record
                    _context.ConsumerProfiles.Add(model);
                    _context.SaveChanges();
                }
                else
                {
                    //update record
                    var modifyProfile = _context.ConsumerProfiles.FirstOrDefault(x => x.ConsumerName == model.ConsumerName.Trim());
                    modifyProfile.BasicSalary = model.BasicSalary;
                    modifyProfile.Birthdate = model.Birthdate;

                    _context.Entry(modifyProfile).State = EntityState.Modified;
                    _context.SaveChanges();

                    model = modifyProfile;
                }
                var result = GenerateBenefit(model);

                if (result != null)
                {
                    var bindRequest = from data in result.ConsumerBenefitResults
                                      select new ConsumerBenefitResultViewModel()
                                      {
                                          Id = data.Id,
                                          TransactionDateTime = data.TransactionDateTime,
                                          Multiple = data.Multiple,
                                          BenefitsAmountQuotation = data.BenefitsAmountQuotation,
                                          PendedAmount = data.PendedAmount,
                                          Benefits = data.Benefits
                                      };

                    return new ConsumerProfileViewModel()
                    {
                        ConsumerName = result.ConsumerName.Trim(),
                        BasicSalary = result.BasicSalary,
                        Birthdate = result.Birthdate,
                        ConsumerBenefitResults = bindRequest.OrderByDescending(x => x.TransactionDateTime).ToList()
                    };
                }
                return new ConsumerProfileViewModel();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ConsumerProfileViewModel ViewMyHistory(string consumerName)
        {
            try
            {
                var result = _context.ConsumerProfiles.FirstOrDefault(x => x.ConsumerName == consumerName.Trim());
                if (result != null)
                {
                    var getAllRequest = _context.ConsumerBenefitResults.Where(x => x.ConsumerProfileId == result.Id);

                    var bindRequest = from data in getAllRequest
                                      select new ConsumerBenefitResultViewModel()
                                      {
                                          Id = data.Id,
                                          TransactionDateTime = data.TransactionDateTime,
                                          Multiple = data.Multiple,
                                          BenefitsAmountQuotation = data.BenefitsAmountQuotation,
                                          PendedAmount = data.PendedAmount,
                                          Benefits = data.Benefits
                                      };

                    return new ConsumerProfileViewModel()
                    {
                        ConsumerName = result.ConsumerName.Trim(),
                        BasicSalary = result.BasicSalary,
                        Birthdate = result.Birthdate,
                        ConsumerBenefitResults = bindRequest.OrderByDescending(x => x.TransactionDateTime).ToList()
                    };
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private ConsumerProfile GenerateBenefit(ConsumerProfile model)
        {
            try
            {
                var retirementSetup = _context.RetirementSetups.FirstOrDefault();

                //serves as unique transaction date & time
                var TransactionDateTime = DateTime.Now;

                //consumer age
                var consumerAge = DateTime.Now.Year - model.Birthdate.Year;

                var incrementedValue = retirementSetup.MinimumRange;

                //loop only if incremented value is within min & max range
                while (incrementedValue <= retirementSetup.MaximumRange)
                {
                    var benefit = new ConsumerBenefitResult();
                    benefit.TransactionDateTime = TransactionDateTime;
                    benefit.ConsumerProfile = model;
                    benefit.Multiple = incrementedValue;
                    benefit.BenefitsAmountQuotation = model.BasicSalary * incrementedValue;

                    //check if age is within min & max age limit
                    if (consumerAge < retirementSetup.MinAgeLimit && consumerAge > retirementSetup.MaxAgeLimit)
                    {
                        //not valid age = approved
                        benefit.PendedAmount = 0;
                        benefit.Benefits = benefit.BenefitsAmountQuotation.ToString();
                    }
                    else
                    {
                        //valid age
                        benefit.PendedAmount = benefit.BenefitsAmountQuotation - retirementSetup.GuaranteedIssue;
                        benefit.PendedAmount = benefit.PendedAmount < 0 ? 0 : benefit.PendedAmount;
                        benefit.Benefits = benefit.BenefitsAmountQuotation > retirementSetup.GuaranteedIssue ? "For approval" : benefit.BenefitsAmountQuotation.ToString();
                    }
                    _context.ConsumerBenefitResults.Add(benefit);
                    _context.SaveChanges();

                    incrementedValue += retirementSetup.Increments;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
