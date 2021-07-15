using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using LIR.DOMAIN.Entities;
using LIR.INFRASTRUCTURE.Interfaces;
using LIR.VIEWMODEL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LIR.WEB.Controllers
{
    public class BenefitController : Controller
    {
        private readonly IConsumerProfileRepository _consumerProfileRepository;
        private readonly IMapper _mapper;
        private readonly IRetirementSetupRepository _retirementSetupRepository;
        private readonly INotyfService _notyfService;

        public BenefitController(IRetirementSetupRepository retirementSetupRepository,
            IConsumerProfileRepository consumerProfileRepository, IMapper mapper,
            INotyfService notyfService)
        {
            _retirementSetupRepository = retirementSetupRepository;
            _consumerProfileRepository = consumerProfileRepository;
            _mapper = mapper;
            _notyfService = notyfService;
        }
        public IActionResult Request()
        {
            var viewModel = new ConsumerProfileViewModel()
            {
                Birthdate = DateTime.Now,
                ConsumerBenefitResults = new List<ConsumerBenefitResultViewModel>()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Request(ConsumerProfileViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _consumerProfileRepository.RequestComputation(_mapper.Map<ConsumerProfileViewModel, ConsumerProfile>(viewModel));
                if (result != null)
                {
                    _notyfService.Information("Request Completed");
                    return View(result);
                }
            }
            _notyfService.Warning("Request Failed");
            return View(viewModel);
        }

        public IActionResult RetirementSetup()
        {
            var result = _retirementSetupRepository.GetSetup();
            if (result != null)
            {
                return View(_mapper.Map<RetirementSetup, RetirementSetupViewModel>(result));
            }
            _notyfService.Information("No record found");
            return View(new RetirementSetupViewModel());
        }

        [HttpPost]
        public IActionResult RetirementSetup(RetirementSetupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var bindModel = _mapper.Map<RetirementSetupViewModel, RetirementSetup>(viewModel);
                var result = viewModel.Id == Guid.Empty ? _retirementSetupRepository.CreateSetup(bindModel) : _retirementSetupRepository.UpdateSetup(bindModel);
                if (result)
                {
                    _notyfService.Information("Request Completed");
                    return View(viewModel);
                }
            }
            _notyfService.Warning("Request Failed");
            return View(viewModel);
        }

        public IActionResult History()
        {
            var viewModel = _consumerProfileRepository.GetAll();
            return View(viewModel);
        }

        public IActionResult HistoryEdit(Guid id)
        {
            var viewModel = _consumerProfileRepository.GetById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult HistoryEdit(ConsumerProfileViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = _consumerProfileRepository.RequestComputation(_mapper.Map<ConsumerProfileViewModel, ConsumerProfile>(viewModel));
                if (result != null)
                {
                    _notyfService.Information("Request Completed");
                    return View(result);
                }
            }
            _notyfService.Warning("Request Failed");
            return View(viewModel);
        }
    }
}
