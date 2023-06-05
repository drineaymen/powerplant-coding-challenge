using System;
using powerplant.core.DTOs;

namespace powerplant.core.Services.ProductionPlan
{
	public interface IProductionPlanService
	{
		public IList<ProductionPlanDto> CalculateProductionPower(ProductionPlanInput productionPlanInput);
	}
}

