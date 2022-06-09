using System.ComponentModel.DataAnnotations;

namespace oriontek.Models.ViewModels
{
    public class DireccViewmodel
    {
        [Display(Name="nombredirec")]
        public string direccion { get; set; }
        [Display(Name="idcliente")]
        public int idclient { get; set; }
    }
}
