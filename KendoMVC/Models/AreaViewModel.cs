using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoMVC.Models
{
    public class AreaViewModel
    {
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    public class AddAreaViewModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
    public class EditAreaViewModel
    {
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}