using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mengassini.WebApi.Models
{
    public class ProductsView
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public decimal? Precio { get; set; }
        public short? UStock { get; set; }
        public short? UOrdenadas { get; set; }
    }
}