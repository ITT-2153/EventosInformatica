using EventosInformatica.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosInformatica.Web.Models.ModelApi
{
    public class EventResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? EventDate { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public int People { get; set; }
        public int Duration { get; set; }
        public string City { get; set; }
        public string Client { get; set; }
        public string Category { get; set; }
    }
}
