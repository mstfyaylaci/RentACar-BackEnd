﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class CustomerCreditCard : IEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int CreditCardId { get; set; }
    }
}
