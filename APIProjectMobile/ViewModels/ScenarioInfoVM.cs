﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProjectMobile.ViewModels
{
    public class ScenarioInfoVM
    {
        public int ScenarioId { get; set; }
        public string ScenarioName { get; set; }
        public string ScenarioDes { get; set; }
        public string ScenarioLocation { get; set; }
        public DateTime? ScenarioTimeFrom { get; set; }
        public DateTime? ScenarioTimeTo { get; set; }
        public int? ScenarioCastAmout { get; set; }
        public string ScenarioImage { get; set; }
        public string ScenarioScript { get; set; }
    }
}
