using System.ComponentModel.DataAnnotations;

namespace oriontek.Models.ViewModels
{
    public class ClientViewmodel
    {
        [Display(Name="nombre")]
      public  string name { get; set; }

      public int? idcli { get; set; }

        public List<Direccion>? Direcciones { get; set; }
    }
}
