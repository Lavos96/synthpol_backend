using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntPolApi.Model
{
    public class Provider
    {
        public int ProviderId { get; set; }
        public int ProviderNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public int HomeNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string NIP { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
