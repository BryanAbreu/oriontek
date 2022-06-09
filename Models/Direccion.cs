using System;
using System.Collections.Generic;

namespace oriontek.Models
{
    public partial class Direccion
    {
        public int Iddirecc { get; set; }
        public int? Idcli { get; set; }
        public string Direccion1 { get; set; }

        public virtual Client? IdcliNavigation { get; set; }
    }
}
