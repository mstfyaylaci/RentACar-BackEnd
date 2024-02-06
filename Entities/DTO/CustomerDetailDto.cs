using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class CustomerDetailDto:IDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string CompanyName { get; set; }
    }
}
