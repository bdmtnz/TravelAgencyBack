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
        public int Id { get; set; }
        public bool Enabled { get; set; } = true;
    }
}
