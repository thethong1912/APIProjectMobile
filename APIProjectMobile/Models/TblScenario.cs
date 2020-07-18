using System;
using System.Collections.Generic;

namespace APIProjectMobile.Models
{
    public partial class TblScenario
    {
        public TblScenario()
        {
            TblActorRoles = new HashSet<TblActorRole>();
            TblEquipmentInScenarios = new HashSet<TblEquipmentInScenario>();
        }

        public int ScenarioId { get; set; }
        public string ScenarioName { get; set; }
        public string ScenarioDes { get; set; }
        public string ScenarioLocation { get; set; }
        public DateTime? ScenarioTimeFrom { get; set; }
        public DateTime? ScenarioTimeTo { get; set; }
        public int? ScenarioCastAmout { get; set; }
        public int? ScenarioStatus { get; set; }
        public string ScenarioImage { get; set; }
        public int? ScenarioIsDelete { get; set; }
        public string ScenarioScript { get; set; }

        public virtual ICollection<TblActorRole> TblActorRoles { get; set; }
        public virtual ICollection<TblEquipmentInScenario> TblEquipmentInScenarios { get; set; }
    }
}
