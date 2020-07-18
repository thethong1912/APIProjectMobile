using System;
using System.Collections.Generic;

namespace APIProjectMobile.Models
{
    public partial class TblActorRole
    {
        public int ActorRoleId { get; set; }
        public int? ActorInScenario { get; set; }
        public int? RoleScenarioId { get; set; }
        public int? ScenarioId { get; set; }
        public string ActorRoleDescription { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? AdminId { get; set; }

        public virtual TblAccount ActorInScenarioNavigation { get; set; }
        public virtual TblRoleScenario RoleScenario { get; set; }
        public virtual TblScenario Scenario { get; set; }
    }
}
