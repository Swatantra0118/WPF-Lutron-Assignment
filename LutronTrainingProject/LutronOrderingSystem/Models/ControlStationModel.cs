using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutronOrderingSystem.Models
{
    public class ControlStationModel
    {
        public int ModelId { get; set; }
        public string ModelDisplayString { get; set; }
        public string Description { get; set; }
        public int NumberOfButtons { get; set; }
        public int Quantity { get; set; }

        public ControlStationModel(int modelId, string modelDisplayString, string description, int numberOfButtons, int quantity)
        {
            ModelId = modelId;
            ModelDisplayString = modelDisplayString;
            Description = description;
            NumberOfButtons = numberOfButtons;
            Quantity = quantity;
        }
    }
}
