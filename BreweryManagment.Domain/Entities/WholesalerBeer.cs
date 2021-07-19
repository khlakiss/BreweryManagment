using System;
using System.Collections.Generic;

namespace BreweryManagment.Domain.Entities
{
    public partial class WholesalerBeer
    {
        public Guid Id { get; set; }
        public Guid WholesalerId { get; set; }
        public Guid BeerId { get; set; }
        public long? StockQuantity { get; set; }

        public virtual Beer Beer { get; set; }
        public virtual Wholesaler Wholesaler { get; set; }
    }
}
