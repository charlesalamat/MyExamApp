using AutoMapper;
using LIR.DOMAIN.Entities;
using LIR.INFRASTRUCTURE.Interfaces;
using LIR.VIEWMODEL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LIR.WEB.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenefitController : ControllerBase
    {
        private readonly IRetirementSetupRepository _retirementSetupRepository;
        private readonly IConsumerProfileRepository _consumerProfileRepository;
        private readonly IMapper _mapper;

        public BenefitController(IRetirementSetupRepository retirementSetupRepository,
            IConsumerProfileRepository consumerProfileRepository,
            IMapper mapper)
        {
            _retirementSetupRepository = retirementSetupRepository;
            _mapper = mapper;
            _consumerProfileRepository = consumerProfileRepository;
        }

        [HttpPost("createSetup")]
        public IActionResult CreateSetup([FromBody]RetirementSetupViewModel viewModel)
        {
            try
            {
                var result = _retirementSetupRepository.CreateSetup(_mapper.Map<RetirementSetupViewModel, RetirementSetup>(viewModel));
                if (result)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("getSetup")]
        public IActionResult GetSetup()
        {
            try
            {
                var setup = _retirementSetupRepository.GetSetup();

                if (setup != null)
                {
                    return Ok(_mapper.Map<RetirementSetup, RetirementSetupViewModel>(setup));
                }
                return Ok(new RetirementSetupViewModel());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("configureSetup")]
        public IActionResult ConfigureSetup([FromBody]RetirementSetupViewModel viewModel)
        {
            try
            {

                var result = viewModel.Id != Guid.Empty ? _retirementSetupRepository.UpdateSetup(_mapper.Map<RetirementSetupViewModel, RetirementSetup>(viewModel))
                                    : _retirementSetupRepository.CreateSetup(_mapper.Map<RetirementSetupViewModel, RetirementSetup>(viewModel));
                if (result)
                {
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("compute")]
        public IActionResult Compute([FromBody] ConsumerProfileViewModel viewModel)
        {
            try
            {
                var result = _consumerProfileRepository.RequestComputation(_mapper.Map<ConsumerProfileViewModel, ConsumerProfile>(viewModel));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
