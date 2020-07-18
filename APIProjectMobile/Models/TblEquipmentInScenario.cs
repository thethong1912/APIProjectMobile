using System;
using System.Collections.Generic;

namespace APIProjectMobile.Models
{
    public partial class TblEquipmentInScenario
    {
        public int EquipInScenario { get; set; }
        public int? ScenarioId { get; set; }
        public int? EquipmentId { get; set; }
        public int? EquipmentQuantity { get; set; }

        public virtual TblEquipment Equipment { get; set; }
        public virtual TblScenario Scenario { get; set; }
    }
}
