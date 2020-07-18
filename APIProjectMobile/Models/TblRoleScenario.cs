using System;
using System.Collections.Generic;

namespace APIProjectMobile.Models
{
    public partial class TblRoleScenario
    {
        public TblRoleScenario()
        {
            TblActorRoles = new HashSet<TblActorRole>();
        }

        public int RoleScenarioId { get; set; }
        public string RoleScenarioName { get; set; }

        public virtual ICollection<TblActorRole> TblActorRoles { get; set; }
    }
}
