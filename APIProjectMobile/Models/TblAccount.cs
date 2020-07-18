using System;
using System.Collections.Generic;

namespace APIProjectMobile.Models
{
    public partial class TblAccount
    {
        public TblAccount()
        {
            TblActorRoles = new HashSet<TblActorRole>();
        }

        public int AccId { get; set; }
        public string AccName { get; set; }
        public string AccImage { get; set; }
        public string AccDescription { get; set; }
        public string AccPhoneNum { get; set; }
        public string AccEmail { get; set; }
        public string AccPassword { get; set; }
        public string AccAdress { get; set; }
        public int AccRole { get; set; }
        public int AccStatus { get; set; }
        public int? AccIsDelete { get; set; }
        public string AccCreateBy { get; set; }
        public string AccUpdateBy { get; set; }
        public DateTime? AccUpdateTime { get; set; }

        public virtual ICollection<TblActorRole> TblActorRoles { get; set; }
    }
}
