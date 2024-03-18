using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LutronOrderingSystem.Models
{
    public class ProductModel
    {
        public enum ProductCategory
        {
            ControlStation,
            Enclosure
        }
        public enum MountTypeEnum
        {
            WallMount,
            TableTop,
            PanelMount
        }
        public int ModelId { get; set; }
        public string ModelDisplayString { get; set; }
        public string Description { get; set; }
        public ProductCategory Category { get; set; } // Category: ControlStation or Enclosure
        public int? NumberOfButtons { get; set; } // Only applicable for ControlStation
        public MountTypeEnum? MountType { get; set; } // Only applicable for Enclosure
        public int Quantity { get; set; }
    }
}
