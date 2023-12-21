using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Domain.Base
{
    public abstract class Entity : IEntity
    {
        public string Id { get; private set; }
        public bool Enabled { get; private set; } = true;

        public Entity()
        {
            SetId(Guid.NewGuid().ToString());
        }

        public void SetEnable(bool enable)
        {
            Enabled = enable;
        }

        public void SetId(string id)
        {
            if (string.IsNullOrEmpty(Id) && !string.IsNullOrEmpty(id)) Id = id;
        }
    }
}
