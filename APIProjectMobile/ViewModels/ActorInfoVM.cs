using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProjectMobile.ViewModels
{
    public class ActorInfoVM
    {
        public int AccId { get; set; }
        public string AccName { get; set; }
        public string AccImage { get; set; }
        public string AccDescription { get; set; }
        public string AccPhoneNum { get; set; }
        public string AccEmail { get; set; }
        public string AccPassword { get; set; }
        public string AccAdress { get; set; }
        public string AccCreateBy { get; set; }
        public DateTime? AccUpdateTime { get; set; }
        public string AccUpdateBy { get; set; }
    }
}
