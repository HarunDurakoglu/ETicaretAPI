using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
#pragma warning disable CS8618 // Non-nullable property 'Description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Description { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Description' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Address' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Address { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Address' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Products' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public ICollection<Product> Products { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Products' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Customer' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public Customer Customer { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Customer' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
    }
}
