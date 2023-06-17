using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Customer : BaseEntity
    {
#pragma warning disable CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Orders' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public ICollection<Order> Orders { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Orders' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
