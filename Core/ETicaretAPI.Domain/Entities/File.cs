using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class File : BaseEntity
    {
#pragma warning disable CS8618 // Non-nullable property 'FileName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string FileName { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'FileName' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
#pragma warning disable CS8618 // Non-nullable property 'Path' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.
        public string Path { get; set; }
#pragma warning restore CS8618 // Non-nullable property 'Path' must contain a non-null value when exiting constructor. Consider declaring the property as nullable.

        [NotMapped]
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
