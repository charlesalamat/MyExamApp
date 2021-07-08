using LIR.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace LIR.DAL
{
    public class LIRDbContext : DbContext
    {
        public LIRDbContext(DbContextOptions<LIRDbContext> options) : base(options)
        {

        }
        public DbSet<RetirementSetup> RetirementSetups { get; set; }
        public DbSet<ConsumerProfile> ConsumerProfiles { get; set; }
        public DbSet<ConsumerBenefitResult> ConsumerBenefitResults { get; set; }
    }
}
