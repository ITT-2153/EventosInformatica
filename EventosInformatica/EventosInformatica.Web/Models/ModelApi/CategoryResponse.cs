using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosInformatica.Web.Models.ModelApi
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<EventResponse> Events { get; set; }
    }
}
