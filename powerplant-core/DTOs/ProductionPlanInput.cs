using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace powerplant.core.DTOs
{
	public class ProductionPlanInput
	{
        public decimal Load { get; set; }
        public Fuel Fuels { get; set; }
        public IList<PowerPlant> PowerPlants { get; set; }
    }
}

