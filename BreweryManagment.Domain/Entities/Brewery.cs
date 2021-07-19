using System;
using System.Collections.Generic;

namespace BreweryManagment.Domain.Entities
{
    public partial class Brewery
    {
        public Brewery()
        {
            Beer = new HashSet<Beer>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Beer> Beer { get; set; }
    }
}
