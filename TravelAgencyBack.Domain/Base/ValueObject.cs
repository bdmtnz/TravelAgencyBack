using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Domain.Base
{
    public class ValueObject<T> : IValueObject where T : IEntity
    {
        public string Id { get; private set; }

        [ForeignKey("Foreign")]
        public string IdForeign { get; set; }
        public T Foreign { get; private set; }

        public ValueObject()
        {
            SetId(Guid.NewGuid().ToString());
        }

        public void SetId(string id)
        {
            if (string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(id)) Id = id;
        }
    }
}
