using System;
using System.Collections.Generic;


namespace BreweryManagment.Domain.Entities
{
    public partial class Beer
    {
        public Guid Id { get; set; }
        public Guid BreweryId { get; set; }
        public string Name { get; set; }
        public decimal? AlcoholPercentage { get; set; }
        public decimal? Price { get; set; }

        public virtual Brewery Brewery { get; set; }
    }
}
