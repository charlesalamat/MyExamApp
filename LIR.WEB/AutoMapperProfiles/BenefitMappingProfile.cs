using AutoMapper;
using LIR.DOMAIN.Entities;
using LIR.VIEWMODEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIR.WEB.AutoMapperProfiles
{
    public class BenefitMappingProfile: Profile
    {
        public BenefitMappingProfile()
        {
            CreateMap<RetirementSetup, RetirementSetupViewModel>()
                .ReverseMap();

            CreateMap<ConsumerProfile, ConsumerProfileViewModel>()
                .ReverseMap();
        }
    }
}
