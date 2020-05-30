using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventosInformatica.Web.Models.ModelApi
{
    public class ClientResponse
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<EventResponse> Events { get; set; }
    }
}
