using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProjectMobile.ViewModels
{
    public class ScenarioBasicInfoVM
    {
        public int ScenarioId { get; set; }
        public string ScenarioName { get; set; }
        public string ScenarioDes { get; set; }
        public string ScenarioLocation { get; set; }
        public int? ScenarioStatus { get; set; }
        public string ScenarioImage { get; set; }
    }
}
