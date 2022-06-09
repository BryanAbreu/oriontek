using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace oriontek.Models
{
    public partial class Client
    {
        public Client()
        {
            Direccions = new HashSet<Direccion>();
        }

       [Display(Name="idcliente")]
        public int Idclient { get; set; }
        [Display(Name="name")]
        public string Name { get; set; }

        public virtual ICollection<Direccion> Direccions { get; set; }
    }
}
