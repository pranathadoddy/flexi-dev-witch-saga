using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using WitchSaga.Mvc.Models;
using WitchSaga.Service.Dto;
using WitchSaga.Service.Service;

namespace WitchSaga.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWitchService _witchService;

        public HomeController(ILogger<HomeController> logger, IWitchService witchService)
        {
            _logger = logger;
            _witchService = witchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAverageKills([FromBody] KillCalculationModel model)
        {
            var villagerA = new VillagerDto(model.AgeOfDeathA, model.DeathYearA);
            var villagerB = new VillagerDto(model.AgeOfDeathB, model.DeathYearB);
            double result = _witchService.CalculateAverageKillings(new List<VillagerDto>
            {
                villagerA,
                villagerB
            });

            if (result == -1)
            {
                return BadRequest("Invalid input data.");
            }

            return Ok(result);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}