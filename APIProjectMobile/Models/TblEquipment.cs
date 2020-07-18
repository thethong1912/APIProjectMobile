using System;
using System.Collections.Generic;

namespace APIProjectMobile.Models
{
    public partial class TblEquipment
    {
        public TblEquipment()
        {
            TblEquipmentInScenarios = new HashSet<TblEquipmentInScenario>();
        }

        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDes { get; set; }
        public string EquipmentImage { get; set; }
        public int EquipmentQuantity { get; set; }
        public int? EquipmentStatus { get; set; }
        public int? EquipmentIsDelete { get; set; }

        public virtual ICollection<TblEquipmentInScenario> TblEquipmentInScenarios { get; set; }
    }
}
