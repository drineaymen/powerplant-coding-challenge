using System;
using System.Text.Json.Serialization;

namespace powerplant.core.DTOs
{
	public class ProductionPlanDto
	{
		public ProductionPlanDto()
		{
			Name = string.Empty;
		}

		public string Name { get; set; }
		public decimal P { get; set; }
    }

}

