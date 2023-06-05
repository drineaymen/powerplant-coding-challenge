using System;
using powerplant.core.Constants;
using powerplant.core.DTOs;

namespace powerplant.core.Services.ProductionPlan
{
    /// <summary>
    /// Determine witch power plants should run and how much power each power plant must produce
    /// </summary>
    public class ProductionPlanService : IProductionPlanService
    {
        private decimal PowerLoadLeft = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productionPlanInput"></param>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public IList<ProductionPlanDto> CalculateProductionPower(ProductionPlanInput productionPlanInput)
        {
            if (!productionPlanInput.PowerPlants.Any())
            {
                throw new InvalidDataException("Please provide power plants.");
            }

            PowerLoadLeft = productionPlanInput.Load;

            var productionPlants = CalculateMeritCostProduction(productionPlanInput);

            return productionPlants.Select(pp =>
            {
                var plant = CalculateRealProduction(pp, productionPlanInput.Fuels);

                return new ProductionPlanDto()
                {
                    Name = pp.Name,
                    P = plant.Production
                };
            })
                .ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plant"></param>
        /// <param name="fuels"></param>
        /// <returns></returns>
        private PowerPlant CalculateRealProduction(PowerPlant plant, Fuel fuels)
        {
            if (PowerLoadLeft <= 0)
            {
                plant.Production = 0;
                return plant;
            }

            if (plant.Type == PowerType.WindTurbine)
            {
                plant.Production = plant.PMax * (fuels.Wind / 100);
                PowerLoadLeft -= plant.Production;
                return plant;
            }

            plant.Production = PowerLoadLeft > plant.PMax ? plant.PMax : PowerLoadLeft;
            PowerLoadLeft -= plant.Production;
            return plant;
        }

        /// <summary>
        /// Caculate merite order, production cost of plants using fuel
        /// </summary>
        /// <param name="productionPlanInput">Production plan input</param>
        /// <returns>List of power plants</returns>
        private IList<PowerPlant> CalculateMeritCostProduction(ProductionPlanInput productionPlanInput)
        {
            foreach (var plant in productionPlanInput.PowerPlants)
            {
                switch (plant.Type)
                {
                    case PowerType.TurboJet:
                        if (productionPlanInput.Fuels.Kerosine > 0)
                        {
                            plant.Cost = (plant.PMax * productionPlanInput.Fuels.Kerosine) * plant.Efficiency;
                            plant.MeritOrder = plant.PMax - plant.Cost;
                        }
                        break;
                    case PowerType.GasFired:
                        if (productionPlanInput.Fuels.Gas > 0)
                        {
                            plant.Cost = (plant.PMax * productionPlanInput.Fuels.Gas) * plant.Efficiency;
                            plant.MeritOrder = plant.PMax - plant.Cost;
                        }
                        break;
                }
            }

            return productionPlanInput.PowerPlants.OrderBy(pp => pp.MeritOrder).ToList();
        }
    }
}

