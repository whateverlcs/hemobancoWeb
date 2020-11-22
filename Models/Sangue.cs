using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetoHemobancoWeb.Models
{
    [Table("Sangue")]
    public class Sangue : BaseModel
    {
        public string TipoSangue { get; set; }
    }
}
