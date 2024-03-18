using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutronOrderingSystem.Models
{
    public class EnclosureModel
    {
        public int ModelId { get; set; }
        public string ModelDisplayString { get; set; }
        public string Description { get; set; }
        public string MountType { get; set; }
        public int Quantity { get; set; }

        public EnclosureModel(int modelId, string modelDisplayString, string description, string mountType, int quantity)
        {
            ModelId = modelId;
            ModelDisplayString = modelDisplayString;
            Description = description;
            MountType = mountType;
            Quantity = quantity;
        }
    }
}
