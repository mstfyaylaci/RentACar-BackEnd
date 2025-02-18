using Core.Entities;
using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class RentalDetailDto:IDTO
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public int CarId { get; set; }
        public string CarName { get; set; }

        public int DailyPrice { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public bool? DeliveryStatus { get; set; }
    }
}
