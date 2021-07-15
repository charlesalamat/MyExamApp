using AutoMapper;
using LIR.DOMAIN.Entities;
using LIR.INFRASTRUCTURE.Interfaces;
using LIR.VIEWMODEL.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIR.API.Controllers
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
            _consumerProfileRepository = consumerProfileRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get setup setting for computation
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Configure the setup setting for computation
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost("configureSetup")]
        public IActionResult ConfigureSetup([FromBody] RetirementSetupViewModel viewModel)
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

        /// <summary>
        /// Complete computation request
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get all history of all consumer
        /// </summary>
        /// <returns></returns>
        [HttpGet("history")]
        public IActionResult History()
        {
            try
            {
                var result = _consumerProfileRepository.GetAll();
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Get record of consumer by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("historyEdit")]
        public IActionResult HistoryEdit(Guid id)
        {
            try
            {
                var result = _consumerProfileRepository.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Update consumer record
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("historyEdit")]
        public IActionResult HistoryEdit([FromBody] ConsumerProfileViewModel viewModel)
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
