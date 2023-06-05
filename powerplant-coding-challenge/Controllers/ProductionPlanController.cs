using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using powerplant.core.DTOs;
using powerplant.core.Services.ProductionPlan;

namespace powerplant_coding_challenge.Controllers
{

    [ApiController]
    [Route("/")]
    public class ProductionPlanController: ControllerBase
	{
        private readonly ILogger<ProductionPlanController> _logger;
        private readonly IProductionPlanService _productionPlanService;

        public ProductionPlanController(ILogger<ProductionPlanController> logger,
            IProductionPlanService productionPlanService)
		{
            _logger = logger;
            _productionPlanService = productionPlanService;
        }

        [HttpPost]
        public IList<ProductionPlanDto> Post([FromBody][Required] ProductionPlanInput request)
        {
            return _productionPlanService.CalculateProductionPower(request);
        }
    }
}

