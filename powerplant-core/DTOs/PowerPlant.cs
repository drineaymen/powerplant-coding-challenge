using System;
using System.Text.Json.Serialization;
using powerplant.core.Constants;

namespace powerplant.core.DTOs
{
	public class PowerPlant
	{
        public PowerPlant()
        {
            Name = string.Empty;
        }

		public string Name { get; set; }

        public PowerType Type { get; set; }

        public decimal Efficiency { get; set; }

        public decimal PMin { get; set; }

        public decimal PMax { get; set; }

        [JsonIgnore]
        public decimal MeritOrder { get; set; }

        [JsonIgnore]
        public decimal Cost { get; set; }

        [JsonIgnore]
        public decimal Production { get; set; }
    }
}

